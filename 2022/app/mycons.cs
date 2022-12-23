namespace MyConsole
{
    class Program {         
        static void Main(string[] args)
        {
            Rangescs.Program.Main(args);
            string filepath = "input4_test.txt";
            string[] lines = System.IO.File.ReadAllLines(@filepath);
            List<Range> ranges = new List<Range>(); 
            int count = 0; 

            for (int i = 0; i < lines.Length; i++){
                Console.WriteLine(lines[i]);
                string line = lines[i].Split(",");
                int r1l = Int32.Parse(line.Split("-")[0]);
                int r1u = Int32.Parse(line.Split("-")[1]);
                int r2l = Int32.Parse(line.Split("-")[2]);
                int r2u = Int32.Parse(line.Split("-")[3]);
                range rng = range(r1l, r1u, r2l, r2u);
                ranges.Add(rng);
                bool chk = rng.check_contained();
                if(chk == true){
                    count += 1; 
                }
            }
        Console.WriteLine(count);

        }
        }

}