using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace DragDropTransfare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Xx;
        int Yy;

        int Xg;
        int Yg;

        const int FTPort = 6868; //File transfer server port
        string serverIP = "localhost";

        private void Form1_Load(object sender, EventArgs e)
        {
            MainPanel.AllowDrop = true;
        }

        private void MainPanel_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    String selected_file = fileNames[0];
                    String file_name = Path.GetFileName(selected_file);

                    FileStream fs = new FileStream(selected_file, FileMode.Open);

                    TcpClient tc = new TcpClient(serverIP, FTPort);
                    NetworkStream ns = tc.GetStream();
                    byte[] data_tosend = CreateDataPacket(Encoding.UTF8.GetBytes("125"), Encoding.UTF8.GetBytes(file_name));
                    ns.Write(data_tosend, 0, data_tosend.Length);
                    ns.Flush();
                    Boolean loop_break = false;

                    //SendExtension();

                    while (true)
                    {
                        if (ns.ReadByte() == 2)
                        {
                            byte[] cmd_buff = new byte[3];
                            ns.Read(cmd_buff, 0, cmd_buff.Length);
                            byte[] recv_data = ReadStream(ns);

                            switch (Convert.ToInt32(Encoding.UTF8.GetString(cmd_buff)))
                            {
                                case 126:
                                    long recv_file_pointer = long.Parse(Encoding.UTF8.GetString(recv_data));
                                    if (recv_file_pointer != fs.Length)
                                    {
                                        //int SendProcess = (int)Math.Ceiling((double)recv_file_pointer / (double)fs.Length * 100);
                                        //CreateSendProps(fileNames[0], SendProcess);

                                        fs.Seek(recv_file_pointer, SeekOrigin.Begin);
                                        int temp_buff_length = (int)(fs.Length - recv_file_pointer < 20000 ? fs.Length - recv_file_pointer : 20000);
                                        byte[] temp_buff = new byte[temp_buff_length];
                                        fs.Read(temp_buff, 0, temp_buff.Length);
                                        byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("127"), temp_buff);
                                        ns.Write(data_to_send, 0, data_to_send.Length);
                                        ns.Flush();

                                        int SendProcess = (int)Math.Ceiling((double)recv_file_pointer / (double)fs.Length * 100);
                                        CreateSendProps(fileNames[0], SendProcess);
                                    }
                                    else
                                    {
                                        byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("128"), Encoding.UTF8.GetBytes("Close"));
                                        ns.Write(data_to_send, 0, data_to_send.Length);
                                        ns.Flush();
                                        fs.Close();
                                        loop_break = true;
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                        if (loop_break == true)
                        {
                            ns.Close();
                            break;
                        }
                    }
                }

            }
        }

        private void MainPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        public byte[] ReadStream(NetworkStream ns)
        {
            byte[] data_buff = null;

            int b = 0;
            String buff_length = "";
            while ((b = ns.ReadByte()) != 4)
            {
                buff_length += (char)b;
            }
            int data_length = Convert.ToInt32(buff_length);
            data_buff = new byte[data_length];
            int byte_read = 0;
            int byte_offset = 0;
            while (byte_offset < data_length)
            {
                byte_read = ns.Read(data_buff, byte_offset, data_length - byte_offset);
                byte_offset += byte_read;
            }
            return data_buff;
        }

        private byte[] CreateDataPacket(byte[] cmd, byte[] data)
        {
            byte[] initialize = new byte[1];
            initialize[0] = 2;
            byte[] separator = new byte[1];
            separator[0] = 4;
            byte[] datalength = Encoding.UTF8.GetBytes(Convert.ToString(data.Length));
            MemoryStream ms = new MemoryStream();
            ms.Write(initialize, 0, initialize.Length);
            ms.Write(cmd, 0, cmd.Length);
            ms.Write(datalength, 0, datalength.Length);
            ms.Write(separator, 0, separator.Length);
            ms.Write(data, 0, data.Length);
            return ms.ToArray();
        }

        void CreateSendProps(string name, int process)
        {
            Graphics g = MainPanel.CreateGraphics();
            Pen myPen = new Pen(Color.Black, 3);
            g.DrawRectangle(myPen, 800, 100, 200, 100);

            label(name);
            Circular(process);
        }

        CircularProgressBar.CircularProgressBar Circular(int value)
        {
            CircularProgressBar.CircularProgressBar pbUpload = new CircularProgressBar.CircularProgressBar();
            MainPanel.Controls.Add(pbUpload);
            pbUpload.Width = 75;
            pbUpload.Height = 60;
            pbUpload.Top = 135;
            pbUpload.Left = 806;
            pbUpload.Minimum = 0;
            pbUpload.Maximum = 100;

            //pbUpload.Value = value; //the value of the transfare process
            //pbUpload.Update();

            for (int i = 0; i < value; i++)
            {
                Thread.Sleep(5);
                pbUpload.Value = i;
                pbUpload.Update();
            }

            return pbUpload;
        }

        System.Windows.Forms.Label label(string FinalName)
        {
            System.Windows.Forms.Label tbName = new System.Windows.Forms.Label();
            MainPanel.Controls.Add(tbName);
            tbName.Top = 110;
            tbName.Left = 806;
            string name = Path.GetFileName(FinalName);
            tbName.Text = name;
            var panelColor = MainPanel.BackColor;
            tbName.BackColor = panelColor;
            tbName.BorderStyle = BorderStyle.None;

            return tbName;
        }

        //System.Windows.Forms.PictureBox()

        //bool mouseDown = false;

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //Xg = e.X;
            //Yg = e.Y;

            //mouseDown = true;
        }

        private void MainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //mouseDown = false;
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Xx = e.X;
            Yy = e.Y;

            XLBL.Text = "X= " + Xx.ToString();
            YLBL.Text = "Y= " + Yy.ToString();

            //if (mouseDown == true)
            //{
            //    Graphics g = MainPanel.CreateGraphics();
            //    Pen myPen = new Pen(Color.Black, 5);

            //    g.DrawLine(myPen, new Point(Xg, Yg), e.Location);
            //    Xg = e.X;
            //    Yg = e.Y;
            //}
        }
    }
}
