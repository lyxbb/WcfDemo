using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteEventDemo
{
    public class people
    {
        public  delegate void delGreate(string msg,string opera);
        public event delGreate eGreate;
        public void Greate(string msg,string opera)
        {
            if(eGreate!=null)
            {
               eGreate(msg,opera);
            }
        }
    }

    public class englishPeople
    {
        people pe;
        public englishPeople(people p)
        {
            pe = p;
            pe.eGreate += GreateEng;
        }

        public void GreateEng(string msg, string opera)
        {
            if(opera.Contains("english"))
            {
                Console.WriteLine("英语问候：" + msg);
            }

        }
    }

    public class chinaPeople
    {

        people pe;
        public chinaPeople(people p)
        {
            pe = p;
            pe.eGreate += GreateChina;
        }
        public void GreateChina(string msg,string opera)
        {
            if(opera.Contains("china"))
            {
                Console.WriteLine("汉语问候：" + msg);
            }
        }
    }
}
