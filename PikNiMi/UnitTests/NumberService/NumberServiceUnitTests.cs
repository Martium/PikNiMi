using Microsoft.VisualStudio.TestTools.UnitTesting;
using PikNiMi.Forms.Service;

namespace UnitTests.NumberService
{
    [TestClass]
    public class NumberServiceUnitTests
    {
        private readonly PikNiMi.Repository.DependencyInjectionRepositoryClass.Service.NumberService _numberService;
        public NumberServiceUnitTests()
        {
            _numberService =
                new PikNiMi.Repository.DependencyInjectionRepositoryClass.Service.NumberService(
                    new InvariantCultureNumberService());
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

            if (firstValueCaseOneActualResult != null)
            {
                Assert.AreEqual(caseOneExpectedResult, firstValueCaseOneActualResult.Value);
            }
            else
            {
                Assert.Fail();
            }

            if (secondValueCaseOneActualResult != null)
            {
                Assert.AreEqual(caseOneExpectedResult, secondValueCaseOneActualResult.Value);
            }
            else
            {
                Assert.Fail();
            }

            Assert.IsNull(caseTwoIsNullResult);


        }
    }
}
