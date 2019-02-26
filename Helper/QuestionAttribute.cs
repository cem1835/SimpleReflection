using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class QuestionAttribute:Attribute
    {
        private int questionKey;

        private string question;

        private QuestionAttribute()
        {

        }

        public QuestionAttribute(int questionKey,string question)
        {
            this.questionKey = questionKey;
            this.question = question;
        }

        public string GetQuestion() => this.question;

        public int GetQuestionKey() => this.questionKey;
    }
}
