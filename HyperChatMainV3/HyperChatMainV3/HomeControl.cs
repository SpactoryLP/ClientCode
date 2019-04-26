using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HyperChatMainV3
{
    public partial class HomeControl : UserControl
    {
        private static HomeControl control;

        public static HomeControl Instance
        {
            get
            {
                if (control == null)
                    control = new HomeControl();
                return control;
            }
        }

        bool HaveFriends = false;
        bool FirstIn = false;

        public HomeControl()
        {
            InitializeComponent();

            if(FirstIn == false)
            {
                //if (!MainPanel.Controls.Contains(FirstInHyperChat.Instance))
                //{
                //    MainPanel.Controls.Add(FirstInHyperChat.Instance);
                //    FirstInHyperChat.Instance.Dock = DockStyle.Fill;           //if the user just downloaded HyperChat he will get the "What is HyperChat"
                //    FirstInHyperChat.Instance.BringToFront();
                //    FirstInHyperChat.Instance.Show();
                //}
                //else
                //{
                //    FirstInHyperChat.Instance.BringToFront();
                //    FirstInHyperChat.Instance.Show();
                //}
            }
            else
            {
                MainPanel.Controls.Clear();
            }
        }

        private void SignInBTN_Click_1(object sender, EventArgs e)
        {
            
        }

        private void SignUpBTN_Click_1(object sender, EventArgs e)
        {
            HomeGroup.Visible = false;

            if (!MainPanel.Controls.Contains(SignUpControl.Instance))
            {
                MainPanel.Controls.Add(SignUpControl.Instance);
                SignUpControl.Instance.Dock = DockStyle.Fill;
                SignUpControl.Instance.BringToFront();
                SignUpControl.Instance.Show();
            }
            else
            {
                SignUpControl.Instance.BringToFront();
                SignUpControl.Instance.Show();
            }
        }
    }
}
