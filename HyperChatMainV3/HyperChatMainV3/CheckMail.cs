using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HyperChatMainV3
{
    public class CheckMail
    {
        public static bool checkForMail(String email)
        {
            bool IsVaild = false;
            Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (r.IsMatch(email))
                IsVaild = true;
            return IsVaild;
        }
    }
}
