using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System;

namespace WebApplication2.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View(new calc());
        }

        [HttpPost]
        public ActionResult Index(calc c, string calculate)
        {
            if (calculate == "add")
            {
                c.tot = c.num1 + c.num2;
            }
            else if (calculate == "min")
            {
                c.tot = c.num1 - c.num2;
            }
            else if (calculate == "mul")
            {
                c.tot = c.num1 * c.num2;
            }
            else if (calculate == "div")
            {
                if (c.num2 != 0)
                {
                    c.tot = c.num1 / c.num2;
                }
                else
                {
                    ModelState.AddModelError("num2", "Cannot divide by zero.");
                    return View(c);
                }
            }
            else
            {
                ModelState.AddModelError("calculate", "Invalid calculation operation.");
                return View(c);
            }

            c.totInWords = NumberToWords(c.tot); // Convert the result to word number
            c.totInWordsC = NumberToWordsC(c.tot);
            c.totInWordsF = NumberToWordsF(c.tot);
            return View(c);
        }

        // Helper method to convert number to word
        private string NumberToWords(decimal number)
        {
            if (number == 0)
                return "zero";

            // Handle negative numbers if needed

            string[] thousandsGroups = { "", " thousand", " million", " billion" };

            int group = 0;
            string words = "";

            do
            {
                int thousands = Convert.ToInt32(number % 1000);
                if (thousands != 0)
                {
                    string thousandsWords = NumberToWordsLessThan1000(thousands);
                    words = thousandsWords + thousandsGroups[group] + " " + words;
                }
                number /= 1000;
                group++;
            } while (number > 0);

            return words.Trim();
        }

        private string NumberToWordsLessThan1000(int number)
        {
            string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] teens = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

            string words = "";

            if (number >= 100)
            {
                words += ones[number / 100] + " hundred ";
                number %= 100;
            }

            if (number >= 11 && number <= 19)
            {
                words += teens[number - 11] + " ";
            }
            else if (number >= 20)
            {
                words += tens[number / 10] + " ";
                number %= 10;
            }

            if (number >= 1 && number <= 9)
            {
                words += ones[number] + " ";
            }

            return words;
        }
        private string NumberToWordsC(decimal number)
        {
            if (number == 0)
                return "零";

            // Handle negative numbers if needed

            string[] thousandsGroups = { "", "千", "百万", "十亿" }; // Adjust as needed for larger numbers

            int group = 0;
            string words = "";

            do
            {
                int thousands = Convert.ToInt32(number % 1000);
                if (thousands != 0)
                {
                    string thousandsWords = NumberToWordsLessThan1000C(thousands);
                    words = thousandsWords + thousandsGroups[group] + " " + words;
                }
                number /= 1000;
                group++;
            } while (number > 0);

            return words.Trim();
        }

        private string NumberToWordsLessThan1000C(int numberC)
        {
            string[] onesC = { "", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            string[] tensC = { "", "十", "二十", "三十", "四十", "五十", "六十", "七十", "八十", "九十" };
            string[] teensC = { "", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九" };

            string words = "";

            if (numberC >= 100)
            {
                words += onesC[numberC / 100] + "百";
                numberC %= 100;
            }

            if (numberC >= 11 && numberC <= 19)
            {
                words += teensC[numberC - 11] + " ";
            }
            else if (numberC >= 20)
            {
                words += tensC[numberC / 10] + " ";
                numberC %= 10;
            }

            if (numberC >= 1 && numberC <= 9)
            {
                words += onesC[numberC] + " ";
            }

            return words;
        }
        private string NumberToWordsF(decimal number)
        {
            if (number == 0)
                return "zero";

            // Handle negative numbers if needed

            string[] thousandsGroups = { "", "libo", "milyon", "bilyon" }; // Adjust as needed for larger numbers

            int group = 0;
            string words = "";

            do
            {
                int thousands = Convert.ToInt32(number % 1000);
                if (thousands != 0)
                {
                    string thousandsWords = NumberToWordsLessThan1000F(thousands);
                    words = thousandsWords + thousandsGroups[group] + " " + words;
                }
                number /= 1000;
                group++;
            } while (number > 0);

            return words.Trim();
        }

        private string NumberToWordsLessThan1000F(int numberF)
        {
            string[] onesF = { "", "isa", "dalawa", "tatlo", "apat", "lima", "anim", "pito", "walo", "siyam" };
            string[] tensF = { "", "labing", "dalawampu", "tatlumpu", "apatnapu", "limampu", "animnapu", "pitumpu", "walumpu", "siyamnapu" };
            string[] teensF = { "", "labing-isa", "labing-dalawa", "labing-tatlo", "labing-apat", "labing-lima", "labing-anim", "labing-pito", "labing-walo", "labing-siyam" };

            string words = "";

            if (numberF >= 100)
            {
                words += onesF[numberF / 100] + "daan";
                numberF %= 100;
            }

            if (numberF >= 11 && numberF <= 19)
            {
                words += teensF[numberF - 11] + " ";
            }
            else if (numberF >= 20)
            {
                words += tensF[numberF / 10] + " ";
                numberF %= 10;
            }

            if (numberF >= 1 && numberF <= 9)
            {
                words += onesF[numberF] + " ";
            }

            return words;
        }


    }
}
