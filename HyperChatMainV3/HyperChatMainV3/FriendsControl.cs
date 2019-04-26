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
    public partial class FriendsControl : UserControl
    {
        private static FriendsControl control;

        public static FriendsControl Instance
        {
            get
            {
                if (control == null)
                    control = new FriendsControl();
                return control;
            }
        }

        public FriendsControl()
        {
            InitializeComponent();
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
