using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegExLab_A
{
    //class Program
    //{
    //    static String searchPatt = @"a+b{2,}c+";
    //    static String replacePatt = "QQQ";
    //    static void Main(string[] args)
    //    {
    //        String str = Console.ReadLine();
    //        while (str != null)
    //        {
    //            String newStr = Regex.Replace(str, searchPatt, replacePatt);
    //            Console.WriteLine(newStr);
    //            str = Console.ReadLine();
    //        }
    //    }
    //}
    //class Program
    //{
    //    static String searchPatt = @"([a-z])([A-Z])";
    //    static String replacePatt = "_?_$1$2_?_";
    //    static void Main(string[] args)
    //    {
    //        String str = Console.ReadLine();
    //        while (str != null)
    //        {
    //            String newStr = System.Text.RegularExpressions.Regex.Replace(str, searchPatt, replacePatt);
    //            Console.WriteLine(newStr);
    //            str = Console.ReadLine();
    //        }
    //    }
    //}
    //class Program
    //{
    //    static String searchPatt = @"\$v_([a-zA-Z0-9])\$";
    //    static String replacePatt = "v[$1]";
    //    static void Main(string[] args)
    //    {
    //        String str = Console.ReadLine();
    //        while (str != null)
    //        {
    //            String newStr = System.Text.RegularExpressions.Regex.Replace(str, searchPatt, replacePatt);
    //            Console.WriteLine(newStr);
    //            str = Console.ReadLine();
    //        }
    //    }
    //}
    //class Program
    //{
    //    static String searchPatt = @"\$v_\{([a-zA-Z\d]*)\}\$";
    //    static String replacePatt = "v[$1]";
    //    static void Main(string[] args)
    //    {
    //        String str = Console.ReadLine();
    //        while (str != null)
    //        {
    //            String newStr = System.Text.RegularExpressions.Regex.Replace(str, searchPatt, replacePatt);
    //            Console.WriteLine(newStr);
    //            str = Console.ReadLine();
    //        }
    //    }
    //}
    //class Program
    //{
    //    static String searchPatt = @"\$v_\{([a-zA-Z\d]*)\}\$|\$v_([a-zA-Z0-9])\$";
    //    static String replacePatt = "v[$1$2]";
    //    static void Main(string[] args)
    //    {
    //        String str = Console.ReadLine();
    //        while (str != null)
    //        {
    //            String newStr = System.Text.RegularExpressions.Regex.Replace(str, searchPatt, replacePatt);
    //            Console.WriteLine(newStr);
    //            str = Console.ReadLine();
    //        }
    //    }
    //}
    //class Program
    //{
    //    static String searchPatt = @"\\texttt\{([a-zA-Z]+|[\d]+)\}"; // modify regex here...
    //    static String replacePatt = @"\begin{ttfamily}$1\end{ttfamily}"; // ...and here
    //    static void Main(string[] args)
    //    {
    //        String str = Console.ReadLine();
    //        while (str != null)
    //        {
    //            String newStr = System.Text.RegularExpressions.Regex.Replace(str, searchPatt, replacePatt);
    //            Console.WriteLine(newStr);
    //            str = Console.ReadLine();
    //        }
    //    }
    //}
    //class Program
    //{
    //    static String searchPatt = @"(?:[A-Z][A-Za-z]*\s{1,}){2,}[A-Z][A-Za-z]*"; // modify regex here...
    //    static String replacePatt = "\"$0\""; // ...and here
    //    static void Main(string[] args)
    //    {
    //        String str = Console.ReadLine();
    //        while (str != null)
    //        {
    //            String newStr = System.Text.RegularExpressions.Regex.Replace(str, searchPatt, replacePatt);
    //            Console.WriteLine(newStr);
    //            str = Console.ReadLine();
    //        }
    //    }
    //}
    class Program
    {
        static String searchPatt = @"\\circle\{\((\d+),(\d+)\)"; // modify regex here...
        static String replacePatt = @"\circle{($2,$1)"; // ...and here
        static void Main(string[] args)
        {
            String str = Console.ReadLine();
            while (str != null)
            {
                String newStr = System.Text.RegularExpressions.Regex.Replace(str, searchPatt, replacePatt);
                Console.WriteLine(newStr);
                str = Console.ReadLine();
            }
        }
    }
}
