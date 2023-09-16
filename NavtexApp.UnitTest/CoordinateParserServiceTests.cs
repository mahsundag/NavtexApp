using NavtexApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavtexApp.UnitTest
{
    public class CoordinateParserServiceTests
    {
        private readonly ICoordinateParserService _service;

        public CoordinateParserServiceTests()
        {
            _service = new CoordinateParserService();
        }

        [Fact]
        public void GetExactText_ExtractsCorrectly()
        {
            // Arrange
            var inputText = "randomTextZCZC EA46\nWZ 700\nWALES ... BELL INOPERATIVE.\nNNNNasdlasdlsakd";
            var expectedText = "ZCZC EA46\nWZ 700\nWALES ... BELL INOPERATIVE.\nNNNN";

            // Act
            var result = _service.GetExactText(inputText);

            // Assert
            Assert.Equal(expectedText, result);
        }
    }
}
