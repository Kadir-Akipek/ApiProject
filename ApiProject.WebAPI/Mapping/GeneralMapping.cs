using ApiProject.WebAPI.DTOs.FearuteDTOs;
using ApiProject.WebAPI.DTOs.MessageDTOs;
using ApiProject.WebAPI.DTOs.ProductDTOs;
using ApiProject.WebAPI.Entities;
using AutoMapper;
using AutoMapper.Features;

namespace ApiProject.WebAPI.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping() //mapp'lenecek ifadeler ctor içine yazılır
		{
			CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
			CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
			CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();

			CreateMap<Message, ResultMessageDTO>().ReverseMap();
			CreateMap<Message, CreateMessageDTO>().ReverseMap();
			CreateMap<Message, UpdateMessageDTO>().ReverseMap();
			CreateMap<Message, GetByIdMessageDTO>().ReverseMap();

			CreateMap<Product, CreateProductDTO>().ReverseMap();
			CreateMap<Product, ResultProductWithCategoryDTO>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();
		}
	}
}
