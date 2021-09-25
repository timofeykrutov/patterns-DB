using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAndText
{
    class Text
    {
        public int TextID;
        public int Order_ID;
        public string TextName;
        public string TextOwner;
        public int SizeOfText;
        public string Textt;

        public bool addText()
        {
            textMapper txtM = new textMapper();
            if (txtM.add(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  Text read()
        {
            textMapper txtM = new textMapper();
            if (txtM.read(this))
            {
                return this;
            }
            else
            {
                return this;
            }
        }
        public string ImgToStr(string filename)
        {
            MemoryStream Memostr = new MemoryStream();
            Image Img = Image.FromFile(filename);
            Img.Save(Memostr, Img.RawFormat);
            byte[] arrayimg = Memostr.ToArray();
            return Convert.ToBase64String(arrayimg);
        }
        public Image StrToImg(string StrImg)
        {
            byte[] arrayimg = Convert.FromBase64String(StrImg);
            Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
            return imageStr;
        }
    }
}
