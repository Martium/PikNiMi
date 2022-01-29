using Microsoft.VisualStudio.TestTools.UnitTesting;
using PikNiMi.Forms.Service;

namespace UnitTests.NumberService
{
    [TestClass]
    public class NumberServiceUnitTests
    {
        private readonly PikNiMi.Repository.DependencyInjectionRepositoryClass.Service.NumberService _numberService;
        private const string ExpectedNumberError = "Expected number but you get null";

        public NumberServiceUnitTests()
        {
            _numberService =
                new PikNiMi.Repository.DependencyInjectionRepositoryClass.Service.NumberService(
                    new InvariantCultureNumberService());
        }

        [TestMethod]
        public void TryParseStringToNumberOrNull_ParseToNumberOrNull_CaseOneReturnNumberCaseTwoReturnNull()
        {
            string caseOnePassedNumber = "1";
            string caseTwoPassedNotNumber = "not number";

            int caseOneExpectedResult = 1;

            int? caseOneActualResult = _numberService.TryParseStringToNumberOrNull(caseOnePassedNumber);
            int? caseTwoActualResult = _numberService.TryParseStringToNumberOrNull(caseTwoPassedNotNumber);

            if (caseOneActualResult.HasValue)
            {
                Assert.AreEqual(caseOneExpectedResult, caseOneActualResult.Value);
            }
            else
            {
                Assert.Fail(ExpectedNumberError);
            }

            Assert.IsNull(caseTwoActualResult);
        }


        [TestMethod]
        public void TryParseStringToDoubleNumberOrNull_ParseToNumberOrNull_CaseOneReturnNumberCaseTwoReturnNull()
        {
            string firstValueCaseOnePassedWithComma = "1,2";
            string secondValueCaseOnePassedWithDot = "1.2";

            double caseOneExpectedResult = 1.2;

            string caseTwoNotNumberPassed = "not number";

            double? firstValueCaseOneActualResult =
                _numberService.TryParseStringToDoubleNumberOrNull(firstValueCaseOnePassedWithComma);

            double? secondValueCaseOneActualResult =
                _numberService.TryParseStringToDoubleNumberOrNull(secondValueCaseOnePassedWithDot);

            double? caseTwoIsNullResult = _numberService.TryParseStringToDoubleNumberOrNull(caseTwoNotNumberPassed);

            if (firstValueCaseOneActualResult.HasValue)
            {
                Assert.AreEqual(caseOneExpectedResult, firstValueCaseOneActualResult.Value);
            }
            else
            {
                Assert.Fail(ExpectedNumberError);
            }

            if (secondValueCaseOneActualResult.HasValue)
            {
                Assert.AreEqual(caseOneExpectedResult, secondValueCaseOneActualResult.Value);
            }
            else
            {
                Assert.Fail(ExpectedNumberError);
            }

            Assert.IsNull(caseTwoIsNullResult);
        }
    }
}
