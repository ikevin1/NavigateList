using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp1
{
    public class Quizy
    {
        public string Ask { get; private set; }
        public string TrueQ { get; private set; }
        public string FalseQ { get; private set; }
        public int TruePoint { get; private set; }
        public int FalsePoint { get; private set; }
        
        
        public Quizy(string ask, string trueQ, string falseQ, int falsePoint, int truePoint)
        {
            Ask = ask;
            TrueQ = trueQ;
            FalseQ = falseQ;
            TruePoint = truePoint;
            FalsePoint = falsePoint;            
        }

        private  Quizy()
        {

        }
        static Quizy()
        {
            //IList<Quizy> Quiz = new List<Quizy>;
               Play = new List<Quizy>
               
            {
                
                new Quizy("What does a dog do?", "A.  bark", "B.  quack", 5, 0),
                new Quizy("what color is the sky", "A.  red", "B.  blue?", 0, 8),
                new Quizy("What does a duck do?", "A.  quack", "B.   bark", 5, 0),
                new Quizy("January has how many weeks", "A.  7 weeks", "B.  4 weeks", 0, 4),
                new Quizy("Wha color do you see first viewing WCTC logo?", "A.  Blue", "B.  Red", 4, 0),
                new Quizy("Medical teams are Hero?", "A.  Yes", "B.  No", 40, 4),
                new Quizy("March has how many days?", "A.  45", "B.  31", 0, 11)
            };
            
        }

        public static IList<Quizy> Play { private set; get; }
        //public string Show { get; internal set; }

        //public string Show
        //{

        //    get
        //    {
        //        string Ask = Quizy.Ask;
        //        string TrueQ = Quizy.TrueQ;
        //        string FalseQ = Quizy.FalseQ;
        //        return string.Format("{0}  \n A. {1}           B. {2}", Ask, TrueQ, FalseQ);
        //    }
        //}
    }
}
