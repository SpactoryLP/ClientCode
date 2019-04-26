using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace HyperChatMainV3
{
    public class newUser
    {
        const int RegPort = 1111; //SignUp / SignIn port
        const string ServerIp = "localhost";

        string FName;
        string LName;
        string Email;
        string Pass;

        byte[] sendData;

        List<int> IDs = new List<int>();

        Dictionary<int, string> IPtoID = new Dictionary<int, string>();

        private int ID;

        public string FinalID;
        public string FinalIP;

        private string currentFile;

        public bool IconSelected = false;

        TcpClient client = new TcpClient(ServerIp, RegPort);

        public newUser(string fname, string lname, string email, string pass)
        {
            FName = fname;
            LName = lname;
            Email = email;
            Pass = pass;
        }

        //Convert IP to ID
        public void GetIpAndId()
        {
            //Get IP address
            IPHostEntry host;
            string localIp = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIp = ip.ToString();
                }
            }

            //Get random ID
            Random random = new Random();

            ID = random.Next();

            //Check if ID is exists
            if (IDs.Contains(ID))
                ID = random.Next();
            else
                IDs.Add(ID);//Add user's IP to list

            IPtoID.Add(ID, localIp);
        }

        //Create the IPtoID pair function
        public void Pair() //Need to access this function inside the newUser class or use it in another function and then use the FinalID string and send it to server
        {
            foreach (KeyValuePair<int, string> keyValue in IPtoID)
            {
                FinalID = keyValue.Key.ToString();
                FinalIP = keyValue.Value.ToString();
            }
        }

        public void FinalSend(bool selected, string imgPath)
        {
            if (selected == true)
            {
                int byteCount = Encoding.ASCII.GetByteCount("!" + FName + "!" + " " + "@" + LName + "@" + " " + "#" + Email +
                                                            "#" + " " + "$" + Pass + "$" + " " + "%" + FinalID + "%" + " " + "^" + FinalIP + "^");

                sendData = new byte[byteCount];

                sendData = Encoding.ASCII.GetBytes("!" + FName + "!" + " " + "@" + LName + "@" + " " + "#" + Email +
                            
                                                   "#" + " " + "$" + Pass + "$" + " " + "%" + FinalID + "%" + " " + "^" + FinalIP + "^");

                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);

                //until this line i sent the fname, lname, exr' but i need to send the nickname too

                SendIcon(imgPath);
            }
            else if (selected == false && imgPath == "")
            {
                int byteCount = Encoding.ASCII.GetByteCount("!" + FName + "!" + " " + "@" + LName + "@" + " " + "#" + Email +
                                                            "#" + " " + "$" + Pass + "$" + " " + "%" + FinalID + "%" + " " + "^" + FinalIP + "^");

                sendData = new byte[byteCount];

                sendData = Encoding.ASCII.GetBytes("!" + FName + "!" + " " + "@" + LName + "@" + " " + "#" + Email +
                                                   "#" + " " + "$" + Pass + "$" + " " + "%" + FinalID + "%" + " " + "^" + FinalIP + "^");

                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);

                //until this line i sent the fname, lname, exr' but i need to send the nickname too

                SendIcon(@"C:\Users\nirle\source\repos\HyperChatMainV3\HyperChatMainV3\Resources\DefaultProfile.png");
            }
        }

        //public void SendProps()
        //{
        //    int byteCount = Encoding.ASCII.GetByteCount("!" + FName + "!" + " " + "@" + LName + "@" + " " + "#" + Email +
        //        "#" + " " + "$" + Pass + "$" + " " + "%" + FinalID + "%" + " " + "^" + FinalIP + "^");

        //    sendData = new byte[byteCount];

        //    sendData = Encoding.ASCII.GetBytes("!" + FName + "!" + " " + "@" + LName + "@" + " " + "#" + Email +
        //        "#" + " " + "$" + Pass + "$" + " " + "%" + FinalID + "%" + " " + "^" + FinalIP + "^");

        //    NetworkStream stream = client.GetStream();
        //    stream.Write(sendData, 0, sendData.Length);
        //}

        //Send user's profile icon
        void SendIcon(string _ImgName)
        {
            String selected_file = _ImgName;
            String file_name = Path.GetFileName(selected_file);

            currentFile = Path.GetFileName(selected_file); //remember the last selected file

            FileStream fs = new FileStream(selected_file, FileMode.Open);

            int FTPort = 1122;
            string serverIP = "localhost";

            TcpClient tc = new TcpClient(serverIP, FTPort);

            NetworkStream ns = tc.GetStream();
            byte[] data_tosend = CreateDataPacket(Encoding.UTF8.GetBytes("125"), Encoding.UTF8.GetBytes(file_name));
            ns.Write(data_tosend, 0, data_tosend.Length);
            ns.Flush();
            Boolean loop_break = false;

            //SendExtension(); //Lately need to select what file the user don't want to receive from others

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
                                fs.Seek(recv_file_pointer, SeekOrigin.Begin);
                                int temp_buff_length = (int)(fs.Length - recv_file_pointer < 20000 ? fs.Length - recv_file_pointer : 20000);
                                byte[] temp_buff = new byte[temp_buff_length];
                                fs.Read(temp_buff, 0, temp_buff.Length);
                                byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("127"), temp_buff);
                                ns.Write(data_to_send, 0, data_to_send.Length);
                                ns.Flush();
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

        byte[] ReadStream(NetworkStream ns)
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

        byte[] CreateDataPacket(byte[] cmd, byte[] data)
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
