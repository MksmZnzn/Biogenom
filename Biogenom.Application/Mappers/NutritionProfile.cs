using AutoMapper;
using Biogenom.Application.Models;
using Biogenom.Domain;

namespace Biogenom.Application.Mappers;

public class NutritionProfile : Profile
{
    public NutritionProfile()
    {
        CreateMap<Nutrient, NutrientDto>();
        CreateMap<Supplement, SupplementDto>();
        CreateMap<NutritionAssessment, NutritionReportDto>()
            .ForMember(dest => dest.Benefits, 
                opt => opt.MapFrom(src => src.Supplements
                    .Where(s => s.Benefits != null && s.Benefits.Any())
                    .SelectMany(s => s.Benefits)
                    .Select(b => b.Text)
                    .Distinct()
                    .ToList() ?? new List<string>())); // Добавляем fallback
    }
}