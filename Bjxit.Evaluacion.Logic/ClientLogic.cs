using Bjxit.Evaluacion.Model.Diccionaries;
using Bjxit.Evaluacion.Model.Entities;
using Community.Core.EnterpriseLibrary.Business;
using Community.Core.EnterpriseLibrary.Model.Contract;
using Community.Core.EnterpriseLibrary.Model.Dto;

namespace Bjxit.Evaluacion.Logic
{
    public class ClientLogic : LogicBase<Client, ClientLogic, IRepository<Client>>
    {
        #region Constructors
        public ClientLogic() : base(AppSettingInfo.AppDataAssembly)
        {

        }
        #endregion


        #region PublicMethods

        public override ResponseDataDto<long> Create(Client client)
        {

            ResponseDataDto<long> response = new ResponseDataDto<long>();
            Client dataClient = GetObject(c => c.Email == client.Email);

            if (dataClient != null)
            {
                response.Data = -1;
                response.Completed = true;
            }
            else
            {
                response = Repository.Create(client);
                response.Data = 1;
            }
            return response;
        }


        public override ResponseDataDto<long> Update(Client client)
        {
            ResponseDataDto<long> response = new ResponseDataDto<long>();
            //con este variable se verifica que el cliente exista para poder actualizarlo
            Client dataClient = GetObject(c => c.ClientId == client.ClientId);
            //este esta variable es para validar si existe un correo igual y no se dupliquen
            Client dataClientCorreo = GetObject(c => c.Email == client.Email);


            if (dataClientCorreo != null && dataClientCorreo.Email != dataClient.Email )
            {
                response.Data = -1;
                response.Completed = true;
                response.Message = "El correo ya existe, intente con otro";

            }
            else
            {
                if (dataClient != null)
                {
                    response = Repository.Update(client);
                    response.Data = 1;
                }
                else
                {
                    response.Data = -1;
                    response.Completed = true;
                    response.Message = "El cliente no existe";

                }
                

            }
            
            return response;
        }



        public override ResponseDataDto<long> Delete(Client client)
        {

            ResponseDataDto<long> response = new ResponseDataDto<long>();
            Client dataClient = GetObject(c => c.ClientId == client.ClientId);


            if (dataClient != null)
            {
                try
                {
                    Repository.Delete(client);
                    response.Message = "Cliente eliminado";
                    response.Data = 1;
                }
                catch {
                    response.Data = -1;
                    response.Completed = true;
                    response.Message = "Hubo un error";
                    

                }
            }
            else
            {
                response.Data = -1;
                response.Completed = true;
                response.Message = "El cliente no existe";

            }

            return response;

        }






        #endregion
        }
}
