
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebProject.Css;

namespace WebProject
{
    public struct IndexInfo:IDisposable
    {
        public int location;
        public bool ProcessCompleted;
        public string value;
        public IndexInfo(int Location,string val,bool completed)
        {
            location = Location;
            ProcessCompleted = completed;
            value = val;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(location);
            GC.SuppressFinalize(ProcessCompleted);
            GC.SuppressFinalize(value);
            GC.SuppressFinalize(this);
        }
    }
    public  class TextProcess:IDisposable
    {
        public  string Cut(string value, int startIndex, int endIndex)
        {
            using (TextBuilder b = new TextBuilder())
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    try
                    {
                        b.Append(value[i]);
                    }
                    catch
                    {
                        break;
                    }
                }
                return b.ToString();
            }
        }
   
        public  string Cut(string value, int startIndex, char endChar, bool WriteEndChar)
        {
            using (TextBuilder b = new TextBuilder())
            {
                for (int i = startIndex; i < value.Length; i++)
                {
                    if (value[i] == endChar)
                    {
                        if (WriteEndChar == true)
                        {
                            b.Append(value[i]);

                        }

                        break;
                    }
                    else
                    {
                        b.Append(value[i]);
                    }


                }
                return b.ToString();
            }
        }
        public  string Cut(string value, int startIndex, char endChar, bool WriteEndChar, int selectedIndex)
        {
            using (TextBuilder b = new TextBuilder())
            {
                int number = 0;
                for (int i = startIndex; i < value.Length; i++)
                {
                    number++;
                    if (value[i] == endChar)
                    {
                        if (WriteEndChar == true)
                        {
                            b.Append(value[i]);

                        }

                        break;
                    }
                    else
                    {
                        b.Append(value[i]);
                    }


                }
                selectedIndex = selectedIndex + number;
                GC.SuppressFinalize(number);
                return b.ToString();
            }
        }
        public  IndexInfo CutOfWriteChar(string value, int startIndex)
        {
            int l = 0;
            using (TextBuilder builder = new TextBuilder())
            {
                for (int i = startIndex; i < value.Length; i++)
                {
                    if (char.IsWhiteSpace(value[i]) == true)
                    {
   l = i;
                        break;

                    }
                    else
                    {
                        builder.Append(value[i]);
                    }
                 
                }
                return new IndexInfo(l, builder.ToString(), true);
            }
        }
    
        public  string Cut(string value, int startIndex, char endChar)
        {
            using (TextBuilder b = new TextBuilder())
            {
                for (int i = startIndex; i < value.Length; i++)
                {
                    if (value[i] == endChar)
                    {


                        break;
                    }
                    else
                    {
                        b.Append(value[i]);
                    }


                }
                return b.ToString();
            }
        }
        public  string Cut(string value, char startChar, char endChar)
        {
            using (TextBuilder b = new TextBuilder())
            {
                bool starting = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == startChar)
                    {
                        starting = true;
                    }
                    if (value[i] == endChar)
                    {


                        break;
                    }
                    else if (starting == true)
                    {

                        b.Append(value[i]);
                    }


                }
                return b.ToString();
            }
        }
        // Boşluk karakteri 
        public IndexInfo CutOfWhiteChar(string value)
        {
            int loc = 0;
            using (TextBuilder builder = new TextBuilder())
            {
                for(int i=0;i<value.Length;i++)
                {
                    if(char.IsWhiteSpace(value[i]))
                    {
                        loc = i;
                        break;
                    }
                    else
                    {
                        builder.Append(value[i]);
                    }
                }
                return new IndexInfo(loc, builder.ToString(),loc>0);
            }
        }
        // string dizesini tersine çevirir
        public  char[] ReverseToArray(string value)
        {
            using (TextBuilder b = new TextBuilder())
            {
                int index = value.Length - 1;
                while (true)
                {
                    if (index == -1)
                    {
                        break;
                    }
                    else
                    {
                        b.Append(value[index]);

                        index--;
                    }


                }
                GC.SuppressFinalize(index);
                return b.ToString().ToCharArray();
            }
        }
        public  char[] ReverseToArray(char[] value)
        {
            using (TextBuilder b = new TextBuilder())
            {
                int index = value.Length - 1;
                while (true)
                {
                    if (index == -1)
                    {
                        break;
                    }
                    else
                    {
                        b.Append(value[index]);

                        index--;
                    }


                }
                GC.SuppressFinalize(index);
                return b.ToString().ToCharArray();
            }
        }
        public  int IndexOf(string value, char ch)
        {
            int d = 0;
            char c = '"';

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '"' || value[i] == Properties.Settings.Default.Ayar)
                {
                    i = value.IndexOf(value[i], i);
                }
                if (ch == value[i])
                {
                    d = i;
                    break;
                }
            }
            return d;
        }
        public  List<char> chs = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public  int ConvertNumber(string value)
        {
            using (TextBuilder builder = new TextBuilder())
            {
                for (int i = 0; i < value.Length; i++)
                {
                    try
                    {
                        if (chs.Contains(value[i]) == true)
                        {
                            builder.Append(value[i]);
                        }
                    }
                    catch
                    {

                    }
                }
                return Convert.ToInt32(builder.ToString().Trim());
            }
        }
        public  int IndexOf(string value, char ch, int index)
        {
            int d = 0;
            char c = '"';

            for (int i = index; i < value.Length; i++)
            {

                if (value[i] == '"' || value[i] == Properties.Settings.Default.Ayar)
                {
                    i = value.IndexOf(value[i], i) + 1;
                }
                if (ch == value[i])
                {
                    d = i;
                    break;
                }
            }
            return d;
        }
        public  List<string> GetStrings(string code, char start, char end)
        {
            List<string> strings = new List<string>();
            int startIndex = 0;
            int endIndex = 0;
            string val = "";
            for (int i = 0; i < code.Length; i++)
            {
                startIndex = IndexOf(code, start, i);
                endIndex = IndexOf(code, end, startIndex);
                val = Cut(code, startIndex, endIndex);
                if (strings.Contains(val) == false)
                {
                    strings.Add(val);
                }


                startIndex = endIndex + 1;

            }
            return strings;
        }

        public  int GotoCharIndex(string code, int StartIndex)
        {
            int location = 0;
            for (int i = StartIndex; i < code.Length; i++)
            {

                if (char.IsWhiteSpace(code[i]) == false)
                {
                    location = i;
                    break;
                }
            }
            return location;
        }

        public  SearchResult FindChar(string code, int startIndex, List<char> chars)
        {
            SearchResult c = new SearchResult('0', 0, false);
            for (int i = startIndex; i < code.Length; i++)
            {
                if (code[i] == '"' || code[i] == WebProject.Properties.Settings.Default.Ayar)
                {
                    i = IndexOf(code, code[i], i) + 1;
                }
                if (chars.Contains(code[i]) == true)
                {

                    c = new SearchResult(code[i], i, true);

                }
            }
            return c;
        }
        public  List<string> GetStrings(string code, char start, char end, int indexLocation)
        {
            List<string> strings = new List<string>();
            int startIndex = 0;
            int endIndex = 0;
            string val = "";
            int loc = 0;
            for (int i = 0; i < code.Length; i++)
            {
                loc = i;
                startIndex = IndexOf(code, start, i);
                endIndex = IndexOf(code, end, startIndex);
                val = Cut(code, startIndex, endIndex);
                if (strings.Contains(val) == false)
                {
                    strings.Add(val);
                }
                loc = i;

                startIndex = endIndex + 1;
                loc = i;
            }
            indexLocation = loc;
            return strings;
        }
        public  bool StringContains(string value, string searchvalue)
        {
            bool b = false;
            using (TextBuilder builder = new TextBuilder())
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsWhiteSpace(value[i]))
                    {
                        if (builder.Length > 0)
                        {
                            if (builder.ToString() == searchvalue)
                            {
                                b = true;
                                builder.Clear();
                                break;
                            }
                        }
                    }
                    if (i == value.Length - 1)
                    {
                        builder.Append(value[i]);
                        if (builder.Length > 0)
                        {
                            if (builder.ToString() == searchvalue)
                            {
                                b = true;
                                builder.Clear();
                                break;
                            }
                        }
                    }
                }
            }
            return b;
        }
  
        public  List<string> SplitOfChar(string value, char c)
        {
            List<string> s = new List<string>();
            using (TextBuilder b = new TextBuilder())
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (i == value.Length - 1)
                    {
                        b.Append(value[i]);
                        s.Add(b.ToString());
                        b.Clear();
                    }
                    if (value[i] == c)
                    {
                        s.Add(b.ToString());
                        b.Clear();
                    }

                }

            }
            return s;
        }
        public List<string> ListOfLines(string value)
        {
      
            return SplitOfChar(value,'\n');     
        }
        public  bool Scan(string code, List<char> chars, char find, int startIndex, int location)
        {
            bool IsFind = false;
            for (int i = startIndex + 1; i < code.Length; i++)
            {
                if (chars.Contains(code[i]) == true)
                {
                    IsFind = true;
                    find = code[i];
                }
            }

            return IsFind;
        }
        public  bool SearchOfChar(string value, char c)
        {
            bool b = false;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == c)
                {
                    b = true;
                    break;
                }

            }
            return b;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
