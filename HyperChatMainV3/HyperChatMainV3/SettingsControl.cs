using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace HyperChatMainV3
{
    public partial class SettingsControl : UserControl
    {
        private static SettingsControl control;

        public static SettingsControl Instance
        {
            get
            {
                if (control == null)
                    control = new SettingsControl();
                return control;
            }
        }

        string TypedFormat = ""; //default

        const int FormatsPort = 2828;
        byte[] sendData;
        const string serverIP = "localhost";

        public SettingsControl()
        {
            InitializeComponent();
        }

        private void ApplyBTN_Click(object sender, EventArgs e)
        {
            if(FormatsTBX.Text != "")
            {
                if (FormatsTBX.Text.StartsWith("."))
                {
                    TypedFormat = FormatsTBX.Text;
                    ErrorLBL.Text = "OK!";

                    TcpClient client = new TcpClient(serverIP, FormatsPort);
                    NetworkStream stream = client.GetStream();

                    int byteCount = Encoding.ASCII.GetByteCount(TypedFormat);

                    sendData = new byte[byteCount];

                    sendData = Encoding.ASCII.GetBytes(TypedFormat);

                    stream.Write(sendData, 0, sendData.Length);

                    stream.Close();
                    client.Close();
                }
                else
                    ErrorLBL.Text = "The text you just typed isn't a format!";
            }
            else { } //the client can receive all the file formats
        }

        private void SettingsControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}
