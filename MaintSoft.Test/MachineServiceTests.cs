using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Asset;
using MaintSoft.Core.Models.Machine;
using MaintSoft.Core.Services;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Test
{
    [TestFixture]
    public class MachineServiceTests
    {
        private readonly IRepository repo;
        private MaintSoftDbContext maintSoftDbContext;
        private IMachineService machineService;
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
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");

            var result = await repo.GetByIdAsync<Machine>(1);

            Assert.That(result.Name, Is.EqualTo("Magnetic"));
        }

        [Test]
        public async Task TestCreateCheckUserCreator()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");

            var result = await repo.GetByIdAsync<Machine>(1);

            Assert.That(result.UserCreatedId, Is.EqualTo("createdUserId"));
        }

        [Test]
        public async Task TestDelete()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");
            await machineService.DeleteAsync(1, "createdUserId");

            var result = await repo.GetByIdAsync<Machine>(1);

            Assert.That(result.IsDelete, Is.EqualTo(true));
        }

        [Test]
        public async Task TestDeleteCheckUserDeleteId()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");
            await machineService.DeleteAsync(1, "createdUserId");

            var result = await repo.GetByIdAsync<Machine>(1);

            Assert.That(result.UserDeletedId, Is.EqualTo("createdUserId"));
        }

        [Test]
        public async Task TestEdit()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");

            var editModel = new AddMachineViewModel()
            {
                Name = "Thermal",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };
            await machineService.Edit(1, editModel);

            var result = await repo.GetByIdAsync<Machine>(1);

            Assert.That(result.Name, Is.EqualTo("Thermal"));
        }

        [Test]
        public async Task TestExists()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");

        

            var result = await machineService.Exists(1);

            Assert.That(result, Is.EqualTo(true));
        }


        [Test]
        public async Task TestGetAllMachine()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");

            var modelSecond = new AddMachineViewModel()
            {
                Name = "Thermal",
                Code = "GTW_202asdas",
                Description = "Thermal Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };
            await machineService.CreateAsync(modelSecond, "createdUserId");

            var result = await machineService.GetAllMachineAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TestGetAllMachineWhenZeroEntity()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

        
            var result = await machineService.GetAllMachineAsync();

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task TestGetMachineById()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");

            var modelSecond = new AddMachineViewModel()
            {
                Name = "Thermal",
                Code = "GTW_202asdas",
                Description = "Thermal Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };
            await machineService.CreateAsync(modelSecond, "createdUserId");

            var result = await machineService.GetMachineByIdAsync(2);

            Assert.That(result.Name, Is.EqualTo("Thermal"));
        }

        [Test]
        public async Task TestGetMachineByIdZeroEntity()
        {
            var loggerMock = new Mock<ILogger<MachineService>>();


            var repo = new Repository(maintSoftDbContext);
            machineService = new MachineService(repo);

            var model = new AddMachineViewModel()
            {
                Name = "Magnetic",
                Code = "GTW_202",
                Description = "Magnetic Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };

            await machineService.CreateAsync(model, "createdUserId");

            var modelSecond = new AddMachineViewModel()
            {
                Name = "Thermal",
                Code = "GTW_202asdas",
                Description = "Thermal Tester",
                Location = "Desto",
                ImageUrl = "pucture"
            };
            await machineService.CreateAsync(modelSecond, "createdUserId");

            var result = await machineService.GetMachineByIdAsync(3);

            Assert.That(result is null);
        }
    }
}
