using ListSymbolTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovLibrary
{
    public class MarkovModel
    {

        ListSymbolTable<string, MarkovEntry> table;
        string fileName;
        int subStringLength;
        int maxCharacters;
        int totalCharCount;
        int storyLength;

        public MarkovModel(string fileName, int subStringLength, int maxCharacters)
        {
            this.fileName = fileName;
            this.subStringLength = subStringLength;
            this.maxCharacters = maxCharacters;
            totalCharCount = 0;
            storyLength = 0;
            table = new ListSymbolTable<string, MarkovEntry>();
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
           return table.ToString();
        }

        /// <summary>
        /// Splits the string then adds it to the symbol table
        /// </summary>
        /// <param name="text"></param>
        private void Split(string text)
        {
            while(totalCharCount < text.Length)
            {
                string sub = text.Substring(totalCharCount, subStringLength + totalCharCount);
                char CharAfterSub = char.Parse(text.Substring(subStringLength + totalCharCount, subStringLength + totalCharCount + 1));
                if (!table.Contains(sub))
                {
                    table.Add(sub, new MarkovEntry(sub, CharAfterSub));
                    totalCharCount = subStringLength + totalCharCount;
                }
                else
                {
                    table.GetValue(sub).Add(CharAfterSub);
                    totalCharCount = subStringLength + totalCharCount;
                }
            }           
           
        }


    }
}
