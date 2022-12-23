namespace MyConsole
{
    class Day7{
        static void Main()
        {
            string filepath = "input7.txt";
            string[] raw = System.IO.File.ReadAllLines(filepath);
            List<string> curr_path = new List<string>() ; 
            List<FileClass> Files = new List<FileClass>();
            bool lsval = false; 
            foreach(var line in raw)
            {
                // System.Console.WriteLine(line);
                string[] splitline = line.Split(" ");
                // System.Console.WriteLine(string.Join("",line).ToString());
                if(splitline[0] == "$")
                {
                    string instruction = splitline[1];
                    if(instruction == "cd")
                    {   
                        lsval = false;
                        if(splitline[2] == "..")
                        {
                            curr_path = curr_path.GetRange(0, curr_path.Count-1);
                        }
                        else
                        {
                            curr_path.Add(splitline[2]);
                        }
                        // System.Console.WriteLine("Path change:" + string.Join("-",curr_path));
                    }

                    if(instruction == "ls")
                    {  
                        lsval = true; 
                    }
                }

                if(lsval==true && splitline[0] != "$")
                {
                    if(splitline[0] == "dir"){
                        List<string> temp = new List<string>(curr_path);
                        temp.Add(splitline[1]);
                        FileClass File_ = new FileClass(temp, 0, true);
                        Files.Add(File_);

                    }
                    else
                    {
                        List<string> temp = new List<string>(curr_path);
                        temp.Add(splitline[1]);
                        FileClass File_ = new FileClass(temp, Int32.Parse(splitline[0]), false);
                        Files.Add(File_);
                    }
                
                }
            }
            // System.Console.WriteLine("\n");
            int part1 = 0; 
            int part2 = 0; 
            List<FileClass> outlist = new List<FileClass>(); 
            List<string> outnames = new List<string>(); 
            foreach (var f in Files)
            {       
               f.finalsize = FindSizes(Files, f.addr); 
                if(f.finalsize <= 100000 && f.isDir==true)
                {   
                    outlist.Add(f);
                    outnames.Add(f.stringaddr);
                    // System.Console.WriteLine(f.stringaddr + " : " + f.finalsize);
                }
                // System.Console.WriteLine("Path: " +string.Join("/",f.addr) + " Size: " + f.size.ToString());
            }

          // outnames = FilterDirs(outnames);
            foreach (var name in outnames)
            {                System.Console.WriteLine("only these: " + name);
                part1 += outlist.Where(i => i.stringaddr == name).First().finalsize;
            }


         System.Console.WriteLine("part 1: " + part1);
        
        foreach (var item in Files.GetRange(0,10))
        {
            part2 += item.finalsize;
        }

        part2 = 70000000-part2; 
        List<int> todel = new List<int>();
        foreach (var f in Files)
                        {       
                        f.finalsize = FindSizes(Files, f.addr); 
                            if(f.finalsize >= 30000000-part2 && f.isDir==true)
                            {   
                               todel.Add(f.finalsize);
                            }
                            // System.Console.WriteLine("Path: " +string.Join("/",f.addr) + " Size: " + f.size.ToString());
                        }

        var result = todel.OrderBy(x => x).First();
        int newout = result + part2; 
        
         System.Console.WriteLine("part 2: " + result + " " + newout);



        }

        static int FindSizes(List<FileClass> Files, List<string> path){
            string comparison = string.Join("-", path);
            int sizecount = 0; 
            // System.Console.WriteLine("new find size with top level " + comparison);
            foreach (var f in Files)
            {
                if((f.stringaddr.Contains(comparison) == true) && (f.stringaddr != comparison))
                {   
                    // System.Console.WriteLine("Comparison: " + f.stringaddr + " " + comparison);
                    if(f.isDir == false)
                    {
                        sizecount += f.size;
                    }
                    else
                    {
                        //sizecount += FindSizes(Files, f.addr);
                    }
                }
            }
            return sizecount;
        }

        static List<string> FilterDirs(List<string> filepaths){
            List<string> outlist = new List<string>(filepaths); 
            foreach (var file in filepaths)
            {
                List<int> index = new List<int>();
                foreach (var otherfile in outlist)
                {
                    if(otherfile.Contains(file) && otherfile != file){
                        index.Add(outlist.IndexOf(otherfile));
                    }
                }

                List<string> newoutlist = new List<string>();
                for(int i = 0; i<outlist.Count; i++){
                    if(!index.Contains(i)){
                        newoutlist.Add(outlist[i]);
                    }
                }

                outlist = new List<string>(newoutlist);

            }
            return outlist;
        }
    }
}