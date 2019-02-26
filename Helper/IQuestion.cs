using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
  public  interface IQuestion
    {
        //KeyValuePair<>

        void Answer();

        bool Validate(string val);
        
    }
}
