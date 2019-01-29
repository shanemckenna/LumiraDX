using System;

namespace LumiraDX.Models
{
    public class OperationResult
    {
        public Operation Operation { get; set; } = null;
        public Decimal? Result { get; set; } = null;
        public String Message { get; set; } = string.Empty;
    }
}