using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlServerBakRestore
{
    public partial class Form1 : Form
    {
        static string connectionString;
        static string db_Data_Path;
        static string db_Log_Path;
        string path;

        int count = 0;//總數量
        int time = 0;
        int h = 0, m = 0, s = 0;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            timer1.Interval = 1000; // 設定每秒觸發一次
        }

        private void init()
        {
            connectionString = txtConnectionString.Text;
            db_Data_Path = txtDb_Data_Path.Text;
            db_Log_Path = txtDb_Log_Path.Text;
            path = txtPath.Text;
            count = 0;
        }

        private void GetFolder(string path)
        {
            string[] dirs = Directory.GetDirectories(path);/*目錄(含路徑)的陣列*/
            string folderName;
            string[] fileNames;
            int i = 0;

            //System.Collections.ArrayList dirlist = new System.Collections.ArrayList();/*用來儲存只有目錄名的集合*/

            foreach (string item in dirs)
            {
                folderName = Path.GetFileNameWithoutExtension(item);//走訪每個元素只取得目錄名稱(不含路徑)並加入dirlist集合中
                fileNames = Directory.GetFileSystemEntries(item.ToString());//取得資料夾下的檔案名稱(含路徑,附檔名)

                foreach (var fileName in fileNames)
                    //if (fileName.Contains("20130312"))
                    count++;
            }

            backgroundWorker1.ReportProgress(0, "共有 " + count);

            foreach (string item in dirs)
            {
                folderName = Path.GetFileNameWithoutExtension(item);//走訪每個元素只取得目錄名稱(不含路徑)並加入dirlist集合中
                fileNames = Directory.GetFileSystemEntries(item.ToString());//取得資料夾下的檔案名稱(含路徑,附檔名)

                foreach (var fileName in fileNames)
                {
                    //if (fileName.Contains("20130312"))
                    //{
                    //Console.WriteLine(fileName);
                    backgroundWorker1.ReportProgress(i, fileName);
                    RestoreDataBase(folderName, fileName);//連接SQL開始還原                        
                    i++;
                    //}
                }
            }
            //Console.WriteLine(count);
        }

        private void testConnection()
        {
            try
            {
                SqlConnection objSaConn = new SqlConnection(connectionString);
                objSaConn.Open();
                MessageBox.Show("connect success " + count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RestoreDataBase(string DatabaseName, string BakFileName)
        {
            string DataFile = "", DataFilePath = "", LogFile = "", LogFilePath = "";

            SqlConnection objSaConn = new SqlConnection(connectionString);
            SqlCommand cmd;
            objSaConn.Open();

            try
            {
                cmd = new SqlCommand("RESTORE FILELISTONLY FROM DISK = '" + BakFileName + "'", objSaConn);

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd["Type"].ToString() == "D")
                    {
                        DataFile = rd["LogicalName"].ToString();
                        DataFilePath = rd["PhysicalName"].ToString();
                    }
                    else if (rd["Type"].ToString() == "L")
                    {
                        LogFile = rd["LogicalName"].ToString();
                        LogFilePath = rd["PhysicalName"].ToString();
                    }
                }
                rd.Close();

                cmd = new SqlCommand("Use Master", objSaConn);
                cmd.ExecuteNonQuery();

                //MessageBox.Show("DataFilePath : " + DataFilePath + "\r\n" +
                //    "LogFilePath : " + LogFilePath + "\r\n");

                String sqlString;

                sqlString = Environment.NewLine + string.Format(
                    "RESTORE DATABASE [{0}] " +
                    "FROM DISK = '{1}' " +
                    "WITH " +
                    "MOVE '{2}' to '{3}', " +
                    "MOVE '{4}' to '{5}', " +
                    "NORECOVERY, Replace",
                    DatabaseName, BakFileName,
                    DataFile, db_Data_Path + "\\" + DataFilePath.Substring(DataFilePath.LastIndexOf("\\")),
                    LogFile, db_Log_Path + "\\" + LogFilePath.Substring(LogFilePath.LastIndexOf("\\")));

                cmd = new SqlCommand(sqlString, objSaConn);
                cmd.CommandTimeout = 0; //預設30s
                cmd.ExecuteNonQuery();

                //MessageBox.Show("123");

                sqlString = Environment.NewLine + string.Format(
                    "RESTORE DATABASE [{0}] " +
                    "FROM DISK = '{1}' ",
                    DatabaseName, BakFileName);

                cmd = new SqlCommand(sqlString, objSaConn);
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                using (StreamWriter sw = System.IO.File.AppendText("Error.txt"))
                {
                    sw.WriteLine(DatabaseName + " : " + ex.Message + "\r\n");
                }
            }
        }


        //        BACKUP DATABASE [SyncSamplesDb_SqlPeer1] 
        //TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\Backup\SyncSamplesDb_SqlPeer1.bak' 
        //WITH NOFORMAT, NOINIT,  NAME = N'SyncSamplesDb_SqlPeer1-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10


        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            init();

            string[] dirs = Directory.GetDirectories(path);/*目錄(含路徑)的陣列*/
            string folderName;
            string[] fileNames;

            foreach (string item in dirs)
            {
                folderName = Path.GetFileNameWithoutExtension(item);//走訪每個元素只取得目錄名稱(不含路徑)並加入dirlist集合中
                fileNames = Directory.GetFileSystemEntries(item.ToString());//取得資料夾下的檔案名稱(含路徑,附檔名)

                foreach (var fileName in fileNames)
                    count++;
            }

            testConnection();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true; // 啟動 Timer
            timer1.Start();

            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            init();
            GetFolder(path);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Maximum = count - 1; //用於progressBar
                progressBar1.Value = e.ProgressPercentage;

                txtInfo.Text += "Restoring " + e.UserState + "\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Stop();
            txtInfo.Text += "Complete";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;

            h = time / 60 / 60;
            m = time / 60 % 60;
            s = time % 60 % 60;

            labTime.Text = h.ToString("D2") + ":" + m.ToString("D2") + ":" + s.ToString("D2");
        }
    }
}
