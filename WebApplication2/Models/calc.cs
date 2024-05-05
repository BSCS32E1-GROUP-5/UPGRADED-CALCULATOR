using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class calc
    {
        [Key]
        public int Number { get; set; }
        public int numberC { get; set; }
        public int numberF { get; set; }

        public int num1 { get; set; }
        public int num2 { get; set; }
        public int tot { get; set; }
        public string totInWords { get; set; }
        public string totInWordsC { get; set; }
        public string totInWordsF { get; set; }

        public calc()
        {
            totInWords = "";
            totInWordsC = "";
            totInWordsF = "";
        }
    }
}
