using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodTutorial {

    public static class IntegereExtensionMethods {

        public static int Add(this int i, int term) {
            return i + term;
        }
        public static int Sub(this int i, int j) {
            return i - j;
        }
        public static int Mult(this int i, int j) {
            return i * j;
        }
        public static int Div(this int i, int j) {
            return i / j;
        }
        public static void CW(this int i) {
            Console.Write($"{i}");
        }
        public static void CWL(this string i) {
            Console.WriteLine($"{i}");
        }
    }

    public static class StringExtensionMethods {

    //this say it is pointing to the instance of what it is attached to;
         //Defines what type of data you
        public static void CW(this string str) {
         Console.WriteLine($"{str}");
        
        }
         public static string AppendString(this string str, string appendStr) {
            return $"{str} {appendStr}";
        }
    }
}
