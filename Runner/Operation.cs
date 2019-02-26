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
    public class Operations
    {
        public IEnumerable<Type> GetAllClass()

            => new DirectoryInfo(AppContext.BaseDirectory)
                                    .GetFiles("*.dll")
                                    .Select(x => x.Name.Substring(0, x.Name.IndexOf(".dll")))
                                    .Select(x => Assembly.Load(x))
                                    .SelectMany(x => x.GetTypes())
                                    .Where(x => typeof(IQuestion).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
        
            
        public IEnumerable<KeyValuePair<int,string>> GetQuestions()
        
           =>this.GetAllClass()
            .Select(x => x.GetCustomAttributes(typeof(QuestionAttribute), true)
            .Select(y => y as QuestionAttribute)
            .Select(y=> new KeyValuePair<int,string>(y.GetQuestionKey(),y.GetQuestion())).FirstOrDefault()); 

     

        public void Ask()
        {

            foreach (var question in this.GetQuestions())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{question.Value} problemini çözmek için {question.Key} yazınız. \n ");
                Console.ResetColor();
            }
        }


        public  Int32 GetValue()
        {
            while (true)
            {
                Int32 value;

                var consoleValue = Console.ReadLine();

               var isValid = Int32.TryParse(consoleValue, out value);

                if (isValid)
                return value;

                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Girdiğiniz değer gerçerli bir değer değil lütfen tekrar deneyiniz.");
                    Console.ResetColor();

                    this.Ask();
                }
            }
        }


        public void ProcessQuestion(int request)
        {
            this.GetAllClass()
            .Select(x => x.GetCustomAttributes(typeof(QuestionAttribute), true)
            .Select(y => y as QuestionAttribute)
            .Select(y => new KeyValuePair<int, string>(y.GetQuestionKey(), y.GetQuestion())).FirstOrDefault());

            var obj =
                this.GetAllClass()
                .Where(x =>
                x.GetCustomAttribute(typeof(QuestionAttribute), true) is QuestionAttribute &&
               (x.GetCustomAttribute(typeof(QuestionAttribute), true) as QuestionAttribute).GetQuestionKey() == request)
                .FirstOrDefault();

            if(obj==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Girdiğiniz değer ile ilgili bir soru bulunamadı..");
                Console.ResetColor();
            }
            else
            obj.GetMethod("Answer").Invoke(Activator.CreateInstance(obj, null),null);



        }
    }
}
