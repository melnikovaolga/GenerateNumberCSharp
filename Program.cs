namespace ConsoleApplication3 {
    class Program
    {
        static void ProcessThreeSignNumber (ref string num, int value) {
            if (value >= 100) {
                int degree = value / 100;
                if (degree == 1 || degree == 2)
                {
                    if (degree == 1)
                        num = String.Concat(num, "сто ");
                    else num = String.Concat(num, "двести ");
                }

                else
                {
                    ProcessThreeSignNumber(ref num, degree);
                    if (degree >= 5)
                        num = String.Concat(num, "сот ");
                    else  
                        num = String.Concat(num, "ста ");
                }
                ProcessThreeSignNumber(ref num, value % 100);
            }

            else if (value >= 20) {
                int degree = value / 10;
                if (degree == 4 || degree == 9) {
                    if (degree == 9)
                        num = String.Concat(num, "девяносто ");
                    else
                        num = String.Concat(num, "сорок ");
                }

                else {
                  ProcessThreeSignNumber(ref num, degree);
                  if (degree > 4)
                      num = String.Concat(num, "десят ");
                  else
                      num = String.Concat(num, "дцать ");
                }
                ProcessThreeSignNumber(ref num, value % 10);
            }

            else if (value >= 10) {
                switch (value) {
                    case 10:
                        num = String.Concat(num, "десять ");
                        break;
                    case 11:
                        num = String.Concat(num, "одиннадцать ");
                        break;
                    case 12:
                        num = String.Concat(num, "двенадцать ");
                        break;
                    case 13:
                        num = String.Concat(num, "тринадцать ");
                        break;
                    case 14:
                        num = String.Concat(num, "четырнадцать ");
                        break;
                    case 15:
                        num = String.Concat(num, "пятнадцать ");
                        break;
                    case 16:
                        num = String.Concat(num, "шестнадцать ");
                        break;
                    case 17:
                        num = String.Concat(num, "семнадцать ");
                        break;
                    case 18:
                        num = String.Concat(num, "восемнадцать ");
                        break;
                    case 19:
                        num = String.Concat(num, "девятнадцать ");
                        break;
                }
            }
             
            else if (value <= 10) {
                switch (value) {
                    case 9:
                        num = String.Concat(num, "девять");
                        break;
                    case 8:
                        num = String.Concat(num, "восемь");
                        break;
                    case 7:
                        num = String.Concat(num, "семь");
                        break;
                    case 6:
                        num = String.Concat(num, "шесть");
                        break;
                    case 5:
                        num = String.Concat(num, "пять");
                        break;
                    case 4:
                        num = String.Concat(num, "четыре");
                        break;
                    case 3:
                        num = String.Concat(num, "три");
                        break;
                    case 2:
                        num = String.Concat(num, "два");
                        break;
                    case 1:
                        num = String.Concat(num, "один");
                        break;
                    case 0:
                        break;
                }
            }
        }
        static void ProcessMillions (ref string num, int value) {
            ProcessThreeSignNumber (ref num, value);
            if ((value % 10 == 1) & (value % 100 != 11)) {
                num = String.Concat(num, " миллион ");
            }
            else if (((value % 10 == 2) & (value % 100 != 12)) | ((value % 10 == 3) & (value % 100 != 13)) | ((value % 10 == 4) & (value % 100 != 14))) {
                num = String.Concat(num, " миллиона ");
            }
            else if (value % 100 == 0) {}
            else {
                num = String.Concat(num, " миллионов ");
            }
        }
        static void ProcessThousands (ref string num, int value) {
            ProcessThreeSignNumber (ref num, value);
            if ((value % 10 == 1) & (value % 100 != 11)) {
                num = String.Concat(num.Substring(0, num.Length - 4), "одна тысяча ");
            }
            else if ((value % 10 == 2) & (value % 100 != 12)) {
                num = String.Concat(num.Substring(0, num.Length - 3), "две тысячи ");
            }
            else if (((value % 10 == 3) & (value % 100 != 13)) | ((value % 10 == 4) & (value % 100 != 14))) {
                num = String.Concat(num, " тысячи ");
            }
            else if (value % 100 == 0) {}
            else {
                num = String.Concat(num, " тысяч ");
            }
        }
        static void Main(string[] args) {

            int number = 1977765432;
            string num = "";

            if (number == 0)
                num = String.Concat(num, "ноль");
            else  {
                if (number >= 1000000000) {
                    if (number >= 2000000000) {num = String.Concat(num, "два миллиарда ");}
                    else
                        num = String.Concat(num, "один миллиард ");
                }
                if (number >= 1000000) { ProcessMillions(ref num, (number % 1000000000) / 1000000); }
                
                if (number >= 1000) { ProcessThousands(ref num, (number % 1000000) / 1000);}
                ProcessThreeSignNumber(ref num, number % 1000);
            }
  
            Console.WriteLine(num);
        }
    }
}