using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.DTOS.Account;
using RestaurantAPI.Core.Application.ViewModel.Dish;
using RestaurantAPI.Core.Application.ViewModel.DishIngredient;
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
            CreateMap<Ingredients, SaveIngredientViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.DishIngredients, opt => opt.Ignore());

            CreateMap<Ingredients, IngredientViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.DishIngredients, opt => opt.Ignore());

            CreateMap<Dish, DishViewModel>()
                .ForMember(x => x.Ingredient, opt => opt.MapFrom(x => x.DishIngredients.Select(x => x.Ingredient).ToList()))
                .ReverseMap()
                .ForMember(x => x.OrderDishes, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore());

            CreateMap<Dish, SaveDishViewModel>()
                .ReverseMap()
                .ForMember(x => x.OrderDishes, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore());

            CreateMap<DishIngredient,SaveDishIngredientViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Ingredient, opt => opt.Ignore())
                .ForMember(x => x.Dish, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore());

            CreateMap<DishCategory, DishCategoryViewModel>()
                .ReverseMap()
                .ForMember(x => x.Dishes, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore());

        }
    }
}
