using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace DIS_Assignment2_Mukul
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        //Answer 1
        public static int SearchInsert(int[] nums1, int target)
        {
            try
            {
                Array.Sort(nums1);//sorting the nums1 array
                int length = nums1.Length; //taking the length of the nums1 array
                int mid = length / 2; //calculating the middle position of the length
                if (length == 0 && nums1[0] >= target) 
                {
                    return 0; //if length is equivalent to 0 and nums1[0] is greater than return the first index
                }
                else if (nums1[length - 1] == target)
                {
                    return length - 1; //if nums1[length - 1] is equivalent to target than return the length - 1 position
                }
                else if (nums1[length - 1] < target) //
                {
                    return length; //if nums1[length - 1] is less to target than return the length position
                }
                else if (nums1[mid] == target)
                {
                    return mid; //if target is equal to the center then  return the center position
                }
                else if (nums1[mid] < target && nums1[mid + 1] > target)
                {
                    return mid + 1; //if target is less to the center and nums1[mid +1] then  return the center +1 position
                }
                else
                {
                    return length;// else return the length
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Answer 2
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.
                char[] delimiterChars = { ' ', ',', '.', ':', '?', ';', '"', ';' }; //storing the delimeterchars
                string[] words = paragraph.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);//spliting the paragraph based on the delimeter characters and removing the empty entries
                int count = 0; //initalizing the count as 0
                Dictionary<string, int> dict = new Dictionary<string, int>(); //creating a dictonary
                HashSet<string> bann = new HashSet<string>(); //creating a hashset to store the banned words
                string output = "";
                foreach (var x in banned)
                {
                    bann.Add(x); //for all the variables x add it to hashset 
                }
                foreach (var y in words)
                {
                    string word = y.ToLower(); //for each variable y convert it to lower and store in the word
                    if (bann.Contains(word)) //if hashset containes word
                    {
                        continue; //just continue and don't do anything
                    }
                    dict.TryAdd(word, 0); //add the word to the dict
                    dict[word]++; //increase the position of word to next word
                }
                foreach (var kv in dict) //for variable kv present in dictonary 
                {
                    if (kv.Value > count) //check if variable value is greater than count
                    {
                        count = kv.Value; //in count store variavle value
                        output = kv.Key; //store the variable key
                    }
                }

                return output;//return the output
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Answer 3
        public static int FindLucky(int[] arr)
        {
            try
            {
                int count = -1; //Initalizing the count to -1
                Dictionary<int, int> dict = new Dictionary<int, int>();//creating a dictonary
                foreach (int n in arr)// for each variable n in integer array arr
                {
                    if (dict.ContainsKey(n))//if dictonary contains the variable n
                    {
                        dict[n] += 1; //dictonary will be dictonary + 1
                    }
                    else
                    {
                        dict.Add(n, 1); //else ass the variable to the dictonary 
                    }
                }
                foreach (KeyValuePair<int, int> kv in dict)// checking the key value pair in dictonary
                {
                    if (kv.Value == kv.Key && kv.Value > count)//if kv value is equivalent to key and kv value is greater then count
                    {
                        count = kv.Value; // count will be kv value
                    }
                }

                return count;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Answer 4

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int b = 0, c = 0; //initializing the bulls and cows
                Dictionary<char, int> dict = new Dictionary<char, int>();//create a new dictonary
                int s = secret.Length; int g = guess.Length;//taking the s as the secret length and g as guess length
                for (int i = 0; i < s; i++)//iterating the i on the secret length
                {
                    char sec = secret[i];//initalizing sec for secret's indexes
                    if (!dict.ContainsKey(sec))//if dictonary doesn't contain the secret index
                    {
                        dict.Add(sec, 1);//add that character to the dictonary
                    }
                    else
                    {
                        dict[sec]++; //else increase the secret's index in the dictonary
                    }
                }
                for (int j = 0; j < g; j++)//iterating the j over the guess length
                {
                    if (secret[j] == guess[j])//if secret of the j and guess of j is equivalent
                    {
                        b++; //increse the count of the bulls
                        dict[guess[j]]--;//decrease the position of guess[j] in the dictonary
                    }

                }
                for (int k = 0; k < g; k++) //iterating the k over the guess length
                {
                    if (dict.ContainsKey(guess[k]) && dict[guess[k]] > 0 && secret[k] != guess[k])//if dictonary contains guess[k] and dictonary guess[k] is greater than 0 and secret of k is not equivalent to guess[k] 
                    {
                        c++;//increase the count of cows
                        dict[guess[k]]--;//decrease the position of guess[j] in the dictonary
                    }
                }

                return (b + "A" + c + "B");//return the output
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Answer 5
        public static List<int> PartitionLabels(string s)
        {
            try
            {
                var news = new int[100];//creating a variable new to store the new integers of length 100
                var list = new List<int>();//creating a new variable list which will convert the values inside it in the form of list
                int a = 0, z = 0;//initalizing the starting as a and ending as z to 0
                for (int i = 0; i < s.Length; i++)//iterating the i till the string s length
                {
                    news[s[i] - 'a'] = i; //calculating the variable news and storing it to i
                }
                for (int j = 0; j < s.Length; j++)//iterating the j till the sting s length
                {
                    z = Math.Max(z, news[s[j] - 'a']);//Calculating the end position using Math max function
                    if (z == j) // if end is equivalent to the j
                    {
                        list.Add(z - a + 1);//add it in the list
                        a = j + 1;//calculate the a
                    }
                }


                return list;//return the list
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Answer 6

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int w = 0, l = 1;// Initalizing the width as 0 and line as 1
                foreach (char i in s)//itearting the i in the complete string
                {
                    w = w + widths[i - 'a'];//calculating the width
                    if (w > 100)//if width is greater than 100
                    {
                        l++; //increae the count of line
                        w = widths[i - 'a'];//calculate the width
                    }
                }

                return new List<int>() { l, w };//return the line and width in a list
            }
            catch (Exception)
            {
                throw;
            }

        }



        //Answer 7
        public static bool IsValid(string bulls_string10)
        {
            try
            {
                char[] delimiterChars = { '(', '{', '[' };//Storing the delimeter characters in a character array
                Dictionary<char, char> dict = new Dictionary<char, char>();//creating a new dictonary
                dict.Add('{', '}');//Adding the required brackets
                dict.Add('(', ')');
                dict.Add('[', ']');
                List<char> list = new List<char>(); //creating a new lisy
                foreach (char x in bulls_string10)//iterating the x over the bull string 10
                {
                    if (!delimiterChars.Contains(x))//if delimeter character doesn't contain x
                    {
                        if (list.Count != 0)//if the list count is not euivalent to 0
                        {
                            int count = list.Count; //initializing the integer variable count
                            char i = list[count - 1]; // initalizing the character variable i
                            list.RemoveAt(count - 1);//removing the value from list whereat count -1
                            if (x != dict[i]) //if x is not equivalent to value of the ith position
                            {
                                return false; //return false as dictonary values is not correct
                            }

                        }
                        else
                        {
                            return false;//return false as the dictonary is not correct
                        }

                    }
                    else
                    {

                        list.Add(x);//else add it to the list 
                    }

                }
                if (list.Count == 0)
                {
                    return true;//if list count is equivalent to 0 then return true
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }


        }

        //Answer 8
        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string[] m = {".-", "-...", "-.-.", "-..", ".", "..-.", "--.",
                 "....", "..", ".---", "-.-", ".-..", "--", "-.",
                 "---", ".--.", "--.-", ".-.", "...", "-", "..-",
                 "...-", ".--", "-..-", "-.--", "--.." };// storing the morse values in the string
                Dictionary<String, int> dict = new Dictionary<String, int>(); //creating a new dictonary
                foreach (string word in words)//iterating the string word in the words
                {
                    String a = "";//initalizing an empty string
                    foreach (Char c in word)//iterating the character c in the word
                    {
                        a += m[c - 'a'];//calculating the value of a
                    }
                    if (!dict.ContainsKey(a)) //if dictonary doiesn't conatin a
                    {
                        dict[a] = 1;//dictonary of a will be 1

                    }
                    else
                    {
                        dict[a] = dict[a] + 1;//else dictonary of a will be dictonary of a +1
                    }
                }

                return dict.Count();//return the count of values the dictonary
            }
            catch (Exception)
            {
                throw;
            }


        }

        //Answer 9

    }
}
