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
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace HyperChatMainV3
{
    public partial class FileTransferControl : UserControl
    {
        private static FileTransferControl control;

        public static FileTransferControl Instance
        {
            get
            {
                if (control == null)
                    control = new FileTransferControl();
                return control;
            }
        }

        bool selectedFile = false;
        bool selectedDir = false;

        OpenFileDialog ofd = new OpenFileDialog();

        const int FTPort = 6868; //File transfer server port
        string serverIP = "localhost";

        private const string ProgramSystemDirectory = @"C:\MYprogramFiles\HyperChat\"; //need to change the location to progam files Very Important!!!

        private string currentFile;
        private string currentDir;

        public FileTransferControl()
        {
            InitializeComponent();
            pb_upload.Visible = false;
            pb_upload.Minimum = 0;
        }

        FolderBrowserDialog fbd = new FolderBrowserDialog();

        //select directory
        private void SelectDBTN_Click(object sender, EventArgs e)
        {
            fbd.Description = "Select a folder";

            if (fbd.ShowDialog() == DialogResult.OK)
                selectedDir = true;
            else
                selectedDir = false;
        }

        //zip the selected directory
        private static void ZipDirectory(string dir)
        {
            string parent = Path.GetDirectoryName(dir);
            Process.Start(parent);
            string name = Path.GetFileName(dir);
            //string fileName = Path.Combine(parent, name + ".zip"); THE ORIGINAL LINE OF CODE (if there is going to be errors)
            string fileName = Path.Combine(ProgramSystemDirectory, name + ".zip");
            ZipFile.CreateFromDirectory(dir, fileName, CompressionLevel.Fastest, true); //need to check if the zip already exists
        }

        //select a file
        private void SelectFBTN_Click_1(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
                selectedFile = true;
            else
                selectedFile = false;
        }

        //reset the progress bar
        private async void FileSent(string Mes)
        {
            await Task.Delay(2500);
            SendLBL.Text = Mes;
            await Task.Delay(2500);
            pb_upload.Visible = false;
            pb_upload.Value = 0;
            SendLBL.Text = "";

        }

        //main delay function
        private async void MainDelay(int time)
        {
            await Task.Delay(time);
        }

        //Send the file
        private void SendBTN_Click_1(object sender, EventArgs e)
        {
            if (selectedFile == true && selectedDir == false)
            {
                SendLBL.Text = "Sending...";
                String selected_file = ofd.FileName;
                String file_name = Path.GetFileName(selected_file);

                currentFile = Path.GetFileName(selected_file); //remeber the last selected file

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
                        ErrorLBL.Text = "";

                        byte[] cmd_buff = new byte[3];
                        ns.Read(cmd_buff, 0, cmd_buff.Length);
                        byte[] recv_data = ReadStream(ns);

                        switch (Convert.ToInt32(Encoding.UTF8.GetString(cmd_buff)))
                        {
                            case 126:
                                long recv_file_pointer = long.Parse(Encoding.UTF8.GetString(recv_data));
                                if (recv_file_pointer != fs.Length)
                                {
                                    fs.Seek(recv_file_pointer, SeekOrigin.Begin);
                                    int temp_buff_length = (int)(fs.Length - recv_file_pointer < 20000 ? fs.Length - recv_file_pointer : 20000);
                                    byte[] temp_buff = new byte[temp_buff_length];
                                    fs.Read(temp_buff, 0, temp_buff.Length);
                                    byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("127"), temp_buff);
                                    ns.Write(data_to_send, 0, data_to_send.Length);
                                    ns.Flush();
                                    pb_upload.Visible = true;
                                    pb_upload.Value = (int)Math.Ceiling((double)recv_file_pointer / (double)fs.Length * 100);

                                    FileSent("File sent!");
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

                currentFile = ""; //actually useless but maybe late gonna be more usefull
            }
            
            //zip and send directory
            else if(selectedDir == true && selectedFile == false)
            {
                ZipDirectory(fbd.SelectedPath);

                MainDelay(3000);

                currentDir = Path.GetFileName(fbd.SelectedPath);

                SendLBL.Text = "Sending...";

                String selected_file = ProgramSystemDirectory + currentDir.ToString() + ".zip";

                String file_name = Path.GetFileName(currentDir) + ".zip";

                FileStream fs = new FileStream(selected_file, FileMode.Open);

                TcpClient tc = new TcpClient(serverIP, FTPort);
                NetworkStream ns = tc.GetStream();
                byte[] data_tosend = CreateDataPacket(Encoding.UTF8.GetBytes("125"), Encoding.UTF8.GetBytes(file_name));
                ns.Write(data_tosend, 0, data_tosend.Length);
                ns.Flush();
                Boolean loop_break = false;

                while (true)
                {
                    if (ns.ReadByte() == 2)
                    {
                        ErrorLBL.Text = "";

                        byte[] cmd_buff = new byte[3];
                        ns.Read(cmd_buff, 0, cmd_buff.Length);
                        byte[] recv_data = ReadStream(ns);

                        switch (Convert.ToInt32(Encoding.UTF8.GetString(cmd_buff)))
                        {
                            case 126:
                                long recv_file_pointer = long.Parse(Encoding.UTF8.GetString(recv_data));
                                if (recv_file_pointer != fs.Length)
                                {
                                    fs.Seek(recv_file_pointer, SeekOrigin.Begin);
                                    int temp_buff_length = (int)(fs.Length - recv_file_pointer < 20000 ? fs.Length - recv_file_pointer : 20000);
                                    byte[] temp_buff = new byte[temp_buff_length];
                                    fs.Read(temp_buff, 0, temp_buff.Length);
                                    byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("127"), temp_buff);
                                    ns.Write(data_to_send, 0, data_to_send.Length);
                                    ns.Flush();
                                    pb_upload.Visible = true;
                                    pb_upload.Value = (int)Math.Ceiling((double)recv_file_pointer / (double)fs.Length * 100);

                                    FileSent("Directory sent!");
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

                File.Delete(ProgramSystemDirectory + currentDir.ToString() + ".zip");

                currentDir = "";
            }

            else
            {
                selectedFile = false;
                selectedDir = false;
                ErrorLBL.Text = "Please select file or directory!";
            }
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
    }
}
