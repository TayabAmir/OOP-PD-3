using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApp
{
    internal class Sign
    {
        public Sign(string mName, string mPassword, string mRole, string mAccount)
        {
            name = mName;
            password = mPassword;
            role = mRole;
            accountNo = mAccount;
        }
        public string name;
        public string password;
        public string role;
        public string accountNo;

        public void StoreUserInfo()
        {
            StreamWriter file = new StreamWriter("Users.txt", true);
            file.WriteLine($"{name},{password},{role},{accountNo}");
            file.Close();
        }
    }
}
