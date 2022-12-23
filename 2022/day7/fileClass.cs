namespace MyConsole
{
    public class FileClass
    {
        public List<string> addr; 
        public int size; 
        public bool isDir; 
        public string stringaddr;
        public int finalsize;
        public FileClass(List<string> address, int sz, bool isD)
        {
            addr=address;
            size = sz;
            isDir = isD;
            stringaddr = string.Join("-", address);
        }

    }
}