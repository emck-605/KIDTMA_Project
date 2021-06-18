using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDTMA.Data
{
    public class DevTeams
    {
        public DevTeams()
        {

        }

        public DevTeams(string teamName, List<Developer>teamMembers, int teamIdentificationNumber)
        {
            TeamName = teamName;
            TeamMembers = teamMembers;
            TeamIdentificationNumber = teamIdentificationNumber;
        }

        public string TeamName { get; set; }
        public List<Developer> TeamMembers { get; set; }
        public int TeamIdentificationNumber { get; set; }
    }
}
