namespace SqlServerBakRestore
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.txtDb_Log_Path = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDb_Data_Path = new System.Windows.Forms.TextBox();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.labTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(14, 24);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(442, 22);
            this.txtConnectionString.TabIndex = 0;
            this.txtConnectionString.Text = "Data Source=THOMAS-SQL-3\\SQLSERVER2;Trusted_Connection=true";
            // 
            // txtDb_Log_Path
            // 
            this.txtDb_Log_Path.Location = new System.Drawing.Point(16, 124);
            this.txtDb_Log_Path.Name = "txtDb_Log_Path";
            this.txtDb_Log_Path.Size = new System.Drawing.Size(440, 22);
            this.txtDb_Log_Path.TabIndex = 2;
            this.txtDb_Log_Path.Text = "D:\\MSSQL2\\DATA";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(16, 173);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(440, 22);
            this.txtPath.TabIndex = 3;
            this.txtPath.Text = "D:\\DB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connection String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Db Data Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Db Log Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = ".BAK File Path";
            // 
            // txtDb_Data_Path
            // 
            this.txtDb_Data_Path.Location = new System.Drawing.Point(14, 74);
            this.txtDb_Data_Path.Name = "txtDb_Data_Path";
            this.txtDb_Data_Path.Size = new System.Drawing.Size(442, 22);
            this.txtDb_Data_Path.TabIndex = 1;
            this.txtDb_Data_Path.Text = "D:\\MSSQL2\\DATA";
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Location = new System.Drawing.Point(16, 201);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnect.TabIndex = 8;
            this.btnTestConnect.Text = "Test Connect";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(109, 201);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 421);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(364, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(14, 230);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(442, 185);
            this.txtInfo.TabIndex = 11;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Font = new System.Drawing.Font("新細明體", 12F);
            this.labTime.Location = new System.Drawing.Point(389, 425);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(64, 16);
            this.labTime.TabIndex = 12;
            this.labTime.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 456);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnTestConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtDb_Log_Path);
            this.Controls.Add(this.txtDb_Data_Path);
            this.Controls.Add(this.txtConnectionString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.TextBox txtDb_Log_Path;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDb_Data_Path;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.Button btnRestore;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Timer timer1;
    }
}

