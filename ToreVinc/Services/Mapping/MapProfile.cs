using AutoMapper;
using KurumsalWebVinc.Migrations;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Models.DTOs;

namespace KurumsalWebVinc.Services.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			/*  CreateMap<Product, ProductDto>()  sadece bu şekilde yazarsak produc producdto döner ama tersinede istersek ReverseMap koymalıyız */
			//CreateMap<Product, ProductDto>().ReverseMap();
			//CreateMap<Category, CategoryDto>().ReverseMap();
			//CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
			//CreateMap<ProductUpdateDto, Product>();// sadece update kullanılacak tersine gerek yok 
			//CreateMap<Product, ProductsWithCategoryDto>();
			//CreateMap<Category, CategoryWithProductsDto>();
			CreateMap<Icerik, IcerikDto>().ReverseMap();
			CreateMap<TalepFormu, TalepFormuDto>().ReverseMap();
			CreateMap<AppRole, RoleDto>().ReverseMap();
			CreateMap<AppUser, UserDto>().ReverseMap();
			CreateMap<Kadromuz, KadromuzDto>().ReverseMap();
			CreateMap<Hakkimizda, HakkimizdaDto>().ReverseMap();
			CreateMap<Vizyon, VizyonDto>().ReverseMap();
			CreateMap<Servisler, ServislerDto>().ReverseMap();
			CreateMap<AracBilgisi, AracSearcDto>().ReverseMap();
			CreateMap<GenelBilgiler, GenelBilgilerDto>().ReverseMap();
		}
	}
}
