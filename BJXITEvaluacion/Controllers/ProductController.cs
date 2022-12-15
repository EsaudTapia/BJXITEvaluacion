using Bjxit.Evaluacion.Logic;
using Bjxit.Evaluacion.Model.Entities;
using Community.Core.EnterpriseLibrary.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace BJXITEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        //constructor

        #region Constructors
        public ProductController()
        {


        }
        #endregion


        #region PublicMethods
        //metodos asincronos

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseDataDto<List<Product>> response = new ResponseDataDto<List<Product>>();
            response.Data = await Task.Run(() => ProductLogic.NewInstance.GetAll());
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            ResponseDataDto< ResponseDataDto<long>> response = new ResponseDataDto<ResponseDataDto<long>>();            
            response.Data = await Task.Run(() => ProductLogic.NewInstance.Create(product));
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            ResponseDataDto<ResponseDataDto<long>> response = new ResponseDataDto<ResponseDataDto<long>>();
            response.Data = await Task.Run(() => ProductLogic.NewInstance.Update(product));
            return Ok(response);
        }

        
        [HttpDelete]       
        public async Task<IActionResult> Delete(Product product) {
            
            ResponseDataDto<ResponseDto> response = new ResponseDataDto<ResponseDto>();
            response.Data = await Task.Run(() => ProductLogic.NewInstance.Delete(product));
            return Ok(response);

        }

        #endregion





    }
}
