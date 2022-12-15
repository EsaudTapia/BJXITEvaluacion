using Bjxit.Evaluacion.Model.Entities;
using Community.Core.EnterpriseLibrary.Model.Enum;
using Community.Core.EnterpriseLibrary.Repository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjxit.Evaluacion.DataAccess
{
    public class RoleData : DataAccessBase<Role>
    {
        protected override void PrepareParameters(RepositoryAction action, Role obj)
        {

            switch (action)
            {
                case RepositoryAction.Create:
                    SetParameter(nameof(obj.Name), obj.Name);
                    SetParameter(nameof(obj.Description), obj.Description);
                    break;
                case RepositoryAction.GetAll:
                    break;
                case RepositoryAction.Update:
                    SetParameter(nameof(obj.RoleId), obj.RoleId);
                    SetParameter(nameof(obj.Name), obj.Name);
                    SetParameter(nameof(obj.Description), obj.Description);
                    break;
                case RepositoryAction.Delete:
                    SetParameter(nameof(obj.RoleId), obj.RoleId);
                    break;

            }

        }
        
        
    }
}
