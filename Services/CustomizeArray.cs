using System.Collections;
using System.Text;

namespace StringAnalyzer.Services
{
    public static class CustomizeArray
    {
        static CustomizeArray()
        {
        }

        // StringBuilder with items from arraylist and every word is divided by comma.
        public static StringBuilder ArrayListToString(ArrayList arrlist)
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

        public static int[] StringArrayToIntArray(String[] arrayStr)
        {
            int[] arrayInt = new int[arrayStr.Length];  
           for(int i = 0; i< arrayStr.Length; i++)
            {
                arrayInt[i] = arrayStr[i].Length;
            }

            return arrayInt;
        }

        public static decimal[] FillArray(int[] arrayStr , decimal fillWith)
        {
            decimal[] array = new decimal[arrayStr.Length];
            for(int i = 0; i < arrayStr.Length; i++)
            {
                array[i] = fillWith;
            }
            return array;
        }

        // Items to strig from array and every word is divided by comma.
        public static String ArrayToString(String[] array)
        {
            //StringBuilder text = new StringBuilder();
            String text = String.Join(", ", array);
            return text;
        }
    }
}
