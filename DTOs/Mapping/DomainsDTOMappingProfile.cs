using AutoMapper;
using BoardSystem.Domains;
using BoardSystem.DTOs.RequestsDTO;
using BoardSystem.DTOs.ResponsesDTO;

namespace BoardSystem.DTOs.Mapping
{
    public class DomainsDTOMappingProfile : Profile
    {
        public DomainsDTOMappingProfile()
        {
            CreateMap<User, CreateUserRequestDTO>().ReverseMap();
            CreateMap<User, UpdateUserRequestDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<Tasks, CreatedTaskRequestDTO>().ReverseMap();
            CreateMap<Tasks, UpdateTaskRequestDTO>().ReverseMap();
            CreateMap<Tasks, TaskResponseDTO>().ReverseMap();
            CreateMap<Comment, CreateCommentRequestDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentRequestDTO>().ReverseMap();
            CreateMap<Comment, CommentResponseDTO>().ReverseMap();
            CreateMap<Board, CreateBoardRequestDTO>().ReverseMap();
            CreateMap<Comment, UpdateBoardRequestDTO>().ReverseMap();
            CreateMap<Comment, BoardResponseDTO>().ReverseMap();
        }
    }
}
