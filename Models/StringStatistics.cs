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
                try
                {
                    text = value;
                    WordArray = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    WordArray = WordArray.Select(s => s.ToLowerInvariant()).ToArray();
                }
                catch (NullReferenceException ex)
                {
                    text = null;
                    WordArray = new string[] {};
                    WordArray = WordArray.Select(s => s.ToLowerInvariant()).ToArray();
                    throw new Exception("Exception {0}", ex);
                }
            }
        }

        string[] WordArray;
        readonly char[] separators = new char[] { ' ', '.', ',', ';', '!', '?', '\n', '(', ')', '\t', '\b', '\f', '\0', '\r', '\v'};
        char[] alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
        readonly char[] delimiterChars = new char[] { '.', '?', '!' };
        readonly string newRow = "\n";
        private string text;


 

        public StringStatistics(string text)
        {
            try
            {
                Text = text;
                WordArray = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                WordArray = WordArray.Select(s => s.ToLowerInvariant()).ToArray();
            }
            catch (NullReferenceException ex)
            {
                Text = null;
                WordArray = new string[] { };
                WordArray = WordArray.Select(s => s.ToLowerInvariant()).ToArray();
                throw new Exception("Exception {0}", ex);
            }
        }

        //public Dictionary<char,string[]> WordsByFirstLetters()
        public Dictionary<char,int> WordsByFirstLetters()
        {
            Dictionary<char,int> alphabetCount = new Dictionary<char, int>();
            foreach (char letterToCheck in alphabet)
            {
                alphabetCount[letterToCheck] = 0;
            }

                foreach (string wordToCheck in WordArray)
            {
                foreach (char letterToCheck in alphabet)
                {
                    if (letterToCheck.ToString().Contains(wordToCheck[0]))
                    {
                            alphabetCount[letterToCheck]++;
                    }
                }
            }
        return alphabetCount;
        }


        public Dictionary<char, int> WordsByLetters()
        {
            Dictionary<char, int> alphabetCount = new Dictionary<char, int>();
            foreach (char letterToCheck in alphabet)
            {
                alphabetCount[letterToCheck] = 0;
            }
            foreach (string wordToCheck in WordArray)
            {
                for(int i = 0; i < wordToCheck.Length; i++)
                {
                    if(alphabetCount.ContainsKey(wordToCheck[i]))
                    {
                        alphabetCount[wordToCheck[i]]++;
                    }
                }
            }
            return alphabetCount;
        }

        public ArrayList MostCommonLetter()
        {
            Dictionary<char, int> alphabetCount = WordsByLetters();

            int maxValue = alphabetCount.Values.Max();
            ArrayList mostCommonLetters = new();

            foreach (var letter in alphabet)
            {
                if (alphabetCount[letter] == maxValue)

                {
                    mostCommonLetters.Add(letter);
                }
            }
            return mostCommonLetters;
        }

        public decimal LetterPercents(int count, Dictionary<char, int> allLetters)
        {
            int sum = 0;
            foreach(int letter in allLetters.Values)
            {
                sum += letter;    
            }

            return 100*Convert.ToDecimal(count)/ Convert.ToDecimal(sum);
        }

        public StringStatistics()
        {
            // WordArray = Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////
        /// Pro vypisovani veci do konzole pri psani novych metod
        public string Ladeni()
        {
            
            Dictionary<char, int> My_dict = WordsByFirstLetters();
            foreach(KeyValuePair<char, int> pair in My_dict)
            {
               Console.WriteLine("{0} and {1}", pair.Key, pair.Value);
            }
            return "Ladime";
        }
      


        // Returns Integrer with number of words.
        public int NumberOfWords()
        {
            int words = WordArray.Length;
            return words;

        }

        // Returns Integer with number of row.
        public int NumberOfRows()
        {
            int row = Text.Split(newRow).Length;
            return row;
        }

        // Integer number of sentences.
        public int NumberOfSentences()
        {
            string text = Text.Replace("\n", "").Replace("\r", "").Replace(" ", "");
            string[] row = text.Split(delimiterChars);
            int counter = 0;
            if (row.Length == 2)
            {
                if (Char.IsUpper(row[0][0]))
                {
                    counter++;
                }
            }
            else
            {
                for (int i = 0; i < (row.Length - 2); i++)
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
            }
            return counter;
        }


        // Returns arrayList of longest words.
        public ArrayList LongestWords()
        {
            ArrayList longestWords = new();
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
                if (word.Length == maxLenght && !longestWords.Contains(word))
                {
                    longestWords.Add(word);
                }
            }
            return longestWords;
        }

        // Returns arrayList of shortest words
        public ArrayList ShortestWords()
        {
            ArrayList shortestWords = new();
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
                if (word.Length == minLenght && !shortestWords.Contains(word))
                {
                    shortestWords.Add(word);
                }
            }
            return shortestWords;
        }

        public decimal AvarageWordLength()
        {
            decimal numberOfWords = Convert.ToDecimal(WordArray.Count());
            decimal sums = 0;
            foreach (var word in WordArray)
            {
                sums = sums + word.Length;
            }

            return sums / numberOfWords;

        }
        //fist int is how long a word is
        public Dictionary<int, int> WordsByLenght()
        {
            var dict = new Dictionary<int, int>();
           // var kratky = ShortestWords();
            int shortest = ((string) ShortestWords()[0]).Length;
            int longest = ((string)LongestWords()[0]).Length;

          
            for(int i = shortest; i <= longest; i++)
            {
                dict.Add(i, 0);
            }
            foreach (var word in WordArray)
            {
                if (dict.ContainsKey(word.Length))
                {
                    dict[word.Length]++;
                }
                else
                {
                    dict[word.Length] = 1;
                    Console.Write("Tohle by se nemelo d9t {0}", word);
                }
            }


            return dict;
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
            ArrayList commonWords = new();
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



        // StringBuilder with items from arraylist and every word is divided by comma.
        public StringBuilder PrintArrayList(ArrayList arrlist)
        {
            StringBuilder text = new();
            foreach (var item in arrlist)
                {
                    if (arrlist[arrlist.Count - 1] == item)
                    {
                        text.Append(item);
                    }
                    else
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
