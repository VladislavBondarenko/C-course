using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte bt = new byte();
            sbyte sbt = new sbyte();
            short sh = new short();
            ushort ush = new ushort();
            int i = new int();
            uint ui = new uint();
            long l = new long();
            ulong ul = new ulong();
            float fl = new float();
            double db = new double();
            decimal dc = new decimal();
            bool bl = new bool();
            char ch = new char();
            Console.WriteLine("Type byte: " + "default value " + bt + ", min " + byte.MinValue + ", max " + byte.MaxValue + "\n");
            Console.WriteLine("Type sbyte: " + "default value " + sbt + ", min " + sbyte.MinValue + ", max " + sbyte.MaxValue + "\n");
            Console.WriteLine("Type short: " + "default value " + sh + ", min " + short.MinValue + ", max " + short.MaxValue + "\n");
            Console.WriteLine("Type ushort: " + "default value " + ush + ", min " + ushort.MinValue + ", max " + ushort.MaxValue + "\n");
            Console.WriteLine("Type int: " + "default value " + i + ", min " + int.MinValue + ", max " + int.MaxValue + "\n");
            Console.WriteLine("Type uint: " + "default value " + ui + ", min " + uint.MinValue + ", max " + uint.MaxValue + "\n");
            Console.WriteLine("Type long: " + "default value " + l + ", min " + long.MinValue + ", max " + long.MaxValue + "\n");
            Console.WriteLine("Type ulong: " + "default value " + ul + ", min " + ulong.MinValue + ", max " + ulong.MaxValue + "\n");
            Console.WriteLine("Type float: " + "default value " + fl + ", min " + float.MinValue + ", max " + float.MaxValue + "\n");
            Console.WriteLine("Type double: " + "default value " + db + ", min " + double.MinValue + ", max " + double.MaxValue + "\n");
            Console.WriteLine("Type decimal: " + "default value " + dc + ", min " + decimal.MinValue + ", max " + decimal.MaxValue + "\n");
            Console.WriteLine("Type bool: " + "default value " + bl + "\n");
            Console.WriteLine("Type char: " + "default value " + ch + "\n");
            Console.ReadKey();
        }
    }
}
