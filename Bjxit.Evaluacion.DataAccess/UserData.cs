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
    public class UserData : DataAccessBase<User>
    {
        protected override void PrepareParameters(RepositoryAction action, User obj)
        {

            switch (action)
            {
                case RepositoryAction.Create:
                    SetParameter(nameof(obj.Name), obj.Name);
                    SetParameter(nameof(obj.LastName), obj.LastName);
                    SetParameter(nameof(obj.PhoneNumber), obj.PhoneNumber);
                    SetParameter(nameof(obj.Direction), obj.Direction);
                    SetParameter(nameof(obj.PostalCode), obj.PostalCode);
                    SetParameter(nameof(obj.Email), obj.Email);
                    SetParameter(nameof(obj.Password), obj.Password);
                    SetParameter(nameof(obj.RoleId), obj.RoleId);
                    break;
                case RepositoryAction.Update:
                    SetParameter(nameof(obj.UserId), obj.UserId);
                    SetParameter(nameof(obj.Name), obj.Name);
                    SetParameter(nameof(obj.LastName), obj.LastName);
                    SetParameter(nameof(obj.PhoneNumber), obj.PhoneNumber);
                    SetParameter(nameof(obj.Direction), obj.Direction);
                    SetParameter(nameof(obj.PostalCode), obj.PostalCode);
                    SetParameter(nameof(obj.Email), obj.Email);
                    SetParameter(nameof(obj.Password), obj.Password);
                    SetParameter(nameof(obj.RoleId), obj.RoleId);
                    break;
                case RepositoryAction.GetAll:
                    break;

                case RepositoryAction.Delete:
                    SetParameter(nameof(obj.UserId), obj.UserId);
                    break;
            }
        }
    }
}
