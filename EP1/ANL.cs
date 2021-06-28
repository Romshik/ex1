using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace EP1
{
    
    public class ANL
    {
        [NonSerialized] public int k =0;
       public string FileName = string.Empty;
        public long FileSize;
        public int countWords;
        public int countLetters;
        public int countDigits ;
        public  int countNumbers ;
        public int countHyphen ;
        public int countPunct ;
        public int lines ;
        public string longestWord=string.Empty;
        public Dictionary<char, int> Letters = new Dictionary<char, int>();
        public Dictionary<string, int> Words = new Dictionary<string, int>();
      
        public void QQQ(string FileP)
        {
            try
            {  FileName= Path.GetFileName(FileP);
                FileSize= new System.IO.FileInfo(FileP).Length;
                string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string[] aa = new string[] { };
                foreach (char ch in alphabet)
                    Letters.Add(ch, 0);

                foreach (var line in File.ReadLines(FileP))
                {
                    countLetters = countLetters + Regex.Matches(line, @"[a-zA-Z]").Count;
                    countNumbers = countNumbers + Regex.Matches(line, @"\d+").Count;
                    countDigits = countDigits + Regex.Matches(line, @"\d").Count;
                    countWords = countWords + Regex.Matches(line, @"[a-zA-Z]+").Count;
                    countHyphen = countHyphen + Regex.Matches(line, @"([A-zА-я]+[\-][A-zА-я]+)").Count;
                    countPunct = countPunct + Regex.Matches(line, @"[?()!.,;:""'']").Count;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////
                    aa = Regex.Matches(line, @"[a-zA-Z]+").Cast<Match>().Select(m => m.Value).ToArray();
                    ///////////////////////////////////////////////////////////////////////////////////////////

                    for (int i = 0; i < aa.Length; i++)
                        if (aa[i].Length > longestWord.Length)
                            longestWord = aa[i];

                    foreach (var word in aa)
                    {
                        var count = 0;
                        Words.TryGetValue(word, out count);
                        Words[word] = count + 1;
                    }

                    foreach (char ch in line)
                        if (alphabet.Contains(ch.ToString()))
                            Letters[ch]++;
                    lines++;
                }

                Words = Words.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                Letters = Letters.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            catch { Console.WriteLine("Unexpected error. Сheck the entered path"); k = 1; }


        }
    }
}
