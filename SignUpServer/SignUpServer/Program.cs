using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SignUpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 1111);
            TcpClient client = default(TcpClient);

            try
            {
                TCPfile obj_server = new TCPfile();
                System.Threading.Thread obj_thread = new System.Threading.Thread(obj_server.StartServer);
                obj_thread.Start();

                server.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }

            while (true)
            {
                client = server.AcceptTcpClient();
                byte[] receivedBuffer = new byte[889911];
                NetworkStream stream = client.GetStream();

                stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                Char[] chars = {' '};

                string Fname;
                string Lname;
                string Email;
                string Pass;
                string ID;
                string IP;

                //! = first name
                //@ = last name
                //# = Email
                //$ = Pass

                StringBuilder msg = new StringBuilder();

                foreach (byte b in receivedBuffer)
                {
                    if (b.Equals(00)) //or 59
                    {
                        break;
                    }
                    else
                    {
                        msg.Append(Convert.ToChar(b).ToString());
                    }
                }

                string[] names = msg.ToString().Split(chars);

                foreach (string x in names)
                {
                    //Console.WriteLine(x);

                    if (x.StartsWith("!") && x.EndsWith("!"))
                    {
                        Fname = x.Substring(1, x.Length -2);

                        //To check
                        Console.WriteLine(Fname);
                    }
                    else if (x.StartsWith("@") && x.EndsWith("@"))
                    {
                        Lname = x.Substring(1, x.Length -2);

                        //To check
                        Console.WriteLine(Lname);
                    }
                    else if (x.StartsWith("#") && x.EndsWith("#"))
                    {
                        Email = x.Substring(1, x.Length - 2);

                        //To check
                        Console.WriteLine(Email);
                    }
                    else if (x.StartsWith("$") && x.EndsWith("$"))
                    {
                        Pass = x.Substring(1, x.Length - 2);

                        //To check
                        Console.WriteLine(Pass);
                    }
                    else if (x.StartsWith("%") && x.EndsWith("%"))
                    {
                        ID = x.Substring(1, x.Length - 2);

                        //To check
                        Console.WriteLine(ID);
                    }
                    else if (x.StartsWith("^") && x.EndsWith("^"))
                    {
                        IP = x.Substring(1, x.Length - 2);

                        //To check

                        //Console.WriteLine(IP); //I DONT WANT ANYBODY TO KNOW MY IP ADDRESS
                    }
                }

                //Console.WriteLine(msg.ToString() + "     " + "bytes: " + msg.Length);
            }
        }

        const int RegPort = 1122;

        class TCPfile //maybe need to remove the "class" at TCPfile an Sockethandler
        {
            TcpListener obj_server;
            public TCPfile()
            {
                obj_server = new TcpListener(IPAddress.Any, RegPort);
            }

            public void StartServer()
            {
                obj_server.Start();
                while (true)
                {
                    TcpClient tc = obj_server.AcceptTcpClient();
                    SocketHandler obj_handler = new SocketHandler(tc);
                    System.Threading.Thread obj_thread = new System.Threading.Thread(obj_handler.ProcessSocketRequest);
                    obj_thread.Start();
                }
            }

            class SocketHandler
            {
                NetworkStream ns;

                public SocketHandler(TcpClient tc)
                {
                    ns = tc.GetStream();
                }

                public void ProcessSocketRequest()
                {
                    FileStream fs = null;
                    long current_file_pointer = 0;
                    Boolean loop_break = false;

                    while (true)
                    {
                        if (ns.ReadByte() == 2)
                        {
                            byte[] cmd_buff = new byte[3];
                            ns.Read(cmd_buff, 0, cmd_buff.Length);
                            byte[] recv_data = ReadStream();

                            switch (Convert.ToInt32(Encoding.UTF8.GetString(cmd_buff)))
                            {
                                case 125:
                                    {
                                        fs = new FileStream(@"C:\HyperChatFiles\" + Encoding.UTF8.GetString(recv_data), FileMode.CreateNew);
                                        byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("126"), Encoding.UTF8.GetBytes(Convert.ToString(current_file_pointer)));
                                        ns.Write(data_to_send, 0, data_to_send.Length);
                                        ns.Flush();
                                    }

                                    break;

                                case 127:
                                    {
                                        fs.Seek(current_file_pointer, SeekOrigin.Begin);
                                        fs.Write(recv_data, 0, recv_data.Length);
                                        current_file_pointer = fs.Position;
                                        byte[] data_to_send = CreateDataPacket(Encoding.UTF8.GetBytes("126"), Encoding.UTF8.GetBytes(Convert.ToString(current_file_pointer)));
                                        ns.Write(data_to_send, 0, data_to_send.Length);
                                        ns.Flush(); //After here
                                    }
                                    break;

                                case 128:
                                    {
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

                public byte[] ReadStream()
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
    }
}
