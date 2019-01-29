using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LumiraDX.Models
{
    public class Operand
    {
        [Required, Range(0, 99, ErrorMessage = "Number must be in the range 0 to 99")]
        public int OperandValue { get; set; }

        public static IEnumerable<OperandItem> GetOperandItems()
        {
            List<OperandItem> list = new List<OperandItem>();
            for (int i = 0; i <= 99; i++)
                list.Add(new OperandItem() { Name = i.ToString(), Value = i });
            return list;
        }
    }   
}