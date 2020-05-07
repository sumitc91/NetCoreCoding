using System;
using System.Collections.Generic;

namespace NetCoreCoding.LeetCode.String.Easy
{
    public class BuddyStringsSoln
    {
        public BuddyStringsSoln()
        {
        }

        public void execute()
        {
            var A = "abab";
            var B = "abab";
            var res = BuddyStrings(A,B);
        }

        public bool BuddyStrings(string A, string B)
        {
            if (A.Length != B.Length)
                return false;

            int diff = 0;
            char[] diffChar = new char[2];
            var set = new HashSet<char>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                {
                    diff++;
                    if(diff==1)
                    {
                        diffChar[0] = A[i];
                        diffChar[1] = B[i];
                    }
                    else
                    {
                        if (diffChar[0] != B[i] || diffChar[1] != A[i])
                            return false;
                    }
                }
                
                set.Add(A[i]);
            }

            if (A == B)
                return set.Count < A.Length;

            //case where all characters are same in 
            if (diff == 0 && set.Count == 1)
                return true;

            return diff == 2;
        }
    }
}
