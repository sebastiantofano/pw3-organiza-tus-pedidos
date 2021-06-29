using AutoMapper;
using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.RequestObjects;

namespace WebAPI.ResponseObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteResponse>();
            //.ForMember(u => u.IdCliente, opt => opt.MapFrom(x => x.IdCliente))
            //.ForMember(u => u.Nombre, opt => opt.MapFrom(x => x.Nombre))
            //.ForMember(u => u.Numero, opt => opt.MapFrom(x => x.Telefono));

            CreateMap<UsuarioLoginRequest, Usuario>();

            CreateMap<Usuario, UsuarioLogueadoResponse>();

            CreateMap<Articulo, ArticuloResponse>();

        }
    }
}

