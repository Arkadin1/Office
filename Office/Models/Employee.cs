using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Models
{
    public class Employee
    {
        public Employee()
        {
            Group = new Group();
            Contract = new Contract();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public double Pay { get; set; }

        public string Comment { get; set; }

        public double Payment { get; set; }

        public bool Student { get; set; }

        public Group Group { get; set; }

        public Contract Contract { get; set; }
    }
}
