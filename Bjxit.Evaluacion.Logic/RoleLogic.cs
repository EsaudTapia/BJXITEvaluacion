using Bjxit.Evaluacion.Model.Diccionaries;
using Bjxit.Evaluacion.Model.Entities;
using Community.Core.EnterpriseLibrary.Business;
using Community.Core.EnterpriseLibrary.Model.Contract;
using Community.Core.EnterpriseLibrary.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bjxit.Evaluacion.Logic
{
    public class RoleLogic: LogicBase<Role, RoleLogic, IRepository<Role>>
    {


        #region Constructors
        public RoleLogic() : base(AppSettingInfo.AppDataAssembly)
        {


        }

        #endregion


        #region PublicMethods


        public override ResponseDataDto<long> Create(Role role)
        {
                            
            ResponseDataDto<long> response = new ResponseDataDto<long>();                              
            
            try            
            {                  
                response = Repository.Create(role);           
            }
            catch (Exception ex)
            {
                response.Completed = false;
                response.Data = -1;
                response.Message = "Ocurrio un error";
                return response;
            }

            return response;
        }

        public override ResponseDataDto<long> Update(Role role)
        {
            ResponseDataDto<long> response = new ResponseDataDto<long>();

            Role dataRole = GetObject(p => p.RoleId == role.RoleId);

            if (dataRole != null)
            {
                response = Repository.Update(role);
            }
            else
            {
                response.Data = -1;
                response.Completed = true;
                response.Message = "No existe este rol";
            }

            return response;
        }

        public override ResponseDataDto<long> Delete(Role role)
        {
            ResponseDataDto<long> response = new ResponseDataDto<long>();

            Role dataRole = GetObject(p => p.RoleId == role.RoleId);

            if (dataRole != null)
            {

                try
                {
                    Repository.Delete(role);
                    response.Data = 1;
                    response.Message = "rol eliminado";
                }
                catch {
                    response.Data = -1;
                    response.Message = "Hubo un error";
                }
            }
            else
            {
                response.Data = -1;
                response.Completed = true;
                response.Message = "No existe este rol";
            }

            return response;
        }

        #endregion




    }


}
