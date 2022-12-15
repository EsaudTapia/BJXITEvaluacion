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
    public class UserLogic : LogicBase<User, UserLogic, IRepository<User>>
    {

        #region Constructors
        public UserLogic() : base(AppSettingInfo.AppDataAssembly)
        {

        }
        #endregion

        #region PublicMethods

        public override ResponseDataDto<long> Create(User user)
        {
            ResponseDataDto<long> response = new ResponseDataDto<long>();
            User dataUser = GetObject(c => c.Email == user.Email);
            
            if (dataUser != null)
            {
                response.Data = -1;
                response.Completed = true;
                response.Message = "El correo ya existe, intente con otro";
            }
            else
            {
                response = Repository.Create(user);
                response.Data = 1;                                
            }
            return response;
        }

        public override ResponseDataDto<long> Update(User user)
        {
            ResponseDataDto<long> response = new ResponseDataDto<long>();
            //con este variable se verifica que el cliente exista para poder actualizarlo
            User dataUser = GetObject(c => c.UserId == user.UserId);
            //este esta variable es para validar si existe un correo igual y no se dupliquen
            User dataUserCorreo = GetObject(c => c.Email == user.Email);

            if (dataUserCorreo != null && dataUserCorreo.Email != dataUser.Email)
            {
                response.Data = -1;
                response.Completed = true;
                response.Message = "El correo ya existe, intente con otro";

            }
            else
            {
                if (dataUser != null)
                {
                    response = Repository.Update(user);
                    response.Data = 1;
                }
                else
                {
                    response.Data = -1;
                    response.Completed = true;
                    response.Message = "El usuario no existe";
                }
            }
            return response;
        }

        public override ResponseDataDto<long> Delete(User user)
        {
            ResponseDataDto<long> response = new ResponseDataDto<long>();
            User dataUser = GetObject(c => c.UserId == user.UserId);
            if (dataUser != null)
            {
                Repository.Delete(user);
                response.Data = 1;
                response.Message = "El usuario se elimino correctamente";
            }
            else
            {
                response.Data = -1;
                response.Completed = true;
                response.Message = "El usuario no existe";
            }
            return response;
        }

        #endregion
    }
}
