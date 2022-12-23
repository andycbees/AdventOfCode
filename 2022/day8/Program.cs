namespace MyConsole
{
    class Day8
    {
        static void Main()
        {   
            System.Console.WriteLine("start");
            string filepath = "input.txt";
            string raw = System.IO.File.ReadAllText(filepath);
            List<char> chararry = raw.Replace("\n", "").Replace("\r", "").ToList(); 
            string[] lines = raw.Split("\n");
            int linnum = lines.Length; 
            int width = raw.Replace("\n", "").Replace("\r", "").Length/lines.Length;
            Tree[,] Trees = new Tree[width, linnum];

            for(int i = 0; i<linnum; i++)
            {
                for(int j = 0; j<width; j++)
                {   
                    Trees[j,i] = new Tree(j, i);
                    string curval =  chararry[j + i*linnum].ToString();
                    // System.Console.WriteLine("ch: " + curval);
                    Trees[j, i].height = Int32.Parse(curval); 
                }

            }
            
            for(int k = 0; k < linnum; k++)
            {
                for(int n = 0; n < width; n++)
                {
                    int currval = Trees[n, k].height; 
                    int updiscalc = 0; 
                    int downdiscalc = 0; 
                    int leftdiscalc = 0; 
                    int rightdiscalc = 0; 

                    for(int m = 1; m <= n; m++)
                    {
                        int check = Trees[n-m, k].height;
                        leftdiscalc += 1;
                        if(check >= currval){
                            Trees[n,k].leftvis = false; 
                            break;
                            // System.Console.WriteLine("Fail m: "  + m  + " Writing at: " + n + " " + k);
                        }
                    }

                    for(int p = n+1; p < width; p++)
                    {   
                        rightdiscalc += 1;
                        int check = Trees[p, k].height;
                        if(check >= currval){
                            Trees[n,k].rightvis = false; 
                            // System.Console.WriteLine("Fail p: "  + p  + "Writing at: " + n + " " + k);
                            break;
                        }
                    }

                    for(int q = 1; q <= k ; q++)
                    {   
                        updiscalc += 1;
                        int check = Trees[n, k - q ].height;
                        if(check >= currval){
                            Trees[n, k].upvis = false; 
                            // System.Console.WriteLine("Fail q: "  + q );
                            break;
                        }
                    }

                    for(int r = k+1; r < linnum; r++)
                    {
                        downdiscalc += 1;
                        int check = Trees[n, r].height;
                        if(check >= currval || Trees[n, r].downvis == false){
                            Trees[n,k].downvis = false;
                            // System.Console.WriteLine("Fail r: "  + r );
                        break;
                        }
                    }
                    
                    Trees[n,k].updis = updiscalc;
                    Trees[n,k].downdis = downdiscalc;
                    Trees[n,k].leftdis = leftdiscalc;
                    Trees[n,k].rightdis = rightdiscalc;



                }
            }

            int counter = 0;
            List<string> outlines = new List<string>(); 
            List<string> outlinescsv = new List<string>(); 
            int currenthighest = 0; 
            // System.Console.WriteLine("Test tree:" + Trees[4,1].upvis + " "+ Trees[4,1].downvis + " "+ Trees[4,1].leftvis + " "+ Trees[4,1].rightvis);
            for(int t = 0; t<linnum; t++)
            {
                string outline = "";
                string outlinecsv = "";
                for(int s = 0; s<width; s++)
                {       
                    Tree tree_ = Trees[s,t]; 
                    int scene = tree_.updis * tree_.downdis * tree_.rightdis * tree_.leftdis;
                    tree_.scenicval = scene; 
                    if(tree_.upvis == false && tree_.downvis == false && tree_.leftvis == false && tree_.rightvis == false)
                    {
                        // System.Console.WriteLine("HERE");
                        outline = outline + "N";
                        outlinecsv = outlinecsv + "N,";
                    }
                    else
                    {
                        counter += 1;
                        outline = outline + tree_.height;
                        outlinecsv = outlinecsv + tree_.height +",";
                    }
                    if(scene > currenthighest){
                        currenthighest = scene; 
                    }
                }
                outlines.Add(outline);
                outlinescsv.Add(outlinecsv);
            }      

            string outdata = string.Join("\n", outlines);
            string outdatacsv = string.Join("\n", outlinescsv);
            File.WriteAllText("output.txt", outdata);
            File.WriteAllText("output2.csv", outdatacsv);

            System.Console.WriteLine("Counter: " + counter);
            System.Console.WriteLine("Scenic: " + currenthighest);
            }
        }

}