using System;

struct MyTime
{
    public int hour, minute, second;

    public MyTime(int h, int m, int s)
    {
        hour = h;
        minute = m;
        second = s;
    }

    //те як об'єкти типу вище будуть представленіу вигляді рядка
    public override string ToString()
    {
        return $"{hour:D}:{minute:D2}:{second:D2}";
    }
}

class Program
{
    static int ToSecSinceMidnight(MyTime t)
    {
        return t.hour * 3600 + t.minute * 60 + t.second;
    }

    static MyTime FromSecSinceMidnight(int t)
    {
        //всього секунд в одній добі
        int secPerDay = 60 * 60 * 24;
        //контролює вихід за рамки часового формату
        //щоб показувався час в рамках доби.

        // видаляє "доби" що накопичилися, залишаючи час без посередньо в рамках однієї доби
        while (t > secPerDay)
        {
            t -= secPerDay;
        }
        //додає "доби" на які відкотився годинник
        while (t < 0)
        {
            t += secPerDay;
        }
        //переведення в формат h m s
        int h = t / 3600;
        //спочатку ділить t на хвилини а потімь знаходить хвилини що не належать годинам
        int m = (t / 60) % 60;
        int s = t % 60;
        return new MyTime(h, m, s);
    }

    static MyTime AddOneSecond(MyTime t)
    {
        int totalSeconds = ToSecSinceMidnight(t) + 1;
        return FromSecSinceMidnight(totalSeconds);
    }

    static MyTime AddOneMinute(MyTime t)
    {
        int totalSeconds = ToSecSinceMidnight(t) + 60;
        return FromSecSinceMidnight(totalSeconds);
    }

    static MyTime AddOneHour(MyTime t)
    {
        int totalSeconds = ToSecSinceMidnight(t) + 3600;
        return FromSecSinceMidnight(totalSeconds);
    }

    static MyTime AddSeconds(MyTime t, int s)
    {
        int totalSeconds = ToSecSinceMidnight(t) + s;
        return FromSecSinceMidnight(totalSeconds);
    }

    static int Difference(MyTime mt1, MyTime mt2)
    {
        return ToSecSinceMidnight(mt1) - ToSecSinceMidnight(mt2);
    }

    static bool IsInRange(MyTime start, MyTime finish, MyTime t)
    {
        int startSec = ToSecSinceMidnight(start);
        int finishSec = ToSecSinceMidnight(finish);
        int timeSec = ToSecSinceMidnight(t);

        //за умови, що початок і кінець в рамках однієї доби
        if (startSec <= finishSec)
            return startSec <= timeSec && timeSec <= finishSec;
        //за умови, що початок і кінець НЕ в рамках однієї доби
        else
            return timeSec >= startSec || timeSec <= finishSec;
    }

    static string WhatLesson(MyTime mt)
    {
        if (ToSecSinceMidnight(mt) < ToSecSinceMidnight(new MyTime(8, 0, 0)))
            return "пари ще не почалися";

        MyTime[] lessonsStart = {
            new MyTime(8, 0, 0),
            new MyTime(9, 40, 0),
            new MyTime(11, 20, 0),
            new MyTime(13, 0, 0),
            new MyTime(14, 40, 0),
            new MyTime(16, 20, 0),
         };

        MyTime[] lessonsEnd = {
            new MyTime(9, 20, 0),
            new MyTime(11, 0, 0),
            new MyTime(12, 40, 0),
            new MyTime(14, 20, 0),
            new MyTime(16, 00, 0),
            new MyTime(17, 40, 0),
        };

        for (int i = 0; i < lessonsStart.Length; i++)
        {
            //перевіряє чи mt в проміжку часу пари
            if (IsInRange(lessonsStart[i], lessonsEnd[i], mt))
            {
                if(i + 1 ==3)
                {
                    return $"{i + 1}-я пара";
                }
                return $"{i + 1}-а пара";
            }
            //якщо ні, то перевіряє чи mt в проміжку між і-тою і+1 парою, за умови що і пара не є останньою
            else if (i < lessonsStart.Length - 1 && IsInRange(lessonsEnd[i], lessonsStart[i + 1], mt))
            {
                return $"перерва між {i + 1}-ю та {i + 2}-ю парами";
            }
        }

        return "пари вже скінчилися";
    }

    static void Main(string[] args)
    {
        MyTime currentTime1 = new MyTime(11, 45, 30);
        MyTime currentTime2 = new MyTime(7, 30, 0);
        MyTime currentTime3 = new MyTime(23, 55, 0);
        MyTime currentTime4 = new MyTime(12, 50, 0);
        MyTime currentTime5 = new MyTime(16, 0, 0);

        Console.WriteLine($"Поточний час 1: {currentTime1}, {WhatLesson(currentTime1)}");
        Console.WriteLine($"Поточний час 2: {currentTime2}, {WhatLesson(currentTime2)}");
        Console.WriteLine($"Поточний час 3: {currentTime3}, {WhatLesson(currentTime3)}");
        Console.WriteLine($"Поточний час 4: {currentTime4}, {WhatLesson(currentTime4)}");
        Console.WriteLine($"Поточний час 5: {currentTime5}, {WhatLesson(currentTime5)}");

        Console.WriteLine($"Секунди з початку доби 1 ({currentTime1}): {ToSecSinceMidnight(currentTime1)}");
        Console.WriteLine($"Секунди з початку доби 2 ({currentTime2}): {ToSecSinceMidnight(currentTime2)}");
        Console.WriteLine($"Секунди з початку доби 3 ({currentTime3}): {ToSecSinceMidnight(currentTime3)}");
        Console.WriteLine($"Секунди з початку доби 4 ({currentTime4}): {ToSecSinceMidnight(currentTime4)}");
        Console.WriteLine($"Секунди з початку доби 5 ({currentTime5}): {ToSecSinceMidnight(currentTime5)}");

        Console.WriteLine($"Віднімання 360 секунд від {currentTime1}: {AddSeconds(currentTime1,-360)}");

        Console.WriteLine($"Додавання однієї секунди до {currentTime2}: {AddOneSecond(currentTime2)}");
          
        Console.WriteLine($"Додавання однієї хвилини до {currentTime3}: {AddOneMinute(currentTime3)}");

        Console.WriteLine($"Додавання однієї години до {currentTime4}: {AddOneHour(currentTime4)}");

        Console.WriteLine($"Різниця між {currentTime1} і {currentTime2} : {Difference(currentTime1, currentTime2)} секунд");

        Console.WriteLine($"Чи {currentTime5} знаходиться у проміжку між {currentTime3} і {currentTime4}: {IsInRange(currentTime3, currentTime4, currentTime5)}");
    }
}
