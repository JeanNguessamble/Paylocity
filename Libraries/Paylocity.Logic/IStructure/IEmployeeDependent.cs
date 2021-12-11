using Paylocity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Logic.IStructure
{
   public interface IEmployeeDependent
    {
        List<Entity.dependent> GetByCompany(int id);
        List<Entity.dependent> GetByEmployee(int id);
        
    }
}
