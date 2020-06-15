using System;
using MartianResearchingSystem.Core.Parsers;
using MartianResearchingSystem.Core.Spacing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianResearchingSystem.Tests.Parsing
{
    [TestClass]
    public class MarsSurfaceDataParserTests
    {
        [TestMethod]
        public void Should_Parse_IfData_Correctly()
        {
            // Arrange.
            const string inputString = "5 3";
            const int expectedWidth = 3;
            const int expectedLength = 5;

            var target = new MarsSurfaceDataParser();

            // Act.
            var result = target.ParseMarsSurface(inputString);

            // Assert.
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(MarsSurface));
            Assert.AreEqual(expectedWidth, result.Width);
            Assert.AreEqual(expectedLength, result.Length);
        }
    }
}
