using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Canvas.LMS.Demo.Core.Coordinators;
using Canvas.LMS.Demo.Core.Domain;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Canvas.LMS.Demo.Core.Tests.Coordinators
{
    [TestFixture]
    public class AccountsCoordinatorTests
    {
        private AccountsCoordinator _accountsCoordinator;

        [SetUp]
        public void SetUp()
        {
            _accountsCoordinator = new AccountsCoordinator();
        }

        [Test]
        public async Task CanGetAccounts()
        {
            IEnumerable<AccountDto> accounts = await _accountsCoordinator.GetAccounts();
            accounts.Should().NotBeNullOrEmpty();
            Console.WriteLine(JsonConvert.SerializeObject(accounts));
        }
    }
}