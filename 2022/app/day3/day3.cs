namespace day3
{
    class mainClass  {         
        static void Main(string[] args)
        {
            string filepath = "input3.txt";
            string[] lines = System.IO.File.ReadAllLines(@filepath);
            List<string> firstlines = new List<string>();
            List<string> secondlines = new List<string>();
            List<HashSet<string>> firsthashes = new List<HashSet<string>>(); 
            List<HashSet<string>> secondhashes = new List<HashSet<string>>(); 
            List<string> priorities = new List<string>();
            List<string> binaries = new List<string>();
            int count = 0; 
            

            for(int i=0; i< lines.Length; i++){
                string firststring = lines[i].Substring(0, lines[i].Length/2);
                string secondstring = lines[i].Substring(lines[i].Length/2,lines[i].Length/2);
                firstlines.Add(firststring);
                secondlines.Add(secondstring);
                HashSet<string> fhash = new HashSet<string>();
                for (int j=0; j<firststring.Length; j++){
                    fhash.Add(firststring[j].ToString());
                }
                HashSet<string> shash = new HashSet<string>();
                List<char> checklist = new List<char>();
                for (int k=0; k<secondstring.Length; k++){
                    bool check = fhash.Contains(secondstring[k].ToString());
                    if (check == true && checklist.Contains(secondstring[k]) == false){
                        int num = calcPriority(secondstring[k]);
                        priorities.Add(num + " " + secondstring[k]);
                        count = count + num;
                        checklist.Add(secondstring[k]);

                    }
                    shash.Add(secondstring[k].ToString());
                }
            }

            for(int m=0; m< lines.Length-2; m+=3){
            string bin1 = convertToBin(lines[m]);
            string bin2 = convertToBin(lines[m+1]);
            string bin3 = convertToBin(lines[m+2]);
            string outbinstr = addTwo(addTwo(bin1, bin2), bin3);
            binaries.Add(outbinstr);
            }
            int priors = 0; 
            string comparison = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int n=0; n<binaries.Count; n++){
                int ind = binaries[n].IndexOf("3");
                priors += ind+1; 
            }

        binaries.ForEach(Console.WriteLine);
        Console.WriteLine("Part 2: " + priors);
        } 


    static int calcPriority(char c){
        int index = (int)c % 32;
        if (char.ToUpper(c) == c){
            index = index + 26;
        }
        return index;

    } 

    static string convertToBin(string inp){
        string comparison = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string comparisonbit = "0000000000000000000000000000000000000000000000000000";
        Console.WriteLine(inp);
            for(int i = 0; i<inp.Length; i++){
              int pos = comparison.IndexOf(inp[i]);
              int currval = Int32.Parse(comparisonbit.Substring(pos, 1)) + 1;
              if (currval > 0){
                currval = 1; 
              }
              string currvalstring = currval.ToString(); 
              comparisonbit = increment(comparisonbit, pos, currvalstring);
        }
        return comparisonbit;

    }

    static string increment(string input, int index, string value){
        string firststring = input.Substring(0, index);
        string middlestring = input.Substring(index, 1);
        string secondstring = input.Substring(index+1, input.Length-index-1);
        string newstring = firststring + value + secondstring;
       // Console.WriteLine("F:" + firststring + " second: " + secondstring + " Middle " + middlestring +" New string " +  newstring);
        return newstring;

    }

    static string addTwo(string bin1, string bin2){
        string outbin = "";
        for (int i = 0; i < bin1.Length; i++){
            int int1 = Int32.Parse(bin1.Substring(i, 1));
            int int2 = Int32.Parse(bin2.Substring(i, 1));
            string int3 = (int1 + int2).ToString();
            // Console.WriteLine("" + i + outbin.Length + " " + outbin);
            outbin = outbin.Substring(0, outbin.Length) + int3; 
        }
        return outbin; 
    }

    }
}