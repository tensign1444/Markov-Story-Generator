using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLib;

namespace MarkovLibrary
{
    public class MarkovEntry
    {
        private _2022_Spring_TannerEnsign_MyListLibrary<char> suffixes;
        private string substring;
        private int count;

        public MarkovEntry(string key)
        {
            this.substring = key;
            count = 0;
        }

        public void Add(char ch)
        {
            count++;
            suffixes.Add(ch);
        }

        public override string ToString()
        {
            return $"'{substring}' ({count}) : {suffixes}";
        }
    }
}
