namespace MyConsole
{
    class Day6{
        static void Main(){
            
            string filepath = "input6.txt";
            string raw = System.IO.File.ReadAllText(filepath);
            System.Console.WriteLine(raw);
            int count = 0; 
            bool setbreak = false;
            for(int i = 13; i < raw.Length; i++)
            {   
                if(setbreak == true){
                    break;
                }
                List<string> chars = new List<string>(); 
                for(int j = 0; j<14; j++){
                    chars.Add(raw.ToCharArray()[j-(13-i)].ToString());
                }
                
                for(int k = 0; k < chars.Count; k++){
                    List<string> temp = chars.GetRange(0, k);
                    List<string> temp2 = chars.GetRange(k+1, chars.Count-k-1);
                    List<string> temp3 = temp.Concat(temp2).ToList();
                    if(!temp3.Contains(chars[k])){
                        if(k==chars.Count-1){
                            count = i+1;
                            setbreak = true; 
                            break;
                        }
                    }
                    else{
                         break;
                    }

                }
            }


            System.Console.WriteLine("Part 1: " + count);
        }
    }
}
