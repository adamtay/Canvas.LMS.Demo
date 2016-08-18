using System;
using System.Threading.Tasks;
using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.Requests;
using Canvas.LMS.Demo.Core.Tests.Builders;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Canvas.LMS.Demo.Core.Tests
{
    [TestFixture]
    public class UsersCoordinatorTests
    {
        private UsersCoordinator _usersCoordinator;

        [SetUp]
        public void SetUp()
        {
            _usersCoordinator = new UsersCoordinator();
        }

        [Test]
        public async Task CanCreateUser()
        {
            CreateUserRequestDto createUserRequest = new CreateUserRequestDtoBuilder().Build();

            UserDto user = await _usersCoordinator.CreateUser(createUserRequest);

            user.Should().NotBeNull();
            Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
        }
    }
}