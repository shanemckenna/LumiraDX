using System;

namespace LumiraDX.Models
{
    public class OperationViewModel
    {
        public int OperandValue1 { get; set; } = 0;
        public string Operator { get; set; }
        public int OperandValue2 { get; set; } = 0;

        public Decimal? Result { get; set; } = null;
        public String Message { get; set; } = string.Empty;

        public string FormattedMessage
        {
            get
            {
                if (Result.HasValue)
                    return string.Format("{0:###,##0.####}", Result.Value);
                else
                    return string.Empty;
            }
        }

    }

}