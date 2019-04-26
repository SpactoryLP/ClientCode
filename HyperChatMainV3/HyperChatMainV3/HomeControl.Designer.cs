namespace HyperChatMainV3
{
    partial class HomeControl
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.HomeGroup = new System.Windows.Forms.GroupBox();
            this.SignUpBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SignInBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.HomeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.HomeGroup);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1435, 637);
            this.MainPanel.TabIndex = 10;
            // 
            // HomeGroup
            // 
            this.HomeGroup.Controls.Add(this.SignUpBTN);
            this.HomeGroup.Controls.Add(this.label3);
            this.HomeGroup.Controls.Add(this.SignInBTN);
            this.HomeGroup.Controls.Add(this.label2);
            this.HomeGroup.Controls.Add(this.label1);
            this.HomeGroup.Location = new System.Drawing.Point(13, 9);
            this.HomeGroup.Name = "HomeGroup";
            this.HomeGroup.Size = new System.Drawing.Size(1408, 100);
            this.HomeGroup.TabIndex = 10;
            this.HomeGroup.TabStop = false;
            // 
            // SignUpBTN
            // 
            this.SignUpBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpBTN.Location = new System.Drawing.Point(1288, 32);
            this.SignUpBTN.Name = "SignUpBTN";
            this.SignUpBTN.Size = new System.Drawing.Size(97, 36);
            this.SignUpBTN.TabIndex = 11;
            this.SignUpBTN.Text = "Sign Up";
            this.SignUpBTN.UseVisualStyleBackColor = true;
            this.SignUpBTN.Click += new System.EventHandler(this.SignUpBTN_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(930, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "If you don\'t have an account please";
            // 
            // SignInBTN
            // 
            this.SignInBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInBTN.Location = new System.Drawing.Point(336, 31);
            this.SignInBTN.Name = "SignInBTN";
            this.SignInBTN.Size = new System.Drawing.Size(97, 35);
            this.SignInBTN.TabIndex = 9;
            this.SignInBTN.Text = "Sign In";
            this.SignInBTN.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "If you have an account please";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CadetBlue;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(487, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome to HyperChat";
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(1435, 640);
            this.MainPanel.ResumeLayout(false);
            this.HomeGroup.ResumeLayout(false);
            this.HomeGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.GroupBox HomeGroup;
        private System.Windows.Forms.Button SignUpBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SignInBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
