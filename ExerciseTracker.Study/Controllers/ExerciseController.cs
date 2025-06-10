using ExerciseTracker.Study.Models;
using ExerciseTracker.Study.Models.DTO;
using ExerciseTracker.Study.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IService<Exercise> Service;
        public ExerciseController(IService<Exercise> service)
        {
            Service = service;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto<Exercise>>> GetAllExercises()
        {
            return await Service.GetAll();
        }
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<ResponseDto<Exercise>>> GetExerciseById([FromRoute] int Id)
        {
            return await Service.GetById(Id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto<Exercise>>> Create([FromBody] ExerciseDto NewExercise)
        {

            return await Service.Create(new Exercise { 
                Name=NewExercise.Name }
            );
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDto<Exercise>>> Update([FromBody] Exercise UpdateExercise)
        {
            return await Service.Update(UpdateExercise);
        }
        [HttpDelete]
        public async Task<ActionResult<ResponseDto<Exercise>>> Delete([FromBody]int Id)
        {
            return await Service.Delete(Id);
        }
    }
}
