using System.Text;

namespace MyConsole {
    class day5{
        static void Main(){
            
            string filepath = "input5.txt";
            string raw = System.IO.File.ReadAllText(filepath);
            string[] stacksraw = raw.Split("\n\n")[0].Split("\n");
            string[] instructionsraw = raw.Split("\n\n")[1].Split("\n");

            char[] stackindex = stacksraw[stacksraw.Length-1].ToCharArray();
            var stacks = new Dictionary<string, List<string>>();
            for (int i = 0; i < stackindex.Length; i++){
                if (stackindex[i] != ' ' && stackindex[i] != '\n' && stackindex[i] != '\r' ){
                    for(int j = 0; j < stacksraw.Length-1; j++){
                        char[] temp = stacksraw[j].ToCharArray();
                        if (temp[i] != ' '){
                            if(!stacks.ContainsKey(stackindex[i].ToString())){
                                List<string> templist = new List<string>();
                                templist.Add(temp[i].ToString());
                                stacks.Add(stackindex[i].ToString(), templist);
                            }
                            else{
                                stacks[stackindex[i].ToString()].Add(temp[i].ToString());
                            }
                        }
                    }
                }

            }

            foreach (var item in stacks)
            {
                stacks[item.Key].Reverse(); 
            }

            // foreach (var item in instructionsraw)
            // {
            //     System.Console.WriteLine(item);
            // }



            List<int[]> instructions = new List<int[]>();
            foreach( var line in instructionsraw){
                string delim1 = "move ";
                string delim2 = "from ";
                string delim3 = "to ";
                int ind1 = line.IndexOf(delim1);
                int ind2 = line.IndexOf(delim2);
                int ind3 = line.IndexOf(delim3);
                System.Console.WriteLine(line);
                int instr1 = Int32.Parse(line.Substring(ind1+delim1.Length, 2).Replace(" ", ""));
                int instr2 = Int32.Parse(line.Substring(ind2+delim2.Length, 2).Replace(" ", ""));
                int instr3 = Int32.Parse(line.Substring(ind3+delim3.Length,line.Length-(ind3+delim3.Length) ).Replace(" ", ""));
                int[] instr4 = {instr1, instr2, instr3};
                instructions.Add(instr4);

            }

            foreach (var instr in instructions)
            {
            System.Console.WriteLine("Move " + instr[0] + " from " + instr[1]  + " to " + instr[2]);
                            foreach (var item in stacks)
                                {
                                var result = String.Join(" ", item.Value.ToArray());
                                System.Console.WriteLine(item.Key +" " + result);
                                }

                string from = instr[1].ToString();
                string to = instr[2].ToString();
                int count = instr[0];

                List<string> moving = stacks[from].GetRange(stacks[from].Count-count, count);
                //moving.Reverse(); 
                for(int i = 0; i < moving.Count; i++){
                    stacks[from].RemoveAt(stacks[from].Count-1);
                    stacks[to].Add(moving[i]);
                }

            }


            List<string> output = new List<string>(); 
            foreach (var item in stacks)
            {
            var result = String.Join(" ", item.Value.ToArray());
            output.Add(result.ToCharArray()[result.Length-1].ToString());
            System.Console.WriteLine(item.Key +" " + result);
            }

            foreach (var ins in instructions)
            {
                System.Console.WriteLine("Ins ");
                foreach (var inty in ins)
                {
                    System.Console.WriteLine(inty);

                }
            }

            System.Console.WriteLine("output: " + string.Join("",output));

        }


    }
}