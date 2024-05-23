using Account_book.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account_book.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LabelTypeController : ControllerBase
    {
        private readonly ILabelTypeService _labelTypeService;
        public LabelTypeController(ILabelTypeService labelTypeService) { _labelTypeService = labelTypeService; }

        [HttpGet]
        public async Task<IResult> GetAsync()
        {
            var result = await _labelTypeService.GetAll();
            return Results.Ok(result);
        }
    }
}
