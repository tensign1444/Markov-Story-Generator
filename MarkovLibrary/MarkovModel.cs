using ListSymbolTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSymbolTable;

namespace MarkovLibrary
{
    public class MarkovModel
    {

        ListSymbolTable<string, MarkovEntry> ListTable;
        TreeSymbolTable<string, MarkovEntry> TreeTable;
        SortedDictionary<string, MarkovEntry> DictionaryTable;
        string fileName;
        int subStringLength;
        int maxCharacters;
        int totalCharCount;
        int storyLength;
        int tableType; //1 for List Symbol Table, 2 for BST, 3 for .Net SortedDictionary
        string beginning;

        StringBuilder ourStory;

        public MarkovModel(string fileName, int subStringLength, int maxCharacters, int tableType = default)
        {
            this.fileName = fileName;
            this.subStringLength = subStringLength;
            this.maxCharacters = maxCharacters;
            totalCharCount = 0;
            storyLength = 0;
            this.tableType = tableType;
            ourStory = new StringBuilder();
            DeclareTableType();


        }

        /// <summary>
        /// Declares our table type
        /// </summary>
        public void DeclareTableType()
        {
            if (tableType == 0)
                ListTable = new ListSymbolTable<string, MarkovEntry>();
            else if (tableType == 1)
                TreeTable = new TreeSymbolTable<string, MarkovEntry>();
            else
                DictionaryTable = new SortedDictionary<string, MarkovEntry>();
        }

        /// <summary>
        /// Reads the textfile and puts it into a string
        /// </summary>
        /// <param name="fileLocation"></param>
        public void ReadFile()
        {
            string text = File.ReadAllText(fileName);
            Split(text);
        }

        /// <summary>
        /// Prints the table as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
           return TableToString();
        }

        /// <summary>
        /// Splits the string then adds it to the symbol table
        /// </summary>
        /// <param name="text"></param>
        private void Split(string text)
        {
            int end = 0;
            while (totalCharCount < text.Length)
            {
                string sub = default;
                end = end + subStringLength + totalCharCount + 1;
                if (end >= text.Length)
                {
                    sub = text.Substring(totalCharCount);
                    totalCharCount = text.Length;
                }
                else
                {
                    sub = text.Substring(totalCharCount, subStringLength + 1);
                    if (totalCharCount == 0)
                        beginning = sub.Substring(0, sub.Length - 1);
                    totalCharCount = subStringLength + totalCharCount;
                }
                // C:\Users\Darth\Desktop\MarkovTestText\Lincoln.txt

                char letter = sub[sub.Length - 1];
                sub = sub.Substring(0, sub.Length - 1);
                if (!Contains(sub))
                {
                    Add(sub,letter);
                    
                }
                else
                {
                    AddValue(sub,letter);
                }
            }           
           
        }

        /// <summary>
        /// Adds a value to our MarkovEntry for the specific key in our type of table
        /// </summary>
        /// <param name="sub"></param>
        /// <param name="letter"></param>
        private void AddValue(string sub, char letter)
        {
            if (tableType == 0)
                ListTable[sub].Add(letter);
            else if (tableType == 1)
                TreeTable[sub].Add(letter);
            else
                DictionaryTable[sub].Add(letter);
        }

        /// <summary>
        /// Checks if the type of table contains a key. Returns true or false.
        /// </summary>
        /// <param name="sub"></param>
        /// <returns>bool</returns>
        private bool Contains(string sub)
        {
            if (tableType == 0)
                return ListTable.Contains(sub);
            else if (tableType == 1)
                return TreeTable.Contains(sub);
            else
                return DictionaryTable.ContainsKey(sub);
        }

        /// <summary>
        /// Adds a key, value pair to our type of table
        /// </summary>
        /// <param name="sub"></param>
        /// <param name="letter"></param>
        private void Add(string sub, char letter)
        {
            if (tableType == 0)
                ListTable.Add(sub, new MarkovEntry(sub, letter));
            else if (tableType == 1)
                TreeTable.add(sub, new MarkovEntry(sub, letter));
            else
                DictionaryTable.Add(sub, new MarkovEntry(sub, letter));
        }

        /// <summary>
        /// Private helper for our ToString method
        /// </summary>
        /// <returns>string of the table</returns>
        private string TableToString()
        {
            if (tableType == 0)
                return ListTable.ToString();
            else if (tableType == 1)
                return TreeTable.ToString();
            else
                return DictionaryTable.ToString();
        }

        /// <summary>
        /// The main method for generating a story
        /// </summary>
        public StringBuilder GenerateStory()
        {
            StoryBuilder();
            return ourStory;
        }

        
        private void StoryBuilder()
        {
            ourStory.Append(beginning);
            ourStory.Append(GetRandomCharFromKey(beginning));
            int charCount = 0;
            while(charCount <= maxCharacters)
            {
                string random = GetRandomString();
                ourStory.Append(random);
                char randomChar = GetRandomCharFromKey(random);
                ourStory.Append(randomChar);
                charCount = ourStory.Length;
            }
        }


        /// <summary>
        /// Gets a random Key for us to add to our string
        /// </summary>
        /// <returns>string</returns>
        private string GetRandomString()
        {
            Random rand = new Random();
            if (tableType == 0)
                return ListTable.GetKey(rand.Next(ListTable.Count));
            else if (tableType == 1)
                return TreeTable.GetKey(rand.Next(TreeTable.Count));
            else
                return DictionaryTable.ElementAt(rand.Next(DictionaryTable.Count)).Key;
        }

        /// <summary>
        /// Gets a random char value from our Values
        /// </summary>
        /// <param name="key"></param>
        /// <returns>char</returns>
        private char GetRandomCharFromKey(string key)
        {
            Random rand = new Random();
            if (tableType == 0)
                return ListTable[key].RandomLetter();
            else if (tableType == 1)
                return TreeTable[key].RandomLetter();
            else
                return DictionaryTable[key].RandomLetter();
        }
    }
}
