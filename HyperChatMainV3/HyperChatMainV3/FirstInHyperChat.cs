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
    public partial class FirstInHyperChat : UserControl
    {
        private static FirstInHyperChat control;

        public static FirstInHyperChat Instance
        {
            get
            {
                if (control == null)
                    control = new FirstInHyperChat();
                return control;
            }
        }

        public FirstInHyperChat()
        {
            InitializeComponent();
        }
    }
}
