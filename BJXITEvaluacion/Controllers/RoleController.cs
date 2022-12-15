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
    public class RoleController : Controller
    {
        //constructor

        #region Constructors
        public RoleController()
        {


        }
        #endregion

        #region PublicMethods
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            ResponseDataDto<List<Role>> response = new ResponseDataDto<List<Role>>();
            response.Data = await Task.Run(() => RoleLogic.NewInstance.GetAll());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            ResponseDataDto<ResponseDataDto<long>> response = new ResponseDataDto<ResponseDataDto<long>>();
            response.Data = await Task.Run(() => RoleLogic.NewInstance.Create(role));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            ResponseDataDto<ResponseDataDto<long>> response = new ResponseDataDto<ResponseDataDto<long>>();
            response.Data = await Task.Run(() => RoleLogic.NewInstance.Update(role));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Role role)
        {
            ResponseDataDto<ResponseDto> response = new ResponseDataDto<ResponseDto>();
            response.Data = await Task.Run(() => RoleLogic.NewInstance.Delete(role));
            return Ok(response);
        }

        #endregion
    }
}
