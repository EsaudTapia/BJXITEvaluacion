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
    public class ProductData : DataAccessBase<Product>
    {
        protected override void PrepareParameters(RepositoryAction action, Product obj)
        {
            switch (action) {
                case RepositoryAction.Create:
                    SetParameter(nameof(obj.Name), obj.Name);
                    SetParameter(nameof(obj.Existence), obj.Existence);
                    break;
                case RepositoryAction.GetAll:
                    break;
                case RepositoryAction.Update:
                    SetParameter(nameof(obj.ProductId), obj.ProductId);
                    SetParameter(nameof(obj.Name), obj.Name);
                    SetParameter(nameof(obj.Existence), obj.Existence);
                    break;
                case RepositoryAction.Delete:
                    SetParameter(nameof(obj.ProductId), obj.ProductId);
                    break;

            }
        }

       
    }
}
