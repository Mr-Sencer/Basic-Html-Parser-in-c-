using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Html
{
   public  class HtmlTag:IDisposable
    {
        bool PropertiesParsed = false;
       
    
        public HtmlTag(string html, int location, HtmlTag tag)
        {
            using (TextProcess proc = new TextProcess())
            {
                StringBuilder b = new StringBuilder();
                int index = 0;
                for (int i = location + 1; i < html.Length; i++)
                {
                    if (html[i] == '>')
                    {
                        index = i;
                        if(PropertiesParsed==false)
                        {
                            TagName = b.ToString();
                            PropertiesParsed = true;
                        break;
                        }
                         

                    }
                  
                    if (char.IsWhiteSpace(html[i]) == true)
                    {
                        index = i;
                        TagName = b.ToString();
                        break;
                    }
                    if (html[i] != '>' && char.IsWhiteSpace(html[i]) != true)
                    {
                        b.Append(html[i]);
                    }

                }
                TagName = b.ToString();
                if (PropertiesParsed == false)
                {
                    parseProperties(html, proc, index);



                    PropertiesParsed = true;
                }

                Parse(html, index);


            }
        
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public string TagName;
        public string ID;
        public Dictionary<string, string> properties = new Dictionary<string, string>();
        public List<HtmlTag> tags = new List<HtmlTag>();
        public int location=0;
        void parseProperties(string html, TextProcess proc, int loc)
        {
            StringBuilder builder = new StringBuilder();
            int end = 0;
            string propertyValue = "";
            string propertyName = "";
            int mode = 0;

            for (int i = loc ; i < html.Length; i++)
            {
               
                if (html[i] == '"' || html[i] == WebProject.Properties.Settings.Default.Ayar)
                {
                    end = html.IndexOf(html[i], i + 1) ;
                    propertyValue = proc.Cut(html, i + 1, end - 1);

                    i = end ;
                    if (properties.ContainsKey(propertyName) == false)
                    {
                        properties.Add(propertyName,propertyValue);
                        builder.Clear();

                    }
                    continue;

                }
                if (html[i] == '>')
                {
                    location = i;

                    break;
                }
                if (html[i] == '=')
                {
                    if (mode == 0)
                    {
                        propertyName = builder.ToString();
                        builder.Clear();

                        mode = 1;
                        continue;
                      
                    }
                }
                if (mode == 1 && char.IsWhiteSpace(html[i]) == true)
                {
                    if(properties.ContainsKey(propertyName)==false)
                    {
properties.Add(propertyName, builder.ToString());
                    builder.Clear();
                   
                    }
                     mode = 0;
                }
                if (mode == 0)
                {
                    if (char.IsWhiteSpace(html[i]) == false)
                    {
                        builder.Append(html[i]);
                    }
                }
                else
                {
                    builder.Append(html[i]);
                }
               
            }
        }
        public bool TagClosed = false;
        public void Parse(string html, int location)
        {
            TextProcess proc = new TextProcess();
            parseProperties(html, proc, location);
            int end = 0;
            for (int i =this. location+1 ; i < html.Length; i++)
            {
                if (html[i] == '<')
                {
                    if(html[i+1]=='/')
                    {
                        end = html.IndexOf('>', i + 1);
                        string name=   proc.Cut(html,i+2,     end-1);
                        if(TagName==name)
                        {
                            TagClosed = true;

                            location = end;
                           
                            break;
                        }
                    }
                    else
                    {

                        tags.Add(new HtmlTag(html, i,this));
                     i=   tags[tags.Count - 1].location;
                        continue;
                    }
                   

                }
               
               
            }
        }
       
    }
}
