using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data.Common;
using MaintSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintSoft.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using MaintSoft.Core.Models.AppTask;
using MaintSoft.Core.Models.Asset;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MaintSoft.Test
{
    [TestFixture]
    public class AssetServiceTest
    {
        private readonly IRepository repo;


        private IUserService userService;
        private MaintSoftDbContext maintSoftDbContext;
        private IAssetService assetService;

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
        public async Task TestCreate()
        {
            var loggerMock = new Mock<ILogger<AssetService>>();


            var repo = new Repository(maintSoftDbContext);
            assetService = new AssetService(repo, userService);

            await repo.AddAsync<ApplicationUser>(new ApplicationUser()
            {
                Id = "ApplicationUserId",
                UserName = "peca",
                Email = "pesho@petrov",
                FirstName = "Pesho",
                LastName = "Petrov",
                JobPosition = "operator",
                IsDelete = false,

            });
            await repo.SaveChangesAsync();


            var model = new AddAssetViewModel()
            {
                Name = "Samsung",
                Description = "Description",
                IsAvailable = true,
                ApplicationUserId = "ApplicationUserId",
                ApplicationUsers = new List<ApplicationUser>()

            };

            await assetService.CreateAsync(model, "ApplicationUserId");

            var result = await repo.GetByIdAsync<Asset>(1);

            Assert.That(result.Name, Is.EqualTo("Samsung"));
        }

        [Test]
        public async Task TestCreateAndCheckApplicationUser()
        {
            var loggerMock = new Mock<ILogger<AssetService>>();


            var repo = new Repository(maintSoftDbContext);
            assetService = new AssetService(repo, userService);

            await repo.AddAsync<ApplicationUser>(new ApplicationUser()
            {
                Id = "ApplicationUserId",
                UserName = "peca",
                Email = "pesho@petrov",
                FirstName = "Pesho",
                LastName = "Petrov",
                JobPosition = "operator",
                IsDelete = false,

            });
            await repo.SaveChangesAsync();


            var model = new AddAssetViewModel()
            {
                Name = "Samsung",
                Description = "Description",
                IsAvailable = true,
                ApplicationUserId = "ApplicationUserId",
                ApplicationUsers = new List<ApplicationUser>()

            };

            await assetService.CreateAsync(model, "ApplicationUserId");

            var result = await repo.GetByIdAsync<Asset>(1);

            Assert.That(result.ApplicationUser.Id, Is.EqualTo("ApplicationUserId"));
        }

        [Test]
        public async Task TestGetAll()
        {
            var loggerMock = new Mock<ILogger<AssetService>>();


            var repo = new Repository(maintSoftDbContext);
            assetService = new AssetService(repo, userService);

            await repo.AddAsync<ApplicationUser>(new ApplicationUser()
            {
                Id = "ApplicationUserId",
                UserName = "peca",
                Email = "pesho@petrov",
                FirstName = "Pesho",
                LastName = "Petrov",
                JobPosition = "operator",
                IsDelete = false,

            });
            await repo.SaveChangesAsync();


            var model = new AddAssetViewModel()
            {
                Name = "Samsung",
                Description = "Description",
                IsAvailable = true,
                ApplicationUserId = "ApplicationUserId",
                ApplicationUsers = new List<ApplicationUser>()

            };

            await assetService.CreateAsync(model, "ApplicationUserId");

            var result = await assetService.GetAllAssetsAsync();

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestGetAllWithZeroEntity()
        {
            var loggerMock = new Mock<ILogger<AssetService>>();


            var repo = new Repository(maintSoftDbContext);
            assetService = new AssetService(repo, userService);

            var result = await assetService.GetAllAssetsAsync();

            Assert.That(result.Count, Is.EqualTo(0));
        }
    }

}
