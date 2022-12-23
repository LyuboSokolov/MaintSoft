using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.AppTask;
using MaintSoft.Core.Services;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

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

        [Test]
        public async Task TestCreateAppTask()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);

            var model = new AddAppTaskViewModel()
            {
                Name = "firstTask1",
                CreatedDate = DateTime.Now,
                StatusId = 1,
                Status = Enumerable.Empty<Status>(),
                MachineId = 1,
                Machines = new List<MaintSoft.Infrastructure.Data.Machine>()

            };
            await appTaskService.CreateAsync(model, "userCreated");

            var result = await repo.GetByIdAsync<AppTask>(1);

            Assert.That(result.Name, Is.EqualTo("firstTask1"));
        }


        [Test]
        public async Task TestCreateAppTaskWithStatusFour()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);

            var model = new AddAppTaskViewModel()
            {
                Name = "firstTask1",
                CreatedDate = DateTime.Now,
                StatusId = 4,
                Status = Enumerable.Empty<Status>(),
                MachineId = 1,
                Machines = new List<MaintSoft.Infrastructure.Data.Machine>()

            };

            await appTaskService.CreateAsync(model, "userCreated");

            var result = await repo.GetByIdAsync<AppTask>(1);

            Assert.That(result.UserContractorId, Is.EqualTo("userCreated"));

        }



        [Test]
        public async Task TestNotExists()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);



            var result = await appTaskService.Exists(1);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task TestExists()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);

            await repo.AddAsync<AppTask>(new AppTask()
            {
                Name = "firstTask1",
                Description = "descriptionTaskFirst",
                StatusId = 1,
                CreatedDate = DateTime.Now,

                UserCreatedId = "userCreated",
                ApplicationUsersAppTasks = new List<ApplicationUserAppTask>(),
                MachinesAppTasks = new List<MachineAppTask>()
            });

            await repo.SaveChangesAsync();

            var result = await appTaskService.Exists(1);

            Assert.That(result, Is.EqualTo(true));

        }


        [Test]
        public async Task TestGetAppTaskById()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);

            await repo.AddAsync<AppTask>(new AppTask()
            {
                Name = "firstTask1",
                Description = "descriptionTaskFirst",
                StatusId = 1,
                CreatedDate = DateTime.Now,

                UserCreatedId = "userCreated",
                ApplicationUsersAppTasks = new List<ApplicationUserAppTask>(),
                MachinesAppTasks = new List<MachineAppTask>()
            });

            await repo.SaveChangesAsync();

            var result = await appTaskService.GetAppTaskByIdAsync(1);

            Assert.That(result.Name, Is.EqualTo("firstTask1"));
        }

        [Test]
        public async Task TestCompleteTask()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);

            await repo.AddAsync<Status>(new Status() { Id = 4, Name = "Done" });

            await repo.AddAsync<AppTask>(new AppTask()
            {
                Name = "firstTask1",
                Description = "descriptionTaskFirst",
                StatusId = 1,
                Status = new Status { Id = 1, Name = "New" },
                CreatedDate = DateTime.Now,
                UserCreatedId = "userCreated",
                ApplicationUsersAppTasks = new List<ApplicationUserAppTask>(),
                MachinesAppTasks = new List<MachineAppTask>()
            });

            await repo.SaveChangesAsync();

            await appTaskService.CompleteTaskAsync(1, "userCreated");

            var appTask = await repo.GetByIdAsync<AppTask>(1);

            Assert.That(appTask.StatusId, Is.EqualTo(4));

        }

        [Test]
        public async Task TestCompleteTaskCheckUserCompleted()
        {
            var loggerMock = new Mock<ILogger<AppTaskService>>();

            var repo = new Repository(maintSoftDbContext);
            appTaskService = new AppTaskService(repo, sparePartService);

            await repo.AddAsync<Status>(new Status() { Id = 4, Name = "Done" });

            await repo.AddAsync<AppTask>(new AppTask()
            {
                Name = "firstTask1",
                Description = "descriptionTaskFirst",
                StatusId = 1,
                Status = new Status { Id = 1, Name = "New" },
                CreatedDate = DateTime.Now,
                UserCreatedId = "userCreated",
                ApplicationUsersAppTasks = new List<ApplicationUserAppTask>(),
                MachinesAppTasks = new List<MachineAppTask>()
            });

            await repo.SaveChangesAsync();

            await appTaskService.CompleteTaskAsync(1, "userCompletedTask");

            var appTask = await repo.GetByIdAsync<AppTask>(1);

            Assert.That(appTask.UserContractorId, Is.EqualTo("userCompletedTask"));

        }



    }
}