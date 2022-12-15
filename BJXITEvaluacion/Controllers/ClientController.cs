using Bjxit.Evaluacion.Logic;
using Bjxit.Evaluacion.Model.Entities;
using Community.Core.EnterpriseLibrary.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BJXITEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {

        #region Constructors
        public ClientController()
        {


        }
        #endregion


        #region PublicMethods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseDataDto<List<Client>> response = new ResponseDataDto<List<Client>>();
            response.Data = await Task.Run(() => ClientLogic.NewInstance.GetAll());
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            ResponseDataDto<ResponseDataDto<long>> response = new ResponseDataDto<ResponseDataDto<long>>();
            response.Data = await Task.Run(() => ClientLogic.NewInstance.Create(client));
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(Client client)
        {
            ResponseDataDto<ResponseDataDto<long>> response = new ResponseDataDto<ResponseDataDto<long>>();
            response.Data = await Task.Run(() => ClientLogic.NewInstance.Update(client));
            return Ok(response);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(Client client)
        {
            ResponseDataDto<ResponseDto> response = new ResponseDataDto<ResponseDto>();
            response.Data = await Task.Run(() => ClientLogic.NewInstance.Delete(client));
            return Ok(response);
        }


        #endregion

    }
}
