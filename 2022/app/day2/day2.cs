// Hello World! program
namespace HelloWorld
{
    class Hello {         
        static void Main_day2(string[] args)
        {
         


            FileStream fs = new FileStream ("input2.txt", FileMode.Open, FileAccess.Read, FileShare.Read); 
            StreamReader sr = new StreamReader(fs);

            var dictionary = new Dictionary<string, int>();
            // A ROCK, B Paper, C Scissors
            // X ROCK, Y PAPER, Z SCISSORS
            dictionary.Add("X", 1);
            dictionary.Add("Y", 2);
            dictionary.Add("Z", 3); 


            var input = sr.ReadToEnd();
            var inputlines = input.Split("\n");
            List<int> winloss = new List<int>();
            int count = 0; 
            int secondcount = 0; 
    
            for (int i = 0; i < inputlines.Length; i++){

                string line = inputlines[i].Replace(" ", "").Replace("\n", "").Replace("\r", "");
                string first = line[0].ToString();
                string second = line[line.Length-1].ToString();
                // Console.WriteLine(line);
                if( (first == "A" && second == "Z") || (first == "B" && second == "X") || (first == "C" && second == "Y") ){
                count = count + dictionary[second]; 
                }
                if ( (first == "A" && second == "X") || (first == "B" && second == "Y") || (first == "C" && second == "Z") ){
                    count = count + 3 + dictionary[second];
                }

                if ( (first == "A" && second == "Y") || (first == "B" && second == "Z") || (first == "C" && second == "X") ){
                    count = count + 6 + dictionary[second];
                }

                if( second == "X"){
                    //lose
                    if(first == "A"){
                        secondcount = secondcount + 3;
                    }
                    if(first == "B"){
                        secondcount = secondcount + 1;
                    }
                    if(first == "C"){
                        secondcount = secondcount + 2;
                    }

                }

                if( second == "Y"){
                  //draw
                    if(first == "A"){
                        secondcount = secondcount + 1 + 3;
                    }
                    if(first == "B"){
                        secondcount = secondcount + 2  + 3;
                    }
                    if(first == "C"){
                        secondcount = secondcount + 3  + 3;
                    }
                }

                if( second == "Z"){
                 //win
                    if(first == "A"){
                        secondcount = secondcount + 2 + 6;
                    }
                    if(first == "B"){
                        secondcount = secondcount + 3  + 6;
                    }
                    if(first == "C"){
                        secondcount = secondcount + 1  + 6;
                    }
                }
            Console.WriteLine("Count:" + secondcount); 


            }


            Console.WriteLine(count);
            Console.WriteLine(secondcount);
 
        }    
    } 
}