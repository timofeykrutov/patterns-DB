using ImageAndText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_nmsp
{
    class Account
    {
        public string login;
        public string password;

        public Client openAccount(Account a)
        {
            Client cl = new Client();
            accountMapper_nmsp.accountMapper accM = new accountMapper_nmsp.accountMapper();

            cl  = accM.read(a);
            if (cl != null)
            {
                //Form3 form = new Form3(accM.read(a));
                //form.Show();
                return cl;
            }
            //return form ;
            else
            {
                return null;
            }
        }
        public bool registartion()
        {
            accountMapper_nmsp.accountMapper accM = new accountMapper_nmsp.accountMapper();
            if (accM.add(this))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
