using AutoMapper;
using BoardSystem.Domains;
using BoardSystem.DTOs.RequestsDTO;
using BoardSystem.DTOs.ResponsesDTO;
using BoardSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BoardSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponseDTO>> GetAllUsers()
        {
            var users = _unitOfWork.UserRepository.GetAllUsers();
            var usersResponseDTO = _mapper.Map<IEnumerable<UserResponseDTO>>(users);
            return Ok(usersResponseDTO);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetUserById")]
        public ActionResult<UserResponseDTO> GetUserById(int id)
        {
            var user = _unitOfWork.UserRepository.GetUserById(id);
            if (user is null)
                return NotFound($"Usuário do id = {id} não encontrado!");
            var userResponseDTO = _mapper.Map<UserResponseDTO>(user);
            return Ok(userResponseDTO);
        }

        [HttpGet("{email}")]
        public ActionResult<UserResponseDTO> GetUserByEmail(string email)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);
            if(user is null)
                return NotFound($"Usuário do email = {email} não encontrado!");
            var userResponseDTO = _mapper.Map<UserResponseDTO>(user);
            return Ok(userResponseDTO);
        }

        [HttpPost]
        public ActionResult<UserResponseDTO> PostUser(CreateUserRequestDTO createUserRequestDTO)
        {
            var user = _mapper.Map<User>(createUserRequestDTO);
            user = _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();
            var userResponseDTO = _mapper.Map<UserResponseDTO>(user);
            return CreatedAtAction(nameof(GetUserById), new { id = userResponseDTO.Id }, userResponseDTO);
        }

        [HttpPatch("{id:int:min(1)}")]
        public ActionResult PutUser(int id, JsonPatchDocument<UpdateUserRequestDTO> updateUserRequestDTO)
        {
            var user = _unitOfWork.UserRepository.GetUserById(id);
            if(user is null)
                return NotFound($"Usuário do id = {id} não encontrado!");
            var userRequestDTO = _mapper.Map<UpdateUserRequestDTO>(user);
            updateUserRequestDTO.ApplyTo(userRequestDTO, ModelState);
            if (!ModelState.IsValid || !TryValidateModel(userRequestDTO))
                return BadRequest(ModelState);
            _mapper.Map(userRequestDTO, user);
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();
            return NoContent();
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _unitOfWork.UserRepository.GetUserById(id);
            if (user is null)
                return NotFound($"Usuário do id = {id} não encontrado!");
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
