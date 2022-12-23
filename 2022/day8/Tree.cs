namespace MyConsole
{
    public class Tree
    {
    
    public bool upvis;
    public bool downvis;
    public bool leftvis;
    public bool rightvis;
    public int updis;
    public int downdis;
    public int leftdis;
    public int rightdis;
    public int scenicval; 
    public int xloc;
    public int yloc;
    public bool visited; 
    public int height; 

        public Tree(int i, int j)
        {
            xloc = i; 
            yloc = j ;
            upvis = true; 
            downvis = true; 
            leftvis = true; 
            rightvis = true; 
        }

        public void set_visibity(string dir, bool vis)
        {
            if(dir == "up")
            {
                upvis = vis; 
            }
            if(dir == "down")
            {
                downvis = vis; 
            }
            if(dir == "left")
            {
                leftvis = vis; 
            }
            if(dir == "right")
            {
                rightvis = vis; 
            }
        }

        public int getHeight()
        {
            return height;
        }

    }
}