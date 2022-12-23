 namespace Ranges {
    public class Range 
    {

        private int range1_l;
        private int range1_u;
        private int range2_l;
        private int range2_u ;

        public void Range(int r1l, int r1u, int r2l, int r2u){
            range1_l = r1l;
            range1_u = r1u;
            range2_l = r2l;
            range2_u = r2u;
        }

        public bool check_contained(){
            if ( (range1_l<range2_l && range1_u>range2_u) || (range1_l>range2_l && range1_u<range2_u)){
                return true;
            }
            else {
                return false; 
            }
        }





    }
}