using Paylocity.Common;
using Paylocity.DataAccess.IAccess;
using Paylocity.Logic.IStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Logic.Structure
{
    public class EmployeeDependent : IEmployeeDependent
    {
        IDependent dependent;
        public EmployeeDependent(IDependent _dependent)
        {
            dependent = _dependent;
        }
        /// <summary>
        /// Returns a list of all the dependents based on a company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Entity.dependent> GetByCompany(int id)
        {
            var response = dependent.GetByCompany(id);
            return response == null || response.count == 0 ? null : (List<Entity.dependent>)response.data;
        }
        public List<Entity.dependent> GetByEmployee(int id)
        {
            var response = dependent.GetByEmployee(id);
            return response == null || response.count == 0 ? null : (List<Entity.dependent>)response.data;
        }
    }
}
