using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HyperChatMainV3
{
    public partial class Form1 : Form
    {
        string currentControl;
        private bool SignedIn = false; //if the client signed in or signed up this bool will equals to true

        private const string ProgramSystemDirectory = @"C:\MYprogramFiles\HyperChat\";

        public Form1()
        {
            InitializeComponent();

            BackBTN.Visible = false;

            if (!MainPanel.Controls.Contains(HomeControl.Instance))
            {
                MainPanel.Controls.Add(HomeControl.Instance);
                HomeControl.Instance.Dock = DockStyle.Fill;
                HomeControl.Instance.BringToFront();
                HomeControl.Instance.Show();
                currentControl = "Home";
            }
            else
            {
                HomeControl.Instance.BringToFront();
                HomeControl.Instance.Show();
                currentControl = "Home";
            }

            if (!Directory.Exists(ProgramSystemDirectory))
            {
                Directory.CreateDirectory(ProgramSystemDirectory);
            }

            //check if the user signed in if not display the "what is HyperChat"

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        //Return to home screen
        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!MainPanel.Controls.Contains(HomeControl.Instance))
            {
                MainPanel.Controls.Add(HomeControl.Instance);
                HomeControl.Instance.Dock = DockStyle.Fill;
                HomeControl.Instance.BringToFront();
                HomeControl.Instance.Show();
                currentControl = "Home";
                BackBTN.Visible = false;
            }
            else
            {
                HomeControl.Instance.BringToFront();
                HomeControl.Instance.Show();
                currentControl = "Home";
                BackBTN.Visible = false;
            }
        }

        //Go to file transfer control
        private void fileTransferToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BackBTN.Visible = true;
            if (!MainPanel.Controls.Contains(FileTransferControl.Instance))
            {
                MainPanel.Controls.Add(FileTransferControl.Instance);
                FileTransferControl.Instance.Dock = DockStyle.Fill;
                FileTransferControl.Instance.BringToFront();
                FileTransferControl.Instance.Show();
                currentControl = "FileTransfer";
            }
            else
            {
                FileTransferControl.Instance.BringToFront();
                FileTransferControl.Instance.Show();
                currentControl = "FileTransfer";
            }
        }

        //open about us window
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs about = new AboutUs();
            about.Show();
        }

        private void friendsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackBTN.Visible = true;
            if (!MainPanel.Controls.Contains(FriendsControl.Instance))
            {
                MainPanel.Controls.Add(FriendsControl.Instance);
                FriendsControl.Instance.Dock = DockStyle.Fill;
                FriendsControl.Instance.BringToFront();
                FriendsControl.Instance.Show();
                currentControl = "FileTransfer";
            }
            else
            {
                FriendsControl.Instance.BringToFront();
                FriendsControl.Instance.Show();
                currentControl = "FileTransfer";
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackBTN.Visible = true;
            if (!MainPanel.Controls.Contains(SettingsControl.Instance))
            {
                MainPanel.Controls.Add(SettingsControl.Instance);
                SettingsControl.Instance.Dock = DockStyle.Fill;
                SettingsControl.Instance.BringToFront();
                SettingsControl.Instance.Show();
                currentControl = "Settings";
            }
            else
            {
                SettingsControl.Instance.BringToFront();
                SettingsControl.Instance.Show();
                currentControl = "Settings";
            }
        }

        private void BackBTN_Click_1(object sender, EventArgs e)
        {
            switch (currentControl)
            {
                case "Home":
                    {
                        BackBTN.Visible = false;
                    }
                    break;

                case "FileTransfer":
                    {
                        if (!MainPanel.Controls.Contains(HomeControl.Instance))
                        {
                            MainPanel.Controls.Add(HomeControl.Instance);
                            HomeControl.Instance.Dock = DockStyle.Fill;
                            HomeControl.Instance.BringToFront();
                            HomeControl.Instance.Show();
                            currentControl = "Home";
                        }
                        else
                        {
                            HomeControl.Instance.BringToFront();
                            HomeControl.Instance.Show();
                            currentControl = "Home";
                        }

                        BackBTN.Visible = false;
                    }
                    break;

                case "Friends":
                    {
                        if (!MainPanel.Controls.Contains(HomeControl.Instance))
                        {
                            MainPanel.Controls.Add(HomeControl.Instance);
                            HomeControl.Instance.Dock = DockStyle.Fill;
                            HomeControl.Instance.BringToFront();
                            HomeControl.Instance.Show();
                            currentControl = "Home";
                        }
                        else
                        {
                            HomeControl.Instance.BringToFront();
                            HomeControl.Instance.Show();
                            currentControl = "Home";
                        }

                        BackBTN.Visible = false;
                    }
                    break;

                case "Settings":
                    {
                        if (!MainPanel.Controls.Contains(HomeControl.Instance))
                        {
                            MainPanel.Controls.Add(HomeControl.Instance);
                            HomeControl.Instance.Dock = DockStyle.Fill;
                            HomeControl.Instance.BringToFront();
                            HomeControl.Instance.Show();
                            currentControl = "Home";
                        }
                        else
                        {
                            HomeControl.Instance.BringToFront();
                            HomeControl.Instance.Show();
                            currentControl = "Home";
                        }

                        BackBTN.Visible = false;
                    }
                    break;

                case "RegularMes":
                    {
                        if (!MainPanel.Controls.Contains(HomeControl.Instance))
                        {
                            MainPanel.Controls.Add(HomeControl.Instance);
                            HomeControl.Instance.Dock = DockStyle.Fill;
                            HomeControl.Instance.BringToFront();
                            HomeControl.Instance.Show();
                            currentControl = "Home";
                        }
                        else
                        {
                            HomeControl.Instance.BringToFront();
                            HomeControl.Instance.Show();
                            currentControl = "Home";
                        }

                        BackBTN.Visible = false;
                    }
                    break;

                //Need to add more when i will add new controls

                default:
                    {
                        BackBTN.Visible = false;
                    }
                    break;

            }
        }
    }
}
