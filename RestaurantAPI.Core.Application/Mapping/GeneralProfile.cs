using AutoMapper;
using RestaurantAPI.Core.Application.DTOS.Account;
using RestaurantAPI.Core.Application.ViewModel.Ingredient;
using RestaurantAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Ingredients,SaveIngredientViewModel>()
                .ReverseMap()
                .ForMember(x=>x.Created,opt=>opt.Ignore())
                .ForMember(x=>x.CreatedBy,opt=>opt.Ignore())
                .ForMember(x=>x.Modified,opt=>opt.Ignore())
                .ForMember(x=>x.ModifiedBy,opt=>opt.Ignore())
                .ForMember(x=>x.DishIngredients,opt=>opt.Ignore());

            CreateMap<Ingredients,IngredientViewModelSerr>()
                .ReverseMap()
                .ForMember(x=>x.Created,opt=>opt.Ignore())
                .ForMember(x=>x.CreatedBy,opt=>opt.Ignore())
                .ForMember(x=>x.Modified,opt=>opt.Ignore())
                .ForMember(x=>x.ModifiedBy,opt=>opt.Ignore())
                .ForMember(x=>x.DishIngredients,opt=>opt.Ignore());
        }
       
    }
}
