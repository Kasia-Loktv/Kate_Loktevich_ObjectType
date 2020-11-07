using System;

namespace ObjectType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите переменную: ");
            object veriable = Console.ReadLine();
            GetTypes(veriable);
            Console.ReadKey();
        }

        static void GetTypes(object value)
        {
            string valueString = Convert.ToString(value);
            string typeSwitch = "string";
            string type = "string";
            bool result;

            switch (typeSwitch)
            {
                case "string":
                    result = byte.TryParse(valueString, out byte valueByte);
                    if (result)
                    {
                        goto case "byte";
                    }

                    result = sbyte.TryParse(valueString, out sbyte valueSbyte);
                    if (result)
                    {
                        goto case "sbyte";
                    }

                    result = short.TryParse(valueString, out short valueShort);
                    if (result)
                    {
                        goto case "short";
                    }

                    result = ushort.TryParse(valueString, out ushort valueUshort);
                    if (result)
                    {
                        goto case "ushort";
                    }

                    result = int.TryParse(valueString, out int valueInt);
                    if (result)
                    {
                        goto case "int";
                    }

                    result = uint.TryParse(valueString, out uint valueUint);
                    if (result)
                    {
                        goto case "uint";
                    }

                    result = long.TryParse(valueString, out long valueLong);
                    if (result)
                    {
                        goto case "long";
                    }

                    result = ulong.TryParse(valueString, out ulong valueUlong);
                    if (result)
                    {
                        goto case "ulong";
                    }

                    result = float.TryParse(valueString, out float valueFloat);
                    if (result && Convert.ToString(valueFloat) == valueString)
                    {
                        goto case "float";
                    }

                    result = double.TryParse(valueString, out double valueDouble);
                    if (result && Convert.ToString(valueDouble) == valueString)
                    {
                        goto case "double";
                    }

                    result = decimal.TryParse(valueString, out decimal valueDecimal);
                    if (result)
                    {
                        goto case "decimal";
                    }

                    if (valueString == "true" || valueString == "false")
                    {
                        goto case "bool";
                    }

                    result = char.TryParse(valueString, out char valueChar);
                    if (result)
                    {
                        goto case "char";
                    }

                    break;

                case "int":
                    type = "int";
                    break;

                case "uint":
                    type = "uint";
                    break;

                case "sbyte":
                    type = "sbyte";
                    break;

                case "double":
                    type = "double";
                    break;

                case "byte":
                    type = "byte";
                    break;

                case "bool":
                    type = "bool";
                    break;

                case "long":
                    type = "long";
                    break;

                case "char":
                    type = "char";
                    break;

                case "ulong":
                    type = "ulong";
                    break;

                case "short":
                    type = "short";
                    break;

                case "ushort":
                    type = "ushort";
                    break;

                case "float":
                    type = "float";
                    break;

                case "decimal":
                    type = "decimal";
                    break;
            }
            Console.WriteLine("The type of {0} is {1}", valueString, type);

        }
    }
}
