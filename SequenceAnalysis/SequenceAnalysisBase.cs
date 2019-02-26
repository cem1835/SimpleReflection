using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceAnalysis
{
    [Question(52, "klavyeden girilen bir string’de büyük harfleri bulun ve bu kelimelerdeki tüm karakterleri alfabetik olarak sırala")]
    public class SequenceAnalysisBase : IQuestion
    {
        public void Answer()
        {

            while (true)
            {
                Console.WriteLine("Lütfen Bir İfade Giriniz..");

                var consoleValue = Console.ReadLine();


                if (Validate(consoleValue))
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    var result = String.Concat(consoleValue.Where(x => Char.IsUpper(x)).OrderBy(x => x));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"İşleminizin Sonucu : {result}");
                    Console.ResetColor();


                    Console.WriteLine("İşleme Devam Etmek İçin 1 e basınız.");

                    if (Console.ReadLine() == "1")
                        continue;
                    else
                        break;

                }

            }

        }

        public bool Validate(string val)
        {
            return true;
        }
    }
}
