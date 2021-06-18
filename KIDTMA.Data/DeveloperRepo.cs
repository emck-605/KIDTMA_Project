using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDTMA.Data
{
    public class DeveloperRepo
    {
        private List<Developer> _listOfDeveloper = new List<Developer>();

        // Create
        public void AddDeveloperToList(Developer developer)
        {
            _listOfDeveloper.Add(developer);
        }

        // Read
        public List<Developer> GetDeveloperList()
        {
            return _listOfDeveloper;
        }

        // Update
        public bool UpdateExistingDeveloper(string originalMember, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByMemberName(originalMember);

            if (oldDeveloper != null)
            {
                oldDeveloper.MemberName = newDeveloper.MemberName;
                oldDeveloper.IdentificationNumber = newDeveloper.IdentificationNumber;
                oldDeveloper.AccessToPluralsight = newDeveloper.AccessToPluralsight;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveDeveloperFromList(string memberName)
        {
            Developer developer = GetDeveloperByMemberName(memberName);

            if (developer == null)
            {
                return false;
            }

            int initialCount = _listOfDeveloper.Count;
            _listOfDeveloper.Remove(developer);

            if (initialCount > _listOfDeveloper.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Method
        private Developer GetDeveloperByMemberName(string memberName)
        {
            foreach (Developer developer in _listOfDeveloper)
            {
                if(developer.MemberName == memberName)
                {
                    return developer;
                }
            }

            return null;
        }
    }
}
