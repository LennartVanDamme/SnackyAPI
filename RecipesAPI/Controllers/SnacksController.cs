using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SnackyAPI.Models.Database;
using SnackyAPI.Models.DTO;
using SnackyAPI.Services;

namespace SnackyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnacksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISnacksService _recipesService;

        public SnacksController(IMapper mapper, ISnacksService recipesService)
        {
            _mapper = mapper;
            _recipesService = recipesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            List<Snack> recipes = await _recipesService.GetAll();
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> AddSnack(CreateSnackDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Snack snack = _mapper.Map<Snack>(dto);
            snack = await _recipesService.AddSnack(snack);

            return Ok(snack);
        }
    }
}
