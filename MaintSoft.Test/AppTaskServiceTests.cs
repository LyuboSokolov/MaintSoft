using MaintSoft.Core.Contracts;
using MaintSoft.Core.Services;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;

namespace MaintSoft.Test
{
    [TestFixture]
    public class AppTaskServiceTests
    {
        private readonly IRepository repo;


        private ISparePartService sparePartService;
        private MaintSoftDbContext maintSoftDbContext;
        private IAppTaskService appTaskService;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<MaintSoftDbContext>()
                .UseInMemoryDatabase("AppTaskDB")
                .Options;

            maintSoftDbContext = new MaintSoftDbContext(contextOptions);

            maintSoftDbContext.Database.EnsureDeleted();
            maintSoftDbContext.Database.EnsureCreated();
        }
        [Test]
        public async Task TestGetAllStatus()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);

            await repo.AddAsync(new Status()
            {
                Id = 1,
                Name = "one"

            });
            await repo.AddAsync(new Status()
            {
                Id = 2,
                Name = "two"
            });
            await repo.SaveChangesAsync();

            var result = await appTaskService.GetAllStatusAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.FirstOrDefault(x => x?.Id == 1).Name, Is.EqualTo("one"));
        }

        [Test]
        public async Task TestGetStatusById()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);

            await repo.AddAsync(new Status()
            {
                Id = 1,
                Name = "one"

            });
            await repo.AddAsync(new Status()
            {
                Id = 2,
                Name = "two"
            });
            await repo.SaveChangesAsync();

            var result = await appTaskService.GetStatusByIdAsync(2);

            Assert.That(result.Name, Is.EqualTo("two"));
  
        }
    }
}