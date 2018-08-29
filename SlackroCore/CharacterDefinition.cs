using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackroCore
{
    public static class CharacterDefinition
    {

        private static Dictionary <char,string[]> LoadCharacters()
        {
            Dictionary<char, string[]> Letters = new Dictionary<char, string[]>();
            Letters.Add('A', new string[]{ " ** ",
                                           "*  *",
                                           "****",
                                           "*  *",
                                           "*  *"});

            Letters.Add('B', new string[]{ "*** ",
                                           "*  *",
                                           "*** ",
                                           "*  *",
                                           "*** " });

            Letters.Add('C', new string[] { " ***",
                                            "*   ",
                                            "*   ",
                                            "*   ",
                                            " ***" });

            Letters.Add('D', new string[] { "*** ",
                                            "*  *",
                                            "*  *",
                                            "*  *",
                                            "*** " });

            Letters.Add('E', new string[] { "***",
                                            "*  ",
                                            "** ",
                                            "*  ",
                                            "***" });

            Letters.Add('F', new string[] { "****",
                                            "*   ",
                                            "*** ",
                                            "*   ",
                                            "*   " });

            Letters.Add('G', new string[] { " ***",
                                            "*   ",
                                            "* **",
                                            "*  *",
                                            " ***" });

            Letters.Add('H', new string[] { "*  *",
                                            "*  *",
                                            "****",
                                            "*  *",
                                            "*  *" });

            Letters.Add('I', new string[] { "*****",
                                            "  *  ",
                                            "  *  ",
                                            "  *  ",
                                            "*****" });

            Letters.Add('J', new string[] { "   *",
                                            "   *",
                                            "   *",
                                            "*  *",
                                            "****" });

            Letters.Add('K', new string[] { "*  *",
                                            "* * ",
                                            "**  ",
                                            "* * ",
                                            "*  *" });

            Letters.Add('L', new string[] { "*  ",
                                            "*  ",
                                            "*  ",
                                            "*  ",
                                            "***" });

            Letters.Add('M', new string[] { "*   *",
                                            "** **",
                                            "* * *",
                                            "*   *",
                                            "*   *" });

            Letters.Add('N', new string[] { "*   *",
                                            "**  *",
                                            "* * *",
                                            "*  **",
                                            "*   *" });

            Letters.Add('O', new string[] { " *** ",
                                            "*   *",
                                            "*   *",
                                            "*   *",
                                            " *** " });

            Letters.Add('P', new string[] { "*** ",
                                            "*  *",
                                            "*** ",
                                            "*   ",
                                            "*   " });

            Letters.Add('Q', new string[] { " *** ",
                                            "*   *",
                                            "*   *",
                                            " ****",
                                            "    *" });

            Letters.Add('R', new string[] { "*** ",
                                            "*  *",
                                            "*** ",
                                            "*  *",
                                            "*  *" });

            Letters.Add('S', new string[] { " ***",
                                            "*   ",
                                            " ** ",
                                            "   *",
                                            "*** " });

            Letters.Add('T', new string[] { "*****",
                                            "  *  ",
                                            "  *  ",
                                            "  *  ",
                                            "  *  " });

            Letters.Add('U', new string[] { "*   *",
                                            "*   *",
                                            "*   *",
                                            "*   *",
                                            " *** " });

            Letters.Add('V', new string[] { "*   *",
                                            "*   *",
                                            "*   *",
                                            " * * ",
                                            "  *  " });

            Letters.Add('W', new string[] { "*   *",
                                            "*   *",
                                            "* * *",
                                            "* * *",
                                            " * * " });

            Letters.Add('X', new string[] { "*   *",
                                            " * * ",
                                            "  *  ",
                                            " * * ",
                                            "*   *" });

            Letters.Add('Y', new string[] { "*   *",
                                            " * * ",
                                            "  *  ",
                                            "  *  ",
                                            "  *  " });

            Letters.Add('Z', new string[] { "*****",
                                            "   * ",
                                            "  *  ",
                                            " *   ",
                                            "*****" });

            Letters.Add('.', new string[] { " ",
                                            " ",
                                            " ",
                                            " ",
                                            "*" });

            Letters.Add(',', new string[] { "  ",
                                            "  ",
                                            "  ",
                                            "* ",
                                            " *" });

            Letters.Add('!', new string[] { "*",
                                            "*",
                                            "*",
                                            " ",
                                            "*" });

            Letters.Add('?', new string[] { "****",
                                            "   *",
                                            " ***",
                                            "    ",
                                            " *  " });

            Letters.Add(' ', new string[] { " ",
                                            " ",
                                            " ",
                                            " ",
                                            " " });

            Letters.Add('-', new string[] { "   ",
                                            "   ",
                                            "***",
                                            "   ",
                                            "   " });

            Letters.Add(':', new string[] { "   ",
                                            " * ",
                                            "   ",
                                            " * ",
                                            "   " });

            Letters.Add(';', new string[] { "   ",
                                            " * ",
                                            "   ",
                                            " * ",
                                            "*  " });

            Letters.Add('*', new string[] { "*   *",
                                            " * * ",
                                            "*****",
                                            " * * ",
                                            "*   *" });
            Letters.Add('\\', new string[] { "*    ",
                                            " *   ",
                                            "  *  ",
                                            "   * ",
                                            "    *" });

            Letters.Add('/', new string[] { "    *",
                                            "   * ",
                                            "  *  ",
                                            " *   ",
                                            "*    " });

            Letters.Add('1', new string[] { " * ",
                                            "** ",
                                            " * ",
                                            " * ",
                                            "***" });

            Letters.Add('2', new string[] { "****",
                                            "   *",
                                            "****",
                                            "*   ",
                                            "****" });

            Letters.Add('3', new string[] { "****",
                                            "   *",
                                            "****",
                                            "   *",
                                            "****" });

            Letters.Add('4', new string[] { "*  *",
                                            "*  *",
                                            "****",
                                            "   *",
                                            "   *" });

            Letters.Add('5', new string[] { "****",
                                            "*   ",
                                            "****",
                                            "   *",
                                            "****" });

            Letters.Add('6', new string[] { "****",
                                            "*   ",
                                            "****",
                                            "*  *",
                                            "****" });

            Letters.Add('7', new string[] { "****",
                                            "   *",
                                            "   *",
                                            "   *",
                                            "   *" });

            Letters.Add('8', new string[] { "****",
                                            "*  *",
                                            "****",
                                            "*  *",
                                            "****" });

            Letters.Add('9', new string[] { "****",
                                            "*  *",
                                            "****",
                                            "   *",
                                            "****" });

            Letters.Add('0', new string[] { "****",
                                            "*  *",
                                            "*  *",
                                            "*  *",
                                            "****" });
            return Letters;
        }

        public static string Macrofy(string text, string emoji)
        {
            string macro = "";
            string blank = ConfigurationManager.AppSettings["blankmoji"];
            Dictionary <char,string[]> letters = LoadCharacters();
            text = text.ToUpper();

            for(int y=0;y<5;y++)
            {
                string line = "";
                foreach (char l in text)
                {
                    string[] letter = null;
                    if (letters.TryGetValue(l, out letter))
                    {
                        line += letter[y].ToString() + blank;
                    }
                }
                if (line.Contains('*'))
                {
                    line = line.Substring(0, line.LastIndexOf('*') + 1);
                }
                macro += line + '\n';
            }            

            macro = macro.Replace(" ", blank);
            macro = macro.Replace("*", emoji);

            return macro;
        }
    }
}
