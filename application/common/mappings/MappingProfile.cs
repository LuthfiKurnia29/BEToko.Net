using application.dto;
using application.features.auth;
using application.features.barang.command.addBarangs;
using application.features.category.command.addCategory;
using AutoMapper;
using domain.entity;

namespace application.common.mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<RegisterCommand, User>();
        CreateMap<AddCategoryCommand, Kategori>();
        CreateMap<AddBarangCommand, Barang>();
    }
}