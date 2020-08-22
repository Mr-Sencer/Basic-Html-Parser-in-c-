using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Html
{
   

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
