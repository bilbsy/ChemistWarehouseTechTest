using ReactCsharpExperienceProof.Services.PizzeriaService;

namespace ReactCsharpExpeienceProof.Tests.Tests;

public class PizzeriaTests : IClassFixture<CWDbContextSeedDataFixture>
{
    public PizzeriaTests(CWDbContextSeedDataFixture fixture)
    {
        _fixture = fixture;
    }

    private CWDbContextSeedDataFixture _fixture { get; }

    [Fact]
    public async Task GetPizzerias()
    {
        // Arrange
        var pizzeriaService = new PizzeriaService(_fixture.CreateContext());

        // Act
        var pizzerias = await pizzeriaService.GetPizzeriasList();

        // Assert
        Assert.NotNull(pizzerias);
        Assert.NotNull(pizzerias.Data);
        Assert.Contains(pizzerias.Data, d => "Southbank Pizzeria" == d.Name);
        Assert.Contains(pizzerias.Data, d => "Southbank" == d.Location);
    }

    [Fact]
    public async Task AddPizzerias()
    {
        // Arrange
        var pizzeriaService = new PizzeriaService(_fixture.CreateContext());
        (var Name, var Location) = ("Docklands Pizzeria", "Docklands");

        // Act
        var result = await pizzeriaService.AddPizzeria(Name, Location);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result?.Data?.Name, Name);
        Assert.Equal(result?.Data?.Location, Location);
    }

    [Fact]
    public async Task GetPizzeria()
    {
        // Arrange
        var pizzeriaService = new PizzeriaService(_fixture.CreateContext());

        // Act
        var pizzerias = await pizzeriaService.GetPizzeriasList();
        var pizzeriaId = pizzerias?.Data?.FirstOrDefault()?.Id;

        Assert.NotNull(pizzeriaId);

        var result = await pizzeriaService.GetPizzeria(pizzeriaId.Value);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(result.Data.Id, pizzeriaId);
    }
}