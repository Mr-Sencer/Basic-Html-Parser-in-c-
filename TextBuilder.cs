using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject
{
 public   class TextBuilder :IDisposable 

    {
        StringBuilder b=new StringBuilder(); 
        public TextBuilder()
        {
   
        }
        public TextBuilder(string text)
        {
            b.Append(text);
        }
        public int Capacity { get { return b.Capacity; } set { b.Capacity = value; } }
        public void Clear()
        {
            if(b.Length>0)
            {
 b.Clear();
            }
           
           
        }
        public int MaxCapacity
        {
          get  { return b.MaxCapacity; }
        }
        public string ToString()
        {
            return b.ToString();
        }
        public void AppendLine(string value)
        {

            b.AppendLine(value);
        }
        public void AppendLine()
        {
          
            b.AppendLine(); 
        
        }
        public void Replace(string oldvalue, string newvalue)
        {
            b.Replace(oldvalue, newvalue);
        }
        public void Replace(char oldchar,char newchar)
        {
            b.Replace(oldchar, newchar);
        }
        public void Remove(int startIndex,int lenght)
        {
            b.Remove(startIndex, lenght);
        }
        public int Length
        {
            get { return b.Length; }
        }
        public void Append(object o)
        {
            b.Append(o);
        }
        public void Append(string c)
        {
            b.Append(c);
        }
        public void Append(char c)
        {
            b.Append(c);
        }
        public void Dispose()
        {
           if(b.Length>0)
            {
                b.Clear();
            }
            GC.SuppressFinalize(b);
            GC.SuppressFinalize(this);
        }
    }
}
