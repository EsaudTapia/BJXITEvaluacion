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
    public class ClientData : DataAccessBase<Client>
    {
        protected override void PrepareParameters(RepositoryAction action, Client obj)
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
                    break;
                case RepositoryAction.Update:
                    SetParameter(nameof(obj.ClientId), obj.ClientId);
                    SetParameter(nameof(obj.Name), obj.Name);
                    SetParameter(nameof(obj.LastName), obj.LastName);
                    SetParameter(nameof(obj.PhoneNumber), obj.PhoneNumber);
                    SetParameter(nameof(obj.Direction), obj.Direction);
                    SetParameter(nameof(obj.PostalCode), obj.PostalCode);
                    SetParameter(nameof(obj.Email), obj.Email);
                    break;
                case RepositoryAction.GetAll:
                    break;

                case RepositoryAction.Delete:
                    SetParameter(nameof(obj.ClientId), obj.ClientId);
                    break;


            }

        }
    
    
    }
}
