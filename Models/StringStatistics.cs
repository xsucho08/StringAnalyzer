using System.Collections;
using System.Text;


namespace StringAnalyzer.Models
{
    public class StringStatistics
    {

        public string Text
        {
            get => text; set
            {
                text = value;
                WordArray = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        string[] WordArray;

        char[] separators = new char[] { ' ', '.', ',', ';', '!', '?', '\n', '(', ')' };
        char[] delimiterChars = new char[] { '.', '?', '!' };
        string newRow = "\n";
        private string text;

        public StringStatistics(string text)
        {
            Text = text;
            WordArray = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        public StringStatistics()
        {

            // WordArray = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }


        // Returns Integrer with number of words.
        public int NumberOfWords()
        {
            int words = WordArray.Length;
            return words;
        }

        // Returns Integer with number of row.
        public int NumberOfRow()
        {
            int row = Text.Split(newRow).Length;
            return row;
        }

        // Integer number of sentences.
        public int NumberOfSentences()
        {
            string text = Text.Replace("\n", "").Replace(" ", "");
            string[] row = text.Split(delimiterChars);
            int counter = 0;
            for (int i = 0; i < row.Length - 2; i++)
            {
                if (i == 0 && Char.IsUpper(row[i][0]))
                {
                    counter++;
                }
                if (Char.IsUpper(row[i + 1][0]))
                {
                    counter++;
                }
            }
            return counter;
        }


        // Returns arrayList of longest words.
        public ArrayList LongestWords()
        {
            ArrayList longestWords = new ArrayList();
            int maxLenght = 0;

            foreach (string word in WordArray)
            {
                if (word.Length > maxLenght)
                {
                    maxLenght = word.Length;
                }
            }

            foreach (string word in WordArray)
            {
                if (word.Length == maxLenght)
                {
                    longestWords.Add(word);
                }
            }

            return longestWords;
        }

        // Returns arrayList of shortest words
        public ArrayList ShortestWords()
        {
            ArrayList shortestWords = new ArrayList();
            int minLenght = int.MaxValue;

            foreach (string word in WordArray)
            {
                if (word.Length < minLenght)
                {
                    minLenght = word.Length;
                }
            }

            foreach (string word in WordArray)
            {
                if (word.Length == minLenght)
                {
                    shortestWords.Add(word);
                }
            }

            return shortestWords;
        }

        // Alphabeticaly sorts and returns array of words.
        public string[] Alpabetize()
        {
            Array.Sort(WordArray);
            return WordArray;
        }

        // using dictionary something like hashmap and every occurrence add value by 1 and after finding biggest value
        // Returns arrayList of most used words.
        public ArrayList MostCommonWords()
        {
            var dict = new Dictionary<string, int>();
            ArrayList commonWords = new ArrayList();
            int ocurencies = 0;

            //var dict = new Dictionary<string, int>();
            //ArrayList commonWords = new ArrayList();
            //string text = Text.Replace("\n", " ").Replace("!", "").Replace("?", "").Replace(",", "").Replace(".", "").Replace("(", "").Replace(")", "");
            //string[] words = text.Split(' ');

            foreach (var value in WordArray)
            {
                if (dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict[value] = 1;
                }
            }

            foreach (var key in dict)
            {
                if (key.Value > ocurencies)
                {
                    ocurencies = key.Value;
                    commonWords.Clear();
                    commonWords.Add(key.Key);
                }
                else if (key.Value == ocurencies)
                {
                    commonWords.Add(key.Key);
                }
            }

            return commonWords;
        }


        //TO DO: is there an adult language?
        //----------------------------------------------------------------------------------------------------
        public bool IsInfected()
        {
            if (Text.ToLower().Contains("covid"))
            {
                return true;
            }
            else if (Text.ToLower().Contains("covid-19"))
            {
                return true;
            }
            else if (Text.ToLower().Contains("sars-cov-2"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //---------------------------------------------------------------------------------------------


        // StringBuilder with items from arraylist and every word is divided by comma.
        public StringBuilder PrintArrayList(ArrayList arrlist)
        {
            StringBuilder text = new StringBuilder();
            if (arrlist.Count == 1)
            {
                text.Append(arrlist[0]);
            }
            else
            {
                foreach (var item in arrlist)
                {
                    text.Append(item).Append(", ");
                }
            }
            return text;
        }


        public override string ToString()
        {
            return this.Text;
        }




    }
}
