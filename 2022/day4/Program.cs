namespace MyConsole
{
    class Day4 {         
        static void Main(string[] args)
        {
            string filepath = "input4.txt";
            string[] lines = System.IO.File.ReadAllLines(@filepath);
            List<Range> ranges = new List<Range>(); 
            int count = 0; 
            int count2 = 0; 

            for (int i = 0; i < lines.Length; i++){
                string line = lines[i];
                string[] linesplit = String.Concat(line).Split(",");
                int r1l = Int32.Parse(String.Concat(linesplit[0]).Split("-")[0]);
                int r1u = Int32.Parse(String.Concat(linesplit[0]).Split("-")[1]);
                int r2l = Int32.Parse(String.Concat(linesplit[1]).Split("-")[0]);
                int r2u = Int32.Parse(String.Concat(linesplit[1]).Split("-")[1]);
                Range rng = new Range(r1l, r1u, r2l, r2u);
                ranges.Add(rng);
                bool chk = rng.check_contained();
                if(chk == true){
                    count += 1; 
                    // Console.WriteLine(line);
                }

                bool chk2 = rng.check_overlap();
                if(chk2 == true){
                    count2 += 1;
                    Console.WriteLine(line);

                }
            }
        Console.WriteLine(count);
        Console.WriteLine(count2);

        }
        }

}