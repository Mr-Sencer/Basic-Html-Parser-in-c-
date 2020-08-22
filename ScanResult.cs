using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject
{
   public struct ScanResult:IDisposable
    {
        public int index;
        public char ch;
        public bool IsFind;
        public string _text;
        int start;
        public ScanResult(string text,int startIndex,List<char> chars)
        {
            index = 0;
            ch = 'n';
            IsFind = false;
            _text = text;
            start = startIndex;
            Scan(chars);

        }

        public void Dispose()
        {
            _text = string.Empty;
            GC.SuppressFinalize(start);
            GC.SuppressFinalize(index);
            GC.SuppressFinalize(IsFind);
            GC.SuppressFinalize(ch);
            GC.SuppressFinalize(_text);
            GC.SuppressFinalize(this);
        }

        public void Scan(List<char> chrs)
        {
            for(int i=start;i<_text.Length;i++)
            {
                  if(chrs.Contains( _text[i])==true)
                    {
                    ch = _text[i];
                    index = i;
                    IsFind = true;
                    break;
                }
            }
        }
    }
}
