using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace HyperChatMainV3
{
    public partial class SignUpControl : UserControl
    {
        private static SignUpControl control;

        public static SignUpControl Instance
        {
            get
            {
                if (control == null)
                    control = new SignUpControl();
                return control;
            }
        }

        //MesTB.Text = "";

        //stream.Close();
        //client.Close();

        bool VaildEMail = false;

        int found;

        private static string hashedPass;

        bool passCorrect = false;

        bool passMatch = false;

        public bool IconSelected = false;

        bool passLength = false;

        OpenFileDialog ofd = new OpenFileDialog(); //System.IO FileDialog
        
        public SignUpControl()
        {
            InitializeComponent();
        }

        //Convert password to MD5 Hash
        private void ToHash(string pass)
        {
            MD5 mD5 = MD5.Create();
            byte[] b = Encoding.ASCII.GetBytes(pass);
            byte[] hash = mD5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();

            foreach (var a in hash)
                sb.Append(a.ToString("X2"));
            hashedPass = sb.ToString();
        }

        private void VaildMail()
        {
            if (CheckMail.checkForMail(EMTBX_Rec.Text.ToString()))
                VaildEMail = true;
            else
                VaildEMail = false;

        }

        //select profile image
        public void SelectImgBTN_Click_1(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //ProfilePicBox.Image = Image.FromFile(ofd.FileName);

                IconSelected = true;
            }
        }

        private void SignUpBTN_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctl in MainPanel.Controls)
            {
                if (ctl is TextBox)
                {
                    int find = ctl.Name.ToString().IndexOf("_Rec", 0);

                    if (find > 0 && ctl.Text == "")
                    {
                        ctl.BackColor = Color.Red;
                        ctl.ForeColor = Color.White;
                    }
                    else
                    {
                        ctl.BackColor = Color.White;
                        ctl.ForeColor = Color.Black;
                    }

                    while (find > 0 && ctl.Text == "")
                    {
                        found = 1;
                    }
                }
            }

            if (found == 0 && CheckMail.checkForMail(EMTBX_Rec.Text) && passCorrect == true && passMatch == true && passLength == true)
            {
                ToHash(PassTBX1_Rec.Text);

                newUser user = new newUser(FNameTBX_Rec.Text, LNameTBX_Rec.Text, EMTBX_Rec.Text, hashedPass);

                if (IconSelected == true) //"Say to class that the user selected a profile image"
                {
                    //user.SendIcon(ofd.FileName);

                    user.GetIpAndId();//Get IP and ID

                    user.Pair();//Pair the IP and the ID together

                    user.FinalSend(true, ofd.FileName);

                    //user.SendProps();//Send everything to server
                }
                else
                {
                    user.GetIpAndId();//Get IP and ID

                    user.Pair();//Pair the IP and the ID together

                    user.FinalSend(false, "");
                }

                //user.GetIpAndId();//Get IP and ID

                //user.Pair();//Pair the IP and the ID together

                //user.SendProps();//Send everything to server
            }
        }

        //main delay function
        private async void Delay(int time)
        {
            await Task.Delay(time);
        }

        private void SeePassCB_CheckedChanged(object sender, EventArgs e)
        {
            if (SeePassCB.Checked)
            {
                PassTBX1_Rec.UseSystemPasswordChar = false;
            }
            else
            {
                PassTBX1_Rec.UseSystemPasswordChar = true;
            }
        }

        private void FNameTBX_Rec_TextChanged(object sender, EventArgs e)
        {
            FNameTBX_Rec.BackColor = Color.White;
            FNameTBX_Rec.ForeColor = Color.Black;
        }

        private void LNameTBX_Rec_TextChanged(object sender, EventArgs e)
        {
            LNameTBX_Rec.BackColor = Color.White;
            LNameTBX_Rec.ForeColor = Color.Black;
        }

        private void EMTBX_Rec_TextChanged(object sender, EventArgs e)
        {
            EMTBX_Rec.BackColor = Color.White;
            EMTBX_Rec.ForeColor = Color.Black;
        }

        //this method check if input string contains numbers
        static bool numbers(string text)
        {
            foreach (char c in text)
            {
                if (c >= '0' && c <= '9')
                {
                    return true;
                }
            }
            return false;
        }

        private void PassTBX1_Rec_TextChanged(object sender, EventArgs e)
        {
            if (numbers(PassTBX1_Rec.Text) == true)
                passMatch = true;
            else
                passMatch = false;
            if (PassTBX1_Rec.Text.Length < 6)
                passLength = false;
            else
                passLength = true;

            PassTBX1_Rec.BackColor = Color.White;
            PassTBX1_Rec.ForeColor = Color.Black;
        }

        //need to add auto check if the password mathces
        private void PassTBX2_Rec_TextChanged(object sender, EventArgs e)
        {
            if (PassTBX2_Rec.Text != PassTBX1_Rec.Text)
            {
                PassTBX2_Rec.BackColor = Color.Red;
                PassTBX2_Rec.ForeColor = Color.White;

                passCorrect = false;
            }
            else
            {
                PassTBX2_Rec.BackColor = Color.White;
                PassTBX2_Rec.ForeColor = Color.Black;

                passCorrect = true;
            }
        }

        private void PassTBX1_Rec_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsLetter(e.KeyChar) && char.IsNumber(e.KeyChar))
            //{
            //    passMatch = true;
            //}
            //else if (e.KeyChar == 7F)
            //    e.Handled = true;

            //if (char.IsLetter(e.KeyChar) && char.IsNumber(e.KeyChar) || e.KeyChar == 7F)
            //{
            //    e.Handled = true;
            //}
            //else
            //    e.Handled = false;
        }
    }
}
