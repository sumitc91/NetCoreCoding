using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NetCoreCoding.LeetCode.String.Easy
{
    public class MostCommonWordSoln
    {
        public MostCommonWordSoln()
        {
        }

        public void execute()
        {
            var paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            var banned = new string[] { "hit" };
            var output = "ball";
            var res = "";
            //res = MostCommonWord(paragraph, banned);
            //Assert(res, output);

            paragraph = "a, a, a, a, b,b,b,c, c";
            banned = new string[] { "a" };
            output = "b";
            res = MostCommonWord(paragraph, banned);
            Assert(res, output);
        }

        private void Assert(string response, string expected)
        {
            if (response != expected)
                throw new Exception("Incorrect Answer.");
        }

        public string MostCommonWord(string paragraph, string[] banned)
        {
            var dict = new SortedDictionary<string, int>();
            var punctuation = new string[] { "!", "?", "\'", ",", ";", "." };

            foreach (var item in punctuation)
            {
                paragraph = paragraph.Replace(item," ");
            }
            
            var words = paragraph.Split(" ");
            for(int i=0;i<words.Length;i++)
            {
                words[i] = words[i].ToLower().Trim();
                if (words[i] == "") continue;
                if (dict.ContainsKey(words[i]))
                {
                    dict[words[i]]++;
                }
                else
                {
                    dict[words[i]] = 1;
                }
            }

            var myList = dict.ToList();

            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            myList.Reverse();

            foreach (var item in myList)
            {
                if (!CheckIfWordIsBanned(item.Key, banned))
                {
                    return item.Key;
                }
            }

            return ""; 
        }

        private bool CheckIfWordIsBanned(string word, string[] banned)
        {
            foreach (var item in banned)
            {
                if (word == item) return true;
            }
            return false;
        }
    }
}
