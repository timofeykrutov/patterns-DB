using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAndText
{
    class Order
    {
        public int OrderID;
        public int User_ID;
        public string UserName;
        public string UserSurname;
        public string UserPhone;
        public DateTime Date;

        public bool openOrder()
        {
            return true;
        }
        public bool createOrder()
        {
            orderMapper ordM = new orderMapper();
            if (ordM.add(this))
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
