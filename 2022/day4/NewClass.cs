 namespace MyConsole {
    public class Range 
    {

        private int range1_l;
        private int range1_u;
        private int range2_l;
        private int range2_u ;
        private int dif_l;
        private int dif_u;
        private int r1l;
        private int r1u;
        private int r2l;
        private int r2u;

        public Range(int r1l, int r1u, int r2l, int r2u)
        {
            range1_l = r1l;
            range1_u = r1u;
            range2_l = r2l;
            range2_u = r2u;
        }

        public bool check_contained(){
            if ( (range1_l<=range2_l && range1_u>=range2_u) || (range1_l>=range2_l && range1_u<=range2_u)){
                return true;
            }
            else {
                return false; 
            }
        }

        public bool check_overlap(){
            if ( range1_u >= range2_l && range2_u >= range1_l ){
                return true;
            }
            else{
                return false; 
            }


        }





    }
}