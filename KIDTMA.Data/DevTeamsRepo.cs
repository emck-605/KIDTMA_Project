using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDTMA.Data
{
    public class DevTeamsRepo
    {
        private List<DevTeams> _listOfDevTeams = new List<DevTeams>();

        // Create
        public void AddDevTeamsToList(DevTeams devTeams)
        {
            _listOfDevTeams.Add(devTeams);
        }

        // Read
        public List<DevTeams> GetDevTeamsList(string teamName)
        {
            return _listOfDevTeams;
        }

        // Update
        public void UpdateExistingDevTeams(string originalTeamName, DevTeams newDevTeams)
        {
            DevTeams oldDevTeams = GetDevTeamsByTeamName(originalTeamName);

            if (oldDevTeams != null)
            {
                oldDevTeams.TeamName = newDevTeams.TeamName;
                oldDevTeams.TeamMembers = newDevTeams.TeamMembers;
                oldDevTeams.TeamIdentificationNumber = newDevTeams.TeamIdentificationNumber;
            }
        }

        // Delete
        public bool RemoveDevTeamsFromList(string teamName)
        {
            DevTeams devTeams = GetDevTeamsByTeamName(teamName);

            if (devTeams == null)
            {
                return false;
            }

            int initialCount = _listOfDevTeams.Count;
            _listOfDevTeams.Remove(devTeams);

            if (initialCount > _listOfDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Method
        public DevTeams GetDevTeamsByTeamName(string teamName)
        {
            foreach (DevTeams devTeams in _listOfDevTeams)
            {
                if (devTeams.TeamName == teamName)
                {
                    return devTeams;
                }
            }

            return null;
        }
    }
}
