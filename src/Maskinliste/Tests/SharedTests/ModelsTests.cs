using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Maskinliste.Shared.InputModels;
using Maskinliste.Shared.ViewModels;
using Xunit;

namespace Maskinliste.Tests.SharedTests
{
    public class ModelsTests
    {
        [Fact]
        public void MachineViewModelShouldHaveName()
        {
            var model = new MachineViewModel
            {
                Id = 1,
                Name = null
            };

            var validateResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(model, new ValidationContext(model), validateResults, true);


            Assert.False(actual);
            Assert.Single(validateResults);
        }

        [Fact]
        public void MachineDetailsViewModelShouldHaveName()
        {
            var model = new MachineDetailsViewModel
            {
                Id = 1,
                Name = null,
                Details = "details"
            };

            var validateResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(model, new ValidationContext(model), validateResults, true);


            Assert.False(actual);
            Assert.Single(validateResults);
        }

        [Fact]
        public void MachineCreateInputModelShouldHaveName()
        {
            var model = new MachineCreateInputModel
            {
                Name = null,
                Details = "details",
                ApplicationUserName = "UserName"
            };

            var validateResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(model, new ValidationContext(model), validateResults, true);


            Assert.False(actual);
            Assert.Single(validateResults);
        }

        [Fact]
        public void MachineUpdateInputModelShouldHaveName()
        {
            var model = new MachineUpdateInputModel
            {
                Id = 1,
                Name = null,
                Details = "details"
            };

            var validateResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(model, new ValidationContext(model), validateResults, true);


            Assert.False(actual);
            Assert.Single(validateResults);
        }
    }
}