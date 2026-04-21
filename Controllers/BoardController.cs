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
    public class BoardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BoardController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BoardResponseDTO>> GetAllBoards()
        {
            var boards = _unitOfWork.BoardRepository.GetAllBoards();
            var boardResponseDto = _mapper.Map<IEnumerable<BoardResponseDTO>>(boards);
            return Ok(boardResponseDto);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetBoardById")]
        public ActionResult<BoardResponseDTO> GetBoardById(int id)
        {
            var board = _unitOfWork.BoardRepository.GetBoardById(id);
            if (board is null)
                return NotFound($"Board com id = {id} não encontrado!");
            var boardResponseDto = _mapper.Map<IEnumerable<BoardResponseDTO>>(board);
            return Ok(boardResponseDto);
        }

        [HttpPost]
        public ActionResult<BoardResponseDTO> PostUser(CreateBoardRequestDTO createBoardRequestDTO)
        {
            var board = _mapper.Map<Board>(createBoardRequestDTO);
            var createdBoard = _unitOfWork.BoardRepository.Add(board);
            _unitOfWork.Commit();
            var boardResponseDTO = _mapper.Map<BoardResponseDTO>(board);
            return CreatedAtAction(nameof(GetBoardById), new { id = boardResponseDTO.Id }, boardResponseDTO);
        }

        [HttpPatch("{id:int:min(1)}")]
        public ActionResult PatchUser(int id, JsonPatchDocument<UpdateBoardRequestDTO> updateBoardRequestDTO)
        {
            var board = _unitOfWork.BoardRepository.GetBoardById(id);
            if (board is null)
                return NotFound($"Board com id = {id} não encontrado!");
            var updateBoardDTO = _mapper.Map<UpdateBoardRequestDTO>(board);
            updateBoardRequestDTO.ApplyTo(updateBoardDTO, ModelState);
            if (!ModelState.IsValid || !TryValidateModel(updateBoardDTO))
                return BadRequest(ModelState);
            _mapper.Map(updateBoardDTO, board);
            _unitOfWork.BoardRepository.Update(board);
            _unitOfWork.Commit();
            return NoContent();
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult DeleteBoard(int id)
        {
            var board = _unitOfWork.BoardRepository.GetBoardById(id);
            if (board is null)
                return NotFound($"Board com id = {id} não encontrado!");
            _unitOfWork.BoardRepository.Delete(board);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
