using AutoMapper;
using Biogenom.Application.Interfaces;
using Biogenom.Application.Models;
using Biogenom.Domain;

namespace Biogenom.Persistence;

public class NutritionService : INutritionService
{
    private readonly INutritionRepository _repository;
    private readonly IMapper _mapper;

    public NutritionService(
        INutritionRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<NutritionReportDto> GetNutritionReportAsync()
    {
        var assessment = await _repository.GetLatestAssessmentAsync();
        if (assessment == null)
            throw new KeyNotFoundException("Assessment not found");

        return _mapper.Map<NutritionReportDto>(assessment);
    }
}