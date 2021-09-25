using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clientMapper_nmsp;
namespace ImageAndText
{
    public class Client
    {
        public int UserID;
        public string Name;
        public string Surname;
        public string PhoneNumber;
        public string email;
        public string User_login;

        public bool insertNewClient()
        {
            clientMapper clM = new clientMapper();
            if (clM.add(this))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public Client openAccount()
        {
            clientMapper clM = new clientMapper();
            
            if(clM.read(this)!=null)
            {
                return this;
            }
            else
            {
                return null;
            }
        }
        public bool updateInformation()
        {
            clientMapper clM = new clientMapper();
            if (clM.update(this))
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
