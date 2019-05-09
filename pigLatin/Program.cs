using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            //pigLatin method
            Console.WriteLine("Please enter a word for me to translate to Pig Latin.");
            string input = Console.ReadLine();
            pigLatin(input);
            string translation = pigLatin(input);
            Console.WriteLine(translation);
        }

        public static string pigLatin(string input)
        {
            char[] chars = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            int firstVowel = input.IndexOfAny(chars);
            if(firstVowel == -1)
            {
                char[] charsy = { 'y', 'Y' };
                int yAsAVowel = input.IndexOfAny(charsy);
                return input.Substring(yAsAVowel) + input.Substring(0, yAsAVowel) + "ay";
            } else
            {
                if(firstVowel == 0)
                {
                    bool lastLetterVowel = input.EndsWith("a") || input.EndsWith("e") || input.EndsWith("i") || input.EndsWith("o") || input.EndsWith("u");
                    if(lastLetterVowel == true) {
                        return input.Substring(firstVowel) + input.Substring(0, firstVowel) + "yay";
                    } else
                    {
                        return input.Substring(firstVowel) + input.Substring(0, firstVowel) + "ay";
                    }
                } else
                {
                    return input.Substring(firstVowel) + input.Substring(0, firstVowel) + "ay";
                }
            }

            
            Console.Read();
        }
    }
}
