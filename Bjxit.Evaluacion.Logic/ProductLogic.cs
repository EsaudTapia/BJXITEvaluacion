
using Bjxit.Evaluacion.Model.Diccionaries;
using Bjxit.Evaluacion.Model.Entities;
using Community.Core.EnterpriseLibrary.Business;
using Community.Core.EnterpriseLibrary.Model.Contract;
using Community.Core.EnterpriseLibrary.Model.Dto;

namespace Bjxit.Evaluacion.Logic
{
    public class ProductLogic: LogicBase<Product,ProductLogic, IRepository<Product>>
    {
        #region Constructors

       
        public ProductLogic ( ) : base (AppSettingInfo.AppDataAssembly){
            
                                                                   
        }

        #endregion

        #region PublicMethods
        public override ResponseDataDto<long> Create(Product product)
        {
            ResponseDataDto<long> response = new ResponseDataDto<long>();
            Product dataProduct = GetObject(p => p.Name == product.Name);

            if (dataProduct != null)
            {
                response.Data = -1;
                response.Completed = true;
            }
            else
            {
                response = Repository.Create(product);
            }

            return response;
        }
        

        public override ResponseDataDto<long> Update(Product product)
        {
            ResponseDataDto<long> response = new ResponseDataDto<long>();
            Product dataProduct = GetObject(p => p.ProductId == product.ProductId);

            if (dataProduct != null)
            {
                response = Repository.Update(product);
            
            }
            else
            {
                response.Data = -1;
                response.Completed = true;

            }

            return response;
        }


        public override ResponseDataDto<ResponseDto> Delete(Product product)
        {
            ResponseDataDto<ResponseDto> response = new ResponseDataDto<ResponseDto>();
            Product dataProduct = GetObject(p => p.ProductId == product.ProductId);

            if (dataProduct != null)
            {

                try
                {
                    response.Data= Repository.Delete(product);
                    response.Message = "Se elimino correctamente";                    
                }
                catch
                {
                    
                    response.Message = "Hubo un error al intentar eliminar";
                }               

            }
            else
            {
                response.Message = "No  existe ese producto";
                response.Completed = true;

            }

            return response;
        }
        #endregion

    }
}
