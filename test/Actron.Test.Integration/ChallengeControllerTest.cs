using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Actron.Test.Integration
{
    public class ChallengeControllerTest
    {
        private ILogger<Actron.WebApi.Controllers.ChallengeController> _logger;
        private Actron.WebApi.services.ActronChallengeService _actronChallengeService;
        public ChallengeControllerTest()
        {
            _logger =  A.Fake<ILogger<Actron.WebApi.Controllers.ChallengeController>>();
            _actronChallengeService = new Actron.WebApi.services.ActronChallengeService();
        }

        [Fact]
        public void FormLargestInt_ValidInput_ReturnsOk()
        {
            //Arrange
            
            var controller = new Actron.WebApi.Controllers.ChallengeController(_logger, _actronChallengeService);
            var inputModel = new Actron.WebApi.models.InputModel();
            inputModel.Input = new List<int> { 10, 223, 78, 90, 99 };
            var expected = new Actron.WebApi.models.OutputModel();
            expected.Output = "99907822310";
            //Act
            var actual = controller.FormLargestInt(inputModel);
            //Assert
            var okResult = Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(actual);
            var actualOutputModel = Assert.IsType<Actron.WebApi.models.OutputModel>(okResult.Value);
            Assert.Equal(expected.Output, actualOutputModel.Output);
        }

        [Fact]
        public void formLargestInt_NonPositiveInteger_ReturnsBadRequest()
        {
            //Arrange
            var controller = new Actron.WebApi.Controllers.ChallengeController(_logger, _actronChallengeService);
            var inputModel = new Actron.WebApi.models.InputModel();
            inputModel.Input = new List<int> { -10, 223, 78, 90, 99 };
            //Act
            var actual = controller.FormLargestInt(inputModel);
            //Assert
            var badRequestResult = Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(actual);
            Assert.Equal("Invalid input array [non-positive integers or empty array]", badRequestResult.Value);
        }

        [Fact]
        public void formLargestInt_EmptyArray_ReturnsBadRequest()
        {
            //Arrange
            var controller = new Actron.WebApi.Controllers.ChallengeController(_logger, _actronChallengeService);
            var inputModel = new Actron.WebApi.models.InputModel();
            inputModel.Input = new List<int> { };
            //Act
            var actual = controller.FormLargestInt(inputModel);
            //Assert
            var badRequestResult = Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(actual);
            Assert.Equal("Invalid input array [non-positive integers or empty array]", badRequestResult.Value);

        }
    }
}