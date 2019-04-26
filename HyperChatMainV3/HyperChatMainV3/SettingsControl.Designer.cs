namespace HyperChatMainV3
{
    partial class SettingsControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.ApplyBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.FormatsTBX = new System.Windows.Forms.TextBox();
            this.ErrorLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CadetBlue;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(655, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 40);
            this.label1.TabIndex = 8;
            this.label1.Text = "Settings";
            // 
            // ApplyBTN
            // 
            this.ApplyBTN.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyBTN.Location = new System.Drawing.Point(811, 89);
            this.ApplyBTN.Name = "ApplyBTN";
            this.ApplyBTN.Size = new System.Drawing.Size(75, 34);
            this.ApplyBTN.TabIndex = 15;
            this.ApplyBTN.Text = "Apply";
            this.ApplyBTN.UseVisualStyleBackColor = true;
            this.ApplyBTN.Click += new System.EventHandler(this.ApplyBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(580, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Please type file formats that you don\'t want to receive from others";
            // 
            // FormatsTBX
            // 
            this.FormatsTBX.Location = new System.Drawing.Point(685, 97);
            this.FormatsTBX.Name = "FormatsTBX";
            this.FormatsTBX.Size = new System.Drawing.Size(100, 22);
            this.FormatsTBX.TabIndex = 16;
            // 
            // ErrorLBL
            // 
            this.ErrorLBL.AutoSize = true;
            this.ErrorLBL.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLBL.ForeColor = System.Drawing.Color.Red;
            this.ErrorLBL.Location = new System.Drawing.Point(942, 95);
            this.ErrorLBL.Name = "ErrorLBL";
            this.ErrorLBL.Size = new System.Drawing.Size(0, 23);
            this.ErrorLBL.TabIndex = 17;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ErrorLBL);
            this.Controls.Add(this.FormatsTBX);
            this.Controls.Add(this.ApplyBTN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(1435, 640);
            this.Load += new System.EventHandler(this.SettingsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ApplyBTN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FormatsTBX;
        private System.Windows.Forms.Label ErrorLBL;
    }
}
