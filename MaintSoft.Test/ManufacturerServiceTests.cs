using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data.Common;
using MaintSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintSoft.Core.Models.Machine;
using MaintSoft.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using MaintSoft.Core.Models.Manufacturer;

namespace MaintSoft.Test
{
    [TestFixture]
    public class ManufacturerServiceTests
    {
        private readonly IRepository repo;
        private MaintSoftDbContext maintSoftDbContext;
        private IManufacturerService manufacturerService;

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
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");

            var result = await repo.GetByIdAsync<Manufacturer>(1);

            Assert.That(result.Name, Is.EqualTo("Festo"));
        }

        [Test]
        public async Task TestDelete()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");
            await manufacturerService.DeleteAsync(1, "createdUserId");

            var result = await repo.GetByIdAsync<Manufacturer>(1);

            Assert.That(result.IsDelete, Is.EqualTo(true));
        }


        [Test]
        public async Task TestDeleteCheckUserDeletetId()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");
            await manufacturerService.DeleteAsync(1, "createdUserId");

            var result = await repo.GetByIdAsync<Manufacturer>(1);

            Assert.That(result.UserDeletedId, Is.EqualTo("createdUserId"));
        }


        [Test]
        public async Task TestEdit()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");

            var editModel = new ManufacturerViewModel()
            {
                Name = "Omron",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };
            await manufacturerService.Edit(1, editModel);

            var result = await repo.GetByIdAsync<Manufacturer>(1);

            Assert.That(result.Name, Is.EqualTo("Omron"));
        }

        [Test]
        public async Task TestExists()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");


            var result = await manufacturerService.Exists(1);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task TestNotExists()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");


            var result = await manufacturerService.Exists(15);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task TestGetAllManufacturer()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");

            var secondModel = new ManufacturerViewModel()
            {
                Name = "Omron",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };
            await manufacturerService.CreateAsync(secondModel, "createdUserId");

            var result = await manufacturerService.GetAllManufacturerAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TestGetAllManufacturerWhenNotExist()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var result = await manufacturerService.GetAllManufacturerAsync();

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task TestGetManufacturerById()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");

            var secondModel = new ManufacturerViewModel()
            {
                Name = "Omron",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };
            await manufacturerService.CreateAsync(secondModel, "createdUserId");

            var result = await manufacturerService.GetManufacturerByIdAsync(2);

            Assert.That(result.Name, Is.EqualTo("Omron"));
        }
        [Test]
        public async Task TestGetManufacturerByIdWhenIdInvalid()
        {
            var loggerMock = new Mock<ILogger<ManufacturerService>>();


            var repo = new Repository(maintSoftDbContext);
            manufacturerService = new ManufacturerService(repo);

            var model = new ManufacturerViewModel()
            {
                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };

            await manufacturerService.CreateAsync(model, "createdUserId");

            var secondModel = new ManufacturerViewModel()
            {
                Name = "Omron",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",

            };
            await manufacturerService.CreateAsync(secondModel, "createdUserId");

            var result = await manufacturerService.GetManufacturerByIdAsync(15);

            Assert.That(result is null);
        }
    }
}
