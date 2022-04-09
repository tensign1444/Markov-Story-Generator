using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListLib;

/**
* <author>
* Tanner Ensign, Nathan Maldonado, Masaya Takahashi
* </author> 
* 
*<summary>
* This is the MarkovEntry class which is a custom data type
*</summary>
*
* <date>
* 4/9/2022
* </date> 
*/
namespace MarkovLibrary
{
    public class MarkovEntry
    {
        private _2022_Spring_TannerEnsign_MyListLibrary<char> suffixes;
        private string substring;
        private int count;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ch"></param>
        public MarkovEntry(string key, char ch)
        {
            suffixes = new _2022_Spring_TannerEnsign_MyListLibrary<char>();
            this.substring = key;          
            count = 0;
            Add(ch);
        }

        /// <summary>
        /// Adds a character to this entry
        /// </summary>
        /// <param name="ch"></param>
        public void Add(char ch)
        {
            count++;
            suffixes.Add(ch);
        }

        /// <summary>
        /// Custom ToString method to string out the suffixes and count
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"MarkovEntry:'{suffixes}' + ({count})";
        }

        /// <summary>
        /// Selects a random letter from the suffixes.
        /// </summary>
        /// <returns></returns>
        public char RandomLetter()
        {
            Random rand = new Random();
            return suffixes[rand.Next(suffixes.Count)];
        }
        
    }
}
