if (args.Length != 3)
{
    Console.WriteLine("Ошибка: нужно 3 аргумента: число1 число2 операция");
    return;
}

if (!int.TryParse(args[0], out int a) || !int.TryParse(args[1], out int b))
{
    Console.WriteLine("Ошибка: аргументы должны быть числами");
    return;
}

string op = args[2];
int result = 0;
switch (op)
{
    case "+": { result = a + b; Console.WriteLine(result); break; }
    case "-": { result = a - b; Console.WriteLine(result); break; }
    case "*": { result = a * b; Console.WriteLine(result); break; }
    case "/": {
                if (b == 0)
                {
                    Console.WriteLine("Error: division by zero!");
                    return;
                }
                result = a / b;
                Console.WriteLine(result);
                break;
        }
    default: { Console.WriteLine($"Error: unknown operation: {op}"); break; }
}