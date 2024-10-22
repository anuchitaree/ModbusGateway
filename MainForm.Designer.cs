namespace ModbusGateway
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DgvList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbClientIp = new System.Windows.Forms.TextBox();
            this.tbClientPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnConn1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvList
            // 
            this.DgvList.AllowUserToDeleteRows = false;
            this.DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvList.Location = new System.Drawing.Point(30, 153);
            this.DgvList.Name = "DgvList";
            this.DgvList.Size = new System.Drawing.Size(911, 367);
            this.DgvList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TCP Port";
            // 
            // tbClientIp
            // 
            this.tbClientIp.Location = new System.Drawing.Point(104, 41);
            this.tbClientIp.Name = "tbClientIp";
            this.tbClientIp.Size = new System.Drawing.Size(100, 20);
            this.tbClientIp.TabIndex = 2;
            this.tbClientIp.Text = "127.0.0.1";
            // 
            // tbClientPort
            // 
            this.tbClientPort.Location = new System.Drawing.Point(102, 71);
            this.tbClientPort.Name = "tbClientPort";
            this.tbClientPort.Size = new System.Drawing.Size(100, 20);
            this.tbClientPort.TabIndex = 2;
            this.tbClientPort.Text = "502";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Network interface";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "TCP Port";
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(489, 41);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(100, 20);
            this.tbServerIp.TabIndex = 2;
            this.tbServerIp.Text = "192.168.2.1";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(487, 71);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(100, 20);
            this.tbServerPort.TabIndex = 2;
            this.tbServerPort.Text = "502";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Server";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Client";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(30, 527);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(911, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.Text = "status:";
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(845, 102);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(82, 40);
            this.btnMonitor.TabIndex = 4;
            this.btnMonitor.Text = "Monitoring";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // btnConn1
            // 
            this.btnConn1.Location = new System.Drawing.Point(665, 55);
            this.btnConn1.Name = "btnConn1";
            this.btnConn1.Size = new System.Drawing.Size(87, 36);
            this.btnConn1.TabIndex = 5;
            this.btnConn1.Text = "Conntection1";
            this.btnConn1.UseVisualStyleBackColor = true;
            this.btnConn1.Click += new System.EventHandler(this.btnConn1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 557);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConn1);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.tbServerPort);
            this.Controls.Add(this.tbClientPort);
            this.Controls.Add(this.tbServerIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbClientIp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvList);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbClientIp;
        private System.Windows.Forms.TextBox tbClientPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Button btnConn1;
        private System.Windows.Forms.Button button1;
    }
}

