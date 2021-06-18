using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDTMA.Data
{
    public class Developer
    {
        public Developer()
        {

        }

        public Developer(string memberName, int identificationNumber, bool accessToPluralsight)
        {
            MemberName = memberName;
            IdentificationNumber = identificationNumber;
            AccessToPluralsight = accessToPluralsight;
        }
        
        public string MemberName { get; set; }
        public int IdentificationNumber { get; set; }
        public bool AccessToPluralsight { get; set; }

    }
}
