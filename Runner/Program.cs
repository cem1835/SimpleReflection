using Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    class Program
    {


        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                var processor = new Operations();

                processor.Ask();

                var value = processor.GetValue();

                processor.ProcessQuestion(value);


                System.Threading.Thread.Sleep(1000 * 1);
            }
            while (true);
            
        }







    }
}
