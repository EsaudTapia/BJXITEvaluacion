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
    public class UserController : Controller
    {

        #region Constructors
        public UserController()
        {
        }
        #endregion

        #region PublicMethods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseDataDto<List<User>> response = new ResponseDataDto<List<User>>();
            response.Data = await Task.Run(() => UserLogic.NewInstance.GetAll());
            return Ok(response);
        }

        [HttpPost]

        public async Task<IActionResult> Create(User user)
        {
            ResponseDataDto<ResponseDataDto<long>> response = new ResponseDataDto<ResponseDataDto<long>>();
            response.Data = await Task.Run(() => UserLogic.NewInstance.Create(user));
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> Update(User user)
        {
            ResponseDataDto<ResponseDataDto<long>> response = new ResponseDataDto<ResponseDataDto<long>>();
            response.Data = await Task.Run(() => UserLogic.NewInstance.Update(user));
            return Ok(response);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(User user)
        {
            ResponseDataDto<ResponseDto> response = new ResponseDataDto<ResponseDto>();
            response.Data = await Task.Run(() => UserLogic.NewInstance.Delete(user));
            return Ok(response);
        }

 


        #endregion
    }
}
