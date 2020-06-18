using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class MatrixProfile : Profile
    {
        public MatrixProfile()
        {
            //  Map = Source -> Target
            CreateMap<Matrix, Matrix_Read_DTO>();
            CreateMap<Matrix_Create_DTO, Matrix>();
        }
    }
}