namespace Maskinliste.Tests.ServerTests
{
    using Maskinliste.Server.Data;
    using Maskinliste.Server.Models;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using IdentityServer4.EntityFramework.Options;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    using Xunit;

    public class ServerDataModelTests : IDisposable
    {
        private readonly ApplicationDbContext dbContext;

        public ServerDataModelTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var operationalStoreOptions = Options.Create(new OperationalStoreOptions());
            this.dbContext = new ApplicationDbContext(options, operationalStoreOptions);
        }
        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        [Fact]
        public void MachineShouldHaveName()
        {
            var machine = new Machine
            {
                Name = null,
                Details = "asd",
                ApplicationUserId = Guid.NewGuid().ToString()
            };

            var validatorResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(machine, new ValidationContext(machine), validatorResults, true);

            Assert.False(actual);
            Assert.Single(validatorResults);
        }
    }
}