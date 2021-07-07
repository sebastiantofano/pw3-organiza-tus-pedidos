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
            CreateMap<Usuario, UsuarioLogueadoResponse>();
            CreateMap<Articulo, ArticuloResponse>();
            CreateMap<Usuario, UsuarioResponse>();

            CreateMap<KeyValuePair<Articulo, int>, ArticuloPedidoResponse>()
                .ForMember(p => p.IdArticulo, opt => opt.MapFrom(x => x.Key.IdArticulo))
                .ForMember(p => p.Codigo, opt => opt.MapFrom(x => x.Key.Codigo))
                .ForMember(p => p.Descripcion, opt => opt.MapFrom(x => x.Key.Descripcion))
                .ForMember(p => p.Cantidad, opt => opt.MapFrom(x => x.Value));

            CreateMap<Pedido, PedidoResponse>()
                .ForMember(p => p.Estado, opt => opt.MapFrom(x => x.IdEstadoNavigation.Descripcion))
                .ForMember(p => p.ModificadoPor, opt => opt.MapFrom(x => x.ModificadoPorNavigation));

            CreateMap<UsuarioLoginRequest, Usuario>();

        }
    }
}

