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
    public partial class MessagesControl : UserControl
    {
        private static MessagesControl control;

        public static MessagesControl Instance
        {
            get
            {
                if (control == null)
                    control = new MessagesControl();
                return control;
            }
        }

        public MessagesControl()
        {
            InitializeComponent();
        }
    }
}
