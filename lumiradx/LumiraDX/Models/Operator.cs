using System.Collections.Generic;

namespace LumiraDX.Models
{
    public class Operator
    {
        public string OperatorValue { get; set; }

        public static IEnumerable<OperatorItem> GetOperatorItems()
        {
            List<OperatorItem> list = new List<OperatorItem>()
            {
                new OperatorItem() { Name = "Addition", Value = "+" },
                new OperatorItem() { Name = "Subtraction", Value = "-" },
                new OperatorItem() { Name = "Multiplication", Value = "*" },
                new OperatorItem() { Name = "Division", Value = "/" }
            };

            return list;
        }
    }

}