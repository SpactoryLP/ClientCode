namespace HyperChatMainV3
{
    partial class FileTransferControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ErrorLBL = new System.Windows.Forms.Label();
            this.SendBTN = new System.Windows.Forms.Button();
            this.pb_upload = new System.Windows.Forms.ProgressBar();
            this.SendLBL = new System.Windows.Forms.Label();
            this.SelectDBTN = new System.Windows.Forms.Button();
            this.SelectFBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ErrorLBL
            // 
            this.ErrorLBL.AutoSize = true;
            this.ErrorLBL.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLBL.ForeColor = System.Drawing.Color.Red;
            this.ErrorLBL.Location = new System.Drawing.Point(490, 382);
            this.ErrorLBL.Name = "ErrorLBL";
            this.ErrorLBL.Size = new System.Drawing.Size(0, 25);
            this.ErrorLBL.TabIndex = 13;
            // 
            // SendBTN
            // 
            this.SendBTN.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBTN.Location = new System.Drawing.Point(596, 231);
            this.SendBTN.Name = "SendBTN";
            this.SendBTN.Size = new System.Drawing.Size(182, 35);
            this.SendBTN.TabIndex = 12;
            this.SendBTN.Text = "Send";
            this.SendBTN.UseVisualStyleBackColor = true;
            this.SendBTN.Click += new System.EventHandler(this.SendBTN_Click_1);
            // 
            // pb_upload
            // 
            this.pb_upload.Location = new System.Drawing.Point(454, 334);
            this.pb_upload.Name = "pb_upload";
            this.pb_upload.Size = new System.Drawing.Size(451, 23);
            this.pb_upload.TabIndex = 11;
            // 
            // SendLBL
            // 
            this.SendLBL.AutoSize = true;
            this.SendLBL.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendLBL.Location = new System.Drawing.Point(397, 275);
            this.SendLBL.Name = "SendLBL";
            this.SendLBL.Size = new System.Drawing.Size(0, 24);
            this.SendLBL.TabIndex = 10;
            // 
            // SelectDBTN
            // 
            this.SelectDBTN.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDBTN.Location = new System.Drawing.Point(493, 171);
            this.SelectDBTN.Name = "SelectDBTN";
            this.SelectDBTN.Size = new System.Drawing.Size(182, 33);
            this.SelectDBTN.TabIndex = 9;
            this.SelectDBTN.Text = "Select Directory";
            this.SelectDBTN.UseVisualStyleBackColor = true;
            this.SelectDBTN.Click += new System.EventHandler(this.SelectDBTN_Click);
            // 
            // SelectFBTN
            // 
            this.SelectFBTN.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFBTN.Location = new System.Drawing.Point(717, 171);
            this.SelectFBTN.Name = "SelectFBTN";
            this.SelectFBTN.Size = new System.Drawing.Size(155, 33);
            this.SelectFBTN.TabIndex = 8;
            this.SelectFBTN.Text = "Select File";
            this.SelectFBTN.UseVisualStyleBackColor = true;
            this.SelectFBTN.Click += new System.EventHandler(this.SelectFBTN_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CadetBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(582, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 44);
            this.label1.TabIndex = 7;
            this.label1.Text = "File transfer";
            // 
            // FileTransferControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ErrorLBL);
            this.Controls.Add(this.SendBTN);
            this.Controls.Add(this.pb_upload);
            this.Controls.Add(this.SendLBL);
            this.Controls.Add(this.SelectDBTN);
            this.Controls.Add(this.SelectFBTN);
            this.Controls.Add(this.label1);
            this.Name = "FileTransferControl";
            this.Size = new System.Drawing.Size(1435, 640);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ErrorLBL;
        private System.Windows.Forms.Button SendBTN;
        private System.Windows.Forms.ProgressBar pb_upload;
        private System.Windows.Forms.Label SendLBL;
        private System.Windows.Forms.Button SelectDBTN;
        private System.Windows.Forms.Button SelectFBTN;
        private System.Windows.Forms.Label label1;
    }
}
