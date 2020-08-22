using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Html
{
    public class LexerParser
    {
        int index = 0;
    }
    public class MathParser
    {
        int left = 0;
        // 3+2+6 
        // 
        void go(int index,string value,ref int loc,ref int number)
        {
            StringBuilder b = new StringBuilder();
             for (int i=index+1;i<value.Length;i++)
            {
              if(value[i]=='+' || value[i]=='-' ||value[i]=='*' ||value[i]=='/' ||  i==value.Length-1)
                {
                    loc = i;
                    number = Convert.ToInt32( b.ToString());
                    break;
                }
                else
                {
                    b.Append(value[i]);
                }
            }
        }
        int right = 0;
    public    int number = 0;
        public void Match(string value)
        {
            parse(value);
        }
        void parse(string value)
        {
            StringBuilder b = new StringBuilder();
            int l = 0;
            for (int i=0;i<value.Length;i++)
            {
                if(value[i]=='+')
                {
                    left = Convert.ToInt32(b.ToString());

                    go(i, value, ref l, ref left);
                    number += left - right;
                    i = l;
                    continue; 

                }
                if (char.IsWhiteSpace(value[i])==false && (value[i]!='+' && value[i]!= '-' && value[i] != '*') && value[i] != '/')
                {
                    b.Append(value[i]);
                }
            }
        }
    }

    public   class HtmlParser
    {
        public List<HtmlTag> elements = new List<HtmlTag>();

        public void Parse(string html)
        {
           if(elements.Count>0)
            {
                elements.Clear();
            }
            TextProcess process = new TextProcess();
            HtmlTag element; 
        //(2+5+5)*5 +3
            for (int i = 0; i < html.Length; i++) 
            {
                
                if (html[i]=='<')
                {
                    element=new HtmlTag(html,i,null);
                    if(element.TagName.Contains("/")==false)
                    {
   elements.Add(element);
                    i = elements[elements.Count-1].location ;

                        continue;
                    }
                    else
                    {

                    }
                  
                }

            }
        }
    }
}
