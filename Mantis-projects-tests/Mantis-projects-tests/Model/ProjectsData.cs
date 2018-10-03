using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
{
   public class ProjectsData: IEquatable<ProjectsData>, IComparable<ProjectsData>
    {
        public ProjectsData()
        {
        }

        public ProjectsData(string name)
        {
            this.Name = name;
        }

        public bool Equals(ProjectsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Name + "\ndesc=" + Desc;
        }
        public ProjectsData(string name, string desc)
        {
            this.Name = name;
            this.Desc = desc;
        }

        public int CompareTo(ProjectsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
