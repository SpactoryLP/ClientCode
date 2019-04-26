namespace HyperChatMainV3
{
    partial class FriendsControl
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
            this.MangeFriends = new System.Windows.Forms.GroupBox();
            this.SearchFriends = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchFriends.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MangeFriends
            // 
            this.MangeFriends.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MangeFriends.Location = new System.Drawing.Point(3, 64);
            this.MangeFriends.Name = "MangeFriends";
            this.MangeFriends.Size = new System.Drawing.Size(702, 455);
            this.MangeFriends.TabIndex = 0;
            this.MangeFriends.TabStop = false;
            this.MangeFriends.Text = "Your friends";
            // 
            // SearchFriends
            // 
            this.SearchFriends.Controls.Add(this.groupBox1);
            this.SearchFriends.Controls.Add(this.panel1);
            this.SearchFriends.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchFriends.Location = new System.Drawing.Point(711, 64);
            this.SearchFriends.Name = "SearchFriends";
            this.SearchFriends.Size = new System.Drawing.Size(703, 455);
            this.SearchFriends.TabIndex = 1;
            this.SearchFriends.TabStop = false;
            this.SearchFriends.Text = "Search for friends";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 359);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SearchBTN);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(7, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 64);
            this.panel1.TabIndex = 0;
            // 
            // SearchBTN
            // 
            this.SearchBTN.Location = new System.Drawing.Point(585, 17);
            this.SearchBTN.Name = "SearchBTN";
            this.SearchBTN.Size = new System.Drawing.Size(102, 33);
            this.SearchBTN.TabIndex = 2;
            this.SearchBTN.Text = "Search";
            this.SearchBTN.UseVisualStyleBackColor = true;
            this.SearchBTN.Click += new System.EventHandler(this.SearchBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter a name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(163, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(380, 30);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CadetBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(635, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 44);
            this.label1.TabIndex = 8;
            this.label1.Text = "Friends";
            // 
            // FriendsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchFriends);
            this.Controls.Add(this.MangeFriends);
            this.Name = "FriendsControl";
            this.Size = new System.Drawing.Size(1435, 640);
            this.SearchFriends.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MangeFriends;
        private System.Windows.Forms.GroupBox SearchFriends;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SearchBTN;
    }
}
