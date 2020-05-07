using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NetCoreCoding.LeetCode.String.Easy
{
    public class ToGoatLatinSoln
    {
        public ToGoatLatinSoln()
        {
        }

        public void execute()
        {            
            var res = ToGoatLatin("I speak Goat Latin");
            Debug.Assert(res == "Imaa peaksmaaa oatGmaaaa atinLmaaaaa");
        }

        public string ToGoatLatin(string S)
        {
            var words = S.Split(" ");
            var str = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                //if first character is vowel
                if (IsVowel(words[i][0]))
                {
                    str.Append(words[i]);                    
                }
                else
                {
                    str.Append(words[i].Substring(1, words[i].Length - 1));
                    str.Append(words[i][0]);                    
                }
                str.Append("ma");
                for(int j = 0; j < i + 1; j++) {
                    str.Append("a");
                }
                str.Append(" ");
            }

            return str.ToString().Trim();
        }

        private bool IsVowel(char v)
        {
            var volwels = new char[] { 'a', 'e' , 'i' , 'o' , 'u' , 'A' , 'E' , 'I' , 'O' , 'U' };
            return volwels.Contains(v);
        }
    }
}
