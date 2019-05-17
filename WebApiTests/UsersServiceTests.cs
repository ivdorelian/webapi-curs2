using curs_2_webapi.Models;
using curs_2_webapi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Linq;


namespace Tests
{
    public class UsersServiceTests
    {
        private IOptions<AppSettings> config;

        [SetUp]
        public void Setup()
        {
            config = Options.Create(new AppSettings
            {
                Secret = "dsadhjcghduihdfhdifd8ih"
            });
        }

        /// <summary>
        /// TODO: AAA - Arrange, Act, Assert
        /// </summary>
        [Test]
        public void ValidRegisterShouldCreateANewUser()
        {
            var options = new DbContextOptionsBuilder<FlowersDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(ValidRegisterShouldCreateANewUser))// "ValidRegisterShouldCreateANewUser")
              .Options;

            using (var context = new FlowersDbContext(options))
            {
                var usersService = new UsersService(context, config);
                var added = new curs_2_webapi.ViewModels.RegisterPostModel
                {
                    Email = "a@a.b",
                    FirstName = "fdsfsdfs",
                    LastName = "fdsfs",
                    Password = "1234567",
                    Username = "test_username"
                };
                var result = usersService.Register(added);

                Assert.IsNotNull(result);
                Assert.AreEqual(added.Username, result.Username);
            }
        }
    }
}