using Moq;
using AutoMapper;
using Biogenom.Application.Interfaces;
using Biogenom.Application.Mappers;
using Biogenom.Domain;
using Biogenom.Persistence;
using Microsoft.Extensions.Logging;
using Xunit;

public class NutritionServiceTests
{
    [Fact]
    public async Task GetNutritionReportAsync_ReturnsCorrectReport()
    {
        // Arrange
        var mockRepo = new Mock<INutritionRepository>();

        var testAssessment = new NutritionAssessment
        {
            AssessmentDate = DateTime.Now,
            Status = "Дефицит",
            Nutrients = new List<Nutrient>
            {
                new Nutrient
                {
                    Name = "Витамин C",
                    CurrentValue = 42.39,
                    NormValue = 100,
                    FromSupplements = 330,
                    FromFood = null
                },
                new Nutrient
                {
                    Name = "Витамин D",
                    CurrentValue = 6.1,
                    NormValue = 15,
                    FromSupplements = null,
                    FromFood = null
                }
            },
            Supplements = new List<Supplement>
            {
                new Supplement
                {
                    Name = "Протектор BioSetting",
                    Description = "Биосеттинг",
                    AlternativesCount = 10,
                    Benefits = new List<Benefit>
                    {
                        new Benefit { Text = "Устраняют витаминно-минеральный дефицит" },
                        new Benefit { Text = "Улучшают усвоение полезных веществ" }
                    }
                },
                new Supplement
                {
                    Name = "ED Smart",
                    Description = "Сохраняют Колизы вкус",
                    AlternativesCount = 5,
                    Benefits = new List<Benefit>
                    {
                        new Benefit { Text = "Компенсируют несбалансированное питание" }
                    }
                }
            }
        };

        mockRepo.Setup(r => r.GetLatestAssessmentAsync())
                .ReturnsAsync(testAssessment);

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            
        });

        var configuration = new MapperConfiguration(
            cfg => cfg.AddProfile<NutritionProfile>(),
            loggerFactory
        );
        
        var mapper = new Mapper(configuration);

        var service = new NutritionService(mockRepo.Object, mapper);

        // Act
        var result = await service.GetNutritionReportAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Дефицит", result.Status);
        Assert.Equal(2, result.Nutrients.Count);
        Assert.Equal(2, result.Supplements.Count);
        
        // Проверяем Benefits
        Assert.Equal(3, result.Benefits.Count);
        Assert.Contains("Устраняют витаминно-минеральный дефицит", result.Benefits);
        Assert.Contains("Улучшают усвоение полезных веществ", result.Benefits);
        Assert.Contains("Компенсируют несбалансированное питание", result.Benefits);
    }
}