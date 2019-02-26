using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfMultiple
{
    [Question(53, "Klavyeden girilen bir sayının altında 3 veya 5 katı olan tüm doğal sayıların toplamını bul")]
    public class SumOfMultiple : IQuestion
    {
        public void Answer()
        {
            while (true)
            {

                Console.WriteLine("Lütfen Bir Sayı Giriniz.");

                var consoleValue = Console.ReadLine();

                if (Validate(consoleValue))
                {

                    Int32 value = int.Parse(consoleValue);

                    Int64 result = 0;

                    for (int val = value; val >= 3; val--)
                    {
                        if (val % 3 == 0 || val % 5 == 0)
                            result += val;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"İşleminizin Sonucu : {result.ToString("N2")}");
                    Console.ResetColor();

                    Console.WriteLine("İşleme Devam Etmek İçin 1 e basınız.");

                    if (Console.ReadLine() == "1")
                        continue;
                    else
                        break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Girdiğiniz Değer Bir Tam Sayıya Çevirilemedi.. Lütfen Tekrar Deneyiniz.");
                    Console.ResetColor();
                }

            }

        }

        public bool Validate(string val)
                => int.TryParse(val, out int output);


    }
}
