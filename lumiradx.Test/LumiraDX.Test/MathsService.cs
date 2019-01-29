using LumiraDX.Models;
using LumiraDX.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LumiraDX.Test
{
    [TestClass]
    public class MathsServiceTest
    {
        MathsService mathsService;

        private string Addition = "Addition";
        private string Subtraction = "Subtraction";
        private string Multiplication = "Multiplication";
        private string Division = "Division";

        [TestInitialize]
        public void Initialize()
        {
            mathsService = new MathsService();
        }

        #region Addition
        [TestMethod]
        public void Check07Plus45Gives52()
        {
            Operation operation = new Operation()
            {
                OperandValue1 = 7,
                OperandValue2 = 45,
                OperatorType = OperatorType.Addition
            };

            OperationResult operationResult 
                = mathsService.PerformOperation(operation);

            CheckSuccessfulAssertions(52m, operationResult,this.Addition);
        }
        #endregion 
       
        #region Subtraction
        [TestMethod]
        public void Check45Less07Gives38()
        {
            Operation operation = new Operation()
            {
                OperandValue1 = 45,
                OperandValue2 = 7,
                OperatorType = OperatorType.Subtraction
            };

            OperationResult operationResult
                = mathsService.PerformOperation(operation);

            CheckSuccessfulAssertions(38m, operationResult, this.Subtraction);
        }
        #endregion

        #region Multiplication
        [TestMethod]
        public void Check05Times07Gives35()
        {
            Operation operation = new Operation()
            {
                OperandValue1 = 5,
                OperandValue2 = 7,
                OperatorType = OperatorType.Multiplication
            };

            OperationResult operationResult
                = mathsService.PerformOperation(operation);

            CheckSuccessfulAssertions(35m, operationResult, this.Multiplication);
        }
        #endregion

        #region Division
        [TestMethod]
        public void Check72DividedBy08Gives09()
        {
            Operation operation = new Operation()
            {
                OperandValue1 = 72,
                OperandValue2 = 8,
                OperatorType = OperatorType.Division
            };

            OperationResult operationResult
                = mathsService.PerformOperation(operation);

            CheckSuccessfulAssertions(9m, operationResult, this.Division);
        }


        [TestMethod]
        public void Check55DividedBy00Fails()
        {
            Operation operation = new Operation()
            {
                OperandValue1 = 55,
                OperandValue2 = 0,
                OperatorType = OperatorType.Division
            };

            OperationResult operationResult
                = mathsService.PerformOperation(operation);

            Assert.IsNull(operationResult.Result);
            Assert.AreEqual("Cannot perform operation: Cannot divide by zero.", operationResult.Message);
        }



        [TestMethod]
        public void Check25DividedBy02Gives12point5()
        {
            Operation operation = new Operation()
            {
                OperandValue1 = 25,
                OperandValue2 = 2,
                OperatorType = OperatorType.Division
            };

            OperationResult operationResult
                = mathsService.PerformOperation(operation);

            CheckSuccessfulAssertions(12.5m, operationResult, this.Division);
        }
        #endregion

        #region Helpers
        private void CheckSuccessfulAssertions(decimal expectedResult, OperationResult operationResult, string operationDescription)
        {
            Assert.IsNotNull(operationResult.Result);
            Assert.AreEqual(expectedResult, operationResult.Result.Value);
            Assert.AreEqual(string.Format("{0} successfully performed.", operationDescription), operationResult.Message);
        }
        #endregion

    }
}
