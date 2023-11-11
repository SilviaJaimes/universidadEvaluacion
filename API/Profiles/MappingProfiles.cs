using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rol,RolDto>().ReverseMap();
        CreateMap<Usuario,UsuarioDto>().ReverseMap();
        CreateMap<Asignatura,AsignaturaDto>().ReverseMap();
        CreateMap<CursoEscolar,CursoEscolarDto>().ReverseMap();
        CreateMap<Departamento,DepartamentoDto>().ReverseMap();
        CreateMap<Grado,GradoDto>().ReverseMap();
        CreateMap<Matricula,MatriculaDto>().ReverseMap();
        CreateMap<Persona,PersonaDto>().ReverseMap();
        CreateMap<Profesor,ProfesorDto>().ReverseMap();
    }
}