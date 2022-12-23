using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data.Common;
using MaintSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintSoft.Core.Models.Manufacturer;
using MaintSoft.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using MaintSoft.Core.Models.SparePart;

namespace MaintSoft.Test
{
    [TestFixture]
    public class SparePartServiceTests
    {
        private readonly IRepository repo;
        private MaintSoftDbContext maintSoftDbContext;
        private IManufacturerService manufacturerService;
        private ISparePartService sparePartService;

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
            var loggerMock = new Mock<ILogger<SparePartService>>();


            var repo = new Repository(maintSoftDbContext);
          
            sparePartService = new SparePartService(repo, manufacturerService);

            await repo.AddAsync<Manufacturer>(new Manufacturer{

                Name = "Festo",
                Address = "Plovdiv str.18",
                Contacts = "+359688",
                Description = "Production for cylinders",
                VAT = "bg 389 55 5",
                UserCreatedId = "userCreted"
            });

            await repo.SaveChangesAsync();

            var model = new SparePartViewModel()
            {
                Name = "Cylinder",
                Code = "DSNU-10-20-P-A",
                Description = "PVN Cylinder",
                ImageUrl = "picture",
                Location = "Desto",
                ManufacturerId = 1,
                Quantity = 2,

            };

            await sparePartService.Create(model, "createdUserId");

            var result = await repo.GetByIdAsync<SparePart>(1);

            Assert.That(result.Name, Is.EqualTo("Cylinder"));
        }
    }
}
