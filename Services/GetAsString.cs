using System.Collections;
using System.Text;

namespace StringAnalyzer.Services
{
    public static class GetAsString
    {
        static GetAsString()
        {
        }

        // StringBuilder with items from arraylist and every word is divided by comma.
        public static StringBuilder ArrayListToString(ArrayList arrlist)
        {
            StringBuilder text = new StringBuilder();
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

        // Items to strig from array and every word is divided by comma.
        public static String ArrayToString(String[] array)
        {
            //StringBuilder text = new StringBuilder();
            String text = String.Join(", ", array);
           
            return text;
        }
    }
}
