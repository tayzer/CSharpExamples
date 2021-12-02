using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Examples
{
    public class PersonRepository : IRepository<Person>
    {
        public void Delete(Person entityToDelete)
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Person entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
