using AutoMapper;
using BoardSystem.Domains;
using BoardSystem.DTOs.RequestsDTO;
using BoardSystem.DTOs.ResponsesDTO;
using BoardSystem.Enums;
using BoardSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BoardSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskResponseDTO>> GetAllTasks()
        {
            var tasks = _unitOfWork.TaskRepository.GetAllTasks();
            var tasksResponseDTO = _mapper.Map<IEnumerable<TaskResponseDTO>>(tasks);
            return Ok(tasksResponseDTO);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetTaskById")]
        public ActionResult<TaskResponseDTO> GetTaskById(int id)
        {
            var task = _unitOfWork.TaskRepository.GetTaskById(id);
            if (task is null)
                return NotFound($"Task com o id = {id} não encontrado!");
            var taskResponseDTO = _mapper.Map<TaskResponseDTO>(task);
            return Ok(taskResponseDTO);
        }

        [HttpGet("Board/{id}")]
        public ActionResult<IEnumerable<TaskResponseDTO>> GetAllTasksByBoardId(int id)
        {
            var tasks = _unitOfWork.TaskRepository.GetTaskByBoardId(id);
            var tasksResponseDTO = _mapper.Map<IEnumerable<TaskResponseDTO>>(tasks);
            return Ok(tasksResponseDTO);
        }

        [HttpGet("Board/Satus{status}")]
        public ActionResult<IEnumerable<TaskResponseDTO>> GetAllTasksByStatus(TasksStatus statusId)
        {
            var tasks = _unitOfWork.TaskRepository.GetTaskByStatus(statusId);
            var tasksResponseDTO = _mapper.Map<IEnumerable<TaskResponseDTO>>(tasks);
            return Ok(tasksResponseDTO);
        }

        [HttpPost]
        public ActionResult<TaskResponseDTO> PostTask(CreatedTaskRequestDTO createdTaskRequestDTO)
        {
            var task = _mapper.Map<Tasks>(createdTaskRequestDTO);
            var createdTask = _unitOfWork.TaskRepository.Add(task);
            _unitOfWork.Commit();
            var taskResponseDTO = _mapper.Map<TaskResponseDTO>(createdTask);
            return CreatedAtAction(nameof(GetTaskById), new {id = taskResponseDTO .Id}, taskResponseDTO);
        }

        [HttpPatch("{id:int:min(1)}")]
        public ActionResult PatchTask(int id, JsonPatchDocument<UpdateTaskRequestDTO> updateTaskRequestDTO)
        {
            var task = _unitOfWork.TaskRepository.GetTaskById(id);
            if (task is null)
                return NotFound($"Task com o id = {id} não encontrado!");
            var updatedTaskDTO = _mapper.Map<UpdateTaskRequestDTO>(task);
            updateTaskRequestDTO.ApplyTo(updatedTaskDTO, ModelState);
            if (!ModelState.IsValid || !TryValidateModel(updatedTaskDTO))
                return BadRequest(ModelState);
            _mapper.Map(updatedTaskDTO, task);
            _unitOfWork.TaskRepository.Update(task);
            _unitOfWork.Commit();
            return NoContent();
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult DeleteTask(int id)
        {
            var task = _unitOfWork.TaskRepository.GetTaskById(id);
            if (task is null)
                return NotFound($"Task com o id = {id} não encontrado!");
            _unitOfWork.TaskRepository.Delete(task);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
