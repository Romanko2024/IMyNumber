
class Program_5 //var12. Нехай цифрам від 1 до 9 відповідають латинські (англійські) букви від А(а) до І(і). Прочитати з
                //клавіатури рядок символів. Скласти новий рядок з цифр, які відповідають тільки зазначеним буквам
                //(тобто, перетворивши 'A' та 'a' на '1', 'B' та 'b' на '2', 'C' та 'c' на '3', ..., 'I' та 'i'
                //на '9'); решту символів при цьому слід пропустити (видалити).
{
    static void Main()
    {
        string input = Console.ReadLine();
        string result = "";

        foreach (char c in input)
        {
            char convertedChar = ConvertChar(c);
            if (convertedChar != '\0') // Null
            {
                result += convertedChar;
            }
        }

        Console.WriteLine("Результат:");
        Console.WriteLine(result);
    }

    static char ConvertChar(char c)
    {
        switch (char.ToLower(c))
        {
            case 'a':
                return '1';
            case 'b':
                return '2';
            case 'c':
                return '3';
            case 'd':
                return '4';
            case 'e':
                return '5';
            case 'f':
                return '6';
            case 'g':
                return '7';
            case 'h':
                return '8';
            case 'i':
                return '9';
            default:
                return '\0'; 
        }
    }
}