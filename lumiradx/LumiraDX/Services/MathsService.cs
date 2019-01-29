using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LumiraDX.Models;

namespace LumiraDX.Services
{
    public class MathsService : IMathsService
    {
        public OperationResult PerformOperation(Operation operation)
        {
            string successfulFormat = "{0} successfully performed.";
            string failedFormat = "Cannot perform operation: {0}.";

            OperationResult operationResult =
                new OperationResult() { Operation = operation };
            
            if (operation.OperatorType == OperatorType.None)
            {
                operationResult.Result = null;
                operationResult.Message =
                    string.Format(failedFormat, "No operator specified");
            }
            else if (operation.OperatorType == OperatorType.Addition)
            {
                operationResult.Result = operation.OperandValue1 + operation.OperandValue2;
                operationResult.Message =
                    string.Format(successfulFormat, "Addition");
            }
            else if (operation.OperatorType == OperatorType.Subtraction)
            {
                operationResult.Result = operation.OperandValue1 - operation.OperandValue2;
                operationResult.Message =
                    string.Format(successfulFormat, "Subtraction");
            }
            else if (operation.OperatorType == OperatorType.Multiplication)
            {
                operationResult.Result = operation.OperandValue1 * operation.OperandValue2;
                operationResult.Message =
                    string.Format(successfulFormat, "Multiplication");
            }
            else if (operation.OperatorType == OperatorType.Division)
            {
                if (operation.OperandValue2 != 0)
                {
                    operationResult.Result = (decimal) operation.OperandValue1 / operation.OperandValue2;
                    operationResult.Message =
                        string.Format(successfulFormat, "Division");
                }
                else
                {
                    operationResult.Message = 
                        string.Format(failedFormat, "Cannot divide by zero");
                }
                
            }

            return operationResult;
        }

    }
}
