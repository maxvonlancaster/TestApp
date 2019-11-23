using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using static System.DayOfWeek;
using static System.Math;

namespace KnowledgeModel.Lang
{
    public class LangQ
    {
        // Static using -> allows all the accessible static members of a type to be imported, making them available without qualification in subseq. code.
        // great if you have a set of functions related to certain domain
        public void StaticUsing()
        {
            WriteLine(Sqrt(5));
            WriteLine(Friday - Monday);
        }
    }
}
