using API_Net.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Net.DataAccess;
using API_Net.Entities;
using API_Net.Services;

namespace API_Net.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TareasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllTareas")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.TareaRepository.GetAllTareas());
        }

        [HttpPost]
        [Route("PostTarea")]
        public async Task<ActionResult> Register(TareaRegisterDTO tareaRegisterDTO)
        {
            var result = await _unitOfWork.TareaRepository.InsertTarea(tareaRegisterDTO);
            if (result)
            {
                await _unitOfWork.Complete();
                return Ok("Guardado");
            }
            return BadRequest("Error");
        }

        [HttpPut]
        [Route("UpdateTarea")]
        public async Task<ActionResult> Update(int id, TareaRegisterDTO tareaRegisterDTO)
        {
            var result = await _unitOfWork.TareaRepository.UpdateTarea(tareaRegisterDTO, id);
            if (result)
            {
                await _unitOfWork.Complete();
                return Ok("Actualizado");
            }
            return BadRequest("Error");
        }

        [HttpDelete]
        [Route("DeleteTarea")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _unitOfWork.TareaRepository.DeleteTarea(id);
            if (result)
            {
                await _unitOfWork.Complete();
                return Ok("Eliminado");
            }
            return BadRequest("Error");
        }
    }
}
