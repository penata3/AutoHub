namespace AutoHub.Services.Data.Tests
{
    using System.Threading.Tasks;

    using AutoHub.Data;
    using AutoHub.Data.Models;
    using AutoHub.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class SettingsServiceTests
    {

        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Settings.Add(new Setting());
            dbContext.Settings.Add(new Setting());
            dbContext.Settings.Add(new Setting());
            await dbContext.SaveChangesAsync();

            using var repository = new EfDeletableEntityRepository<Setting>(dbContext);
            var service = new SettingsService(repository);
            Assert.Equal(3, service.GetCount());
        }
    }
}
