using AutoMapper;
using SnackyAPI.Models.Database;

namespace SnackyAPI.Models.DTO.Profiles
{
    public class SnackProfile : Profile
    {
        public SnackProfile() 
        {
            CreateMap<CreateSnackDTO, Snack>();
        }
    }
}
