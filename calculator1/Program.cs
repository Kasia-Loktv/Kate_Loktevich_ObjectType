using System;

namespace calculator1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string str1;
            string str2;
            string op;
            string answer = "";
            bool isPositive_ans = true;
            bool isStart = true;

            while (true)
            {
                bool isPositive_1 = true;
                bool isPositive_2 = true;
                bool is_Digit = true;
                bool isDivideByZero = false;

                if (isStart)
                {
                    Console.Write("Первое число: ");
                    str1 = Console.ReadLine();
                    while (string.IsNullOrEmpty(str1))
                    {
                        Console.Write("Перепроверьте число и введите снова! ");
                        str1 = Console.ReadLine();
                    }
                    if (str1[0] == '-' && str1.Length > 1)
                    {
                        str1 = str1.Substring(1);
                        isPositive_1 = false;
                    }

                    while (is_Digit)
                    {
                        is_Digit = false;
                        foreach (char c in str1)
                        {
                            if (!Char.IsDigit(c))
                            {
                                is_Digit = true;
                                break;
                            }
                        }
                        if (is_Digit)
                        {
                            Console.Write("Перепроверьте число и введите снова! ");
                            str1 = Console.ReadLine();
                            while (string.IsNullOrEmpty(str1))
                            {
                                Console.Write("Перепроверьте число и введите снова! ");
                                str1 = Console.ReadLine();
                            }
                            if (str1[0] == '-' && str1.Length > 1)
                            {
                                str1 = str1.Substring(1);
                                isPositive_1 = false;
                            }
                        }
                        while (str1[0] == '0' && str1.Length > 1)
                        {
                            str1 = str1.Substring(1);
                        }
                    }
                }
                else
                {
                    str1 = answer;
                    isPositive_1 = isPositive_ans;
                }

                Console.Write("Операция: ");
                op = Console.ReadLine();
                while (!(op == "+" || op == "-" || op == "*" || op == "/"))
                {
                    Console.Write("Введите корректную операцию (+ - * /): ");
                    op = Console.ReadLine();
                }

                //Второе число

                Console.Write("Второе число: ");
                str2 = Console.ReadLine();
                while (string.IsNullOrEmpty(str2))
                {
                    Console.Write("Перепроверьте число и введите снова! ");
                    str2 = Console.ReadLine();
                }
                if (str2[0] == '-' && str2.Length > 1)
                {
                    str2 = str2.Substring(1);
                    isPositive_2 = false;
                }
                is_Digit = true;
                while (is_Digit || isDivideByZero)
                {
                    is_Digit = false;
                    foreach (char c in str2)
                    {
                        if (!Char.IsDigit(c))
                        {
                            is_Digit = true;
                            break;
                        }
                    }
                    if (is_Digit || isDivideByZero)
                    {
                        isDivideByZero = false;
                        Console.Write("Перепроверьте число и введите снова! ");
                        str2 = Console.ReadLine();
                        while (string.IsNullOrEmpty(str2))
                        {
                            Console.Write("Перепроверьте число и введите снова! ");
                            str2 = Console.ReadLine();
                        }
                        if (str2[0] == '-' && str2.Length > 1)
                        {
                            str2 = str2.Substring(1);
                            isPositive_2 = false;
                        }
                    }
                    while (str2[0] == '0' && str2.Length > 1)
                    {
                        str2 = str2.Substring(1);
                    }
                    if (op == "/" && str2 == "0")
                    {
                        isDivideByZero = true;
                        Console.WriteLine("Нельзя делить на ноль! ");
                    }

                }

                bool fromPlus = false;
                bool fromPlus_1_pos = false;
                bool fromPlus_2_pos = false;
                bool fromMinus = false;

                switch (op)
                {
                    case "+":
                        if (!fromMinus)
                        {
                            if (!isPositive_1 && !isPositive_2)
                            {
                                isPositive_ans = false;
                            }
                            else if (isPositive_1 && !isPositive_2)
                            {
                                fromPlus = true;
                                fromPlus_1_pos = true;
                                goto case "-";
                            }
                            else if (!isPositive_1 && isPositive_2)
                            {
                                fromPlus = true;
                                fromPlus_2_pos = true;
                                goto case "-";
                            }
                        }

                        if (str1.Length > str2.Length)
                        {
                            string t = str1;
                            str1 = str2;
                            str2 = t;
                        }

                        string str = "";

                        int n1 = str1.Length;
                        int n2 = str2.Length;
                        int diff = n2 - n1;

                        int carry = 0;

                        for (int i = n1 - 1; i >= 0; i--)
                        {
                            int sum = ((int)(str1[i] - '0') + (int)(str2[i + diff] - '0') + carry);
                            str += (char)(sum % 10 + '0');
                            carry = sum / 10;
                        }

                        for (int i = n2 - n1 - 1; i >= 0; i--)
                        {
                            int sum = ((int)(str2[i] - '0') + carry);
                            str += (char)(sum % 10 + '0');
                            carry = sum / 10;
                        }

                        if (carry > 0)
                            str += (char)(carry + '0');

                        char[] ch2 = str.ToCharArray();
                        Array.Reverse(ch2);
                        answer = new string(ch2);
                        break;

                    case "-":
                        bool isBoth_Minus = false;
                        if (!fromPlus)
                        {
                            if (!isPositive_1 && !isPositive_2)
                            {
                                isBoth_Minus = true;
                                isPositive_ans = false;
                            }
                            else if (isPositive_1 && !isPositive_2)
                            {
                                fromMinus = true;
                                goto case "+";
                            }
                            else if (!isPositive_1 && isPositive_2)
                            {
                                fromMinus = true;
                                isPositive_ans = false;
                                goto case "+";
                            }
                        }

                        bool isSmaller = false;
                        int n1_diff = str1.Length;
                        int n2_diff = str2.Length;

                        if (n1_diff < n2_diff)
                        {
                            isSmaller = true;
                        }
                        else if (n2_diff < n1_diff)
                        {
                            isSmaller = false;
                        }
                        else
                        {
                            for (int i = 0; i < n1_diff; i++)
                            {
                                if (str1[i] < str2[i])
                                {
                                    isSmaller = true;
                                    break;
                                }
                                else if (str1[i] > str2[i])
                                {
                                    isSmaller = false;
                                    break;
                                }
                            }
                        }
                        if (isSmaller)
                        {
                            string t = str1;
                            str1 = str2;
                            str2 = t;
                            isPositive_ans = false;
                            if (isBoth_Minus)
                            {
                                isPositive_ans = true;
                            }
                        }

                        if (fromPlus)
                        {
                            if ((isSmaller && fromPlus_1_pos) || (!isSmaller && fromPlus_2_pos))
                            {
                                isPositive_ans = false;
                            }
                            else if (isSmaller && fromPlus_2_pos)
                            {
                                isPositive_ans = true;
                            }
                        }

                        string str_diff = "";

                        n1_diff = str1.Length;
                        n2_diff = str2.Length;
                        int diff_diff = n1_diff - n2_diff;
                        int carry_diff = 0;

                        for (int i = n2_diff - 1; i >= 0; i--)
                        {
                          int sub = (((int)str1[i + diff_diff] - (int)'0') - ((int)str2[i] - (int)'0') - carry_diff);
                            if (sub < 0)
                            {
                                sub = sub + 10;
                                carry_diff = 1;
                            }
                            else
                            { 
                                carry_diff = 0; 
                            }

                            str_diff += sub.ToString();
                        }

                        for (int i = n1_diff - n2_diff - 1; i >= 0; i--)
                        {
                            if (str1[i] == '0' && carry_diff > 0)
                            {
                                str_diff += "9";
                                continue;
                            }
                            int sub = (((int)str1[i] - (int)'0') - carry_diff);
                            if (i > 0 || sub > 0)
                            {
                                str_diff += sub.ToString();
                            }
                            carry_diff = 0;
                        }

                        while (str_diff[str_diff.Length - 1] == '0' && str_diff.Length > 1)
                        {
                            str_diff = str_diff.Substring(0, str_diff.Length - 1);
                        }

                        char[] aa = str_diff.ToCharArray();
                        Array.Reverse(aa);
                        answer = new string(aa);
                        break;

                    case "*":
                        isPositive_ans = true;
                        if ((isPositive_1 || isPositive_2) && (!isPositive_1 || !isPositive_2))
                        {
                            isPositive_ans = false;
                        }

                        string num1 = str1;
                        string num2 = str2;
                        int len1 = num1.Length;
                        int len2 = num2.Length;
                        if (num1 == "0" || num1 == "0")
                        {
                            answer = "0";
                            break;
                        }

                        int[] result = new int[len1 + len2];
                        int i_n1 = 0;
                        int i_n2 = 0;
                        int i_mult;

                        for (i_mult = len1 - 1; i_mult >= 0; i_mult--)
                        {
                            int carry_mult = 0;
                            int n1_mult = num1[i_mult] - '0';
                            i_n2 = 0;

                            for (int j = len2 - 1; j >= 0; j--)
                            {
                                int n2_mult = num2[j] - '0';
                                int sum = n1_mult * n2_mult + result[i_n1 + i_n2] + carry_mult;
                                carry_mult = sum / 10;
                                result[i_n1 + i_n2] = sum % 10;
                                i_n2++;
                            }

                            if (carry_mult > 0) 
                            {
                                result[i_n1 + i_n2] += carry_mult;
                            }

                            i_n1++;
                        }

                        i_mult = result.Length - 1;
                        while (i_mult >= 0 && result[i_mult] == 0) 
                        {
                            i_mult--;
                        }
                        
                        answer = "";

                        while (i_mult >= 0)
                        {
                            answer += (result[i_mult--]);
                        }

                        break;

                    case "/":
                        isPositive_ans = true;
                        if ((isPositive_1 || isPositive_2)  && (!isPositive_1 || !isPositive_2))
                        {
                            isPositive_ans = false;
                        }

                        string number = str1;
                        int divisor = Convert.ToInt32(str2);
                        answer = "";

                        int idx = 0;
                        int temp = (int)(number[idx] - '0');

                        while (temp < divisor)
                        {
                            if (number.Length == idx + 1)
                            {
                                break;
                            }
                            temp = temp * 10 + (int)(number[idx + 1] - '0');
                            idx++;
                        }
                        ++idx;

                        while (number.Length > idx)
                        {
                            answer += (char)(temp / divisor + '0');

                            temp = (temp % divisor) * 10 + (int)(number[idx] - '0');
                            idx++;
                        }
                        answer += (char)(temp / divisor + '0');
                                              
                        break;
                }

                Console.Write("ОТВЕТ: ");
                if (answer == "0")
                {
                    isPositive_ans = true;
                }
                Console.Write(!isPositive_ans ? "-" : "");
                Console.WriteLine(answer + "\n");
                
                Console.WriteLine("Чтобы продолжить, нажмите 'y'. Чтобы начать сначала, нажмите 'n'.");
                string loop = Console.ReadLine();
                while (!(loop == "y" || loop == "n"))
                {
                    Console.WriteLine("Чтобы продолжить, нажмите 'y'. Чтобы начать сначала, нажмите 'n' !!!");
                    loop = Console.ReadLine();
                }
                if (loop == "y")

                {
                    isStart = false;
                }
                else if (loop == "n") 
                {
                    isPositive_ans = true;
                }
               
            }

        }
    }
}
