
using System;
using System.Reflection;

Console.WriteLine("Välkommen till Stress");
//Användaren bestämmer storlek på spelet
int width = 10;
int height = 10;

int snakePosY = height / 2;
int snakePosX = width / 2;

int candyX = 1;
int candyY = 1;

int result = 0;


int CountDownTimer(int timer)
{
    for (int i = timer; i > 0; i--)
    {
        System.Threading.Thread.Sleep(1000);
        timer--;
        Console.WriteLine("Spelet startar om... " + timer);

    }

    return timer;
}


void NewCandy()
{
    Random rnd = new Random();
    candyX = rnd.Next(1, (width - 1));
    candyY = rnd.Next(1, (height - 1));
}


void DrawBox(int width, int height)
{


    for (int y = 0; y < height; y++)
    {

        for (int x = 0; x < width; x++)
        {

            if (x < 1 || x > (width - 2))
            {
                Console.Write("#");
            }
            else if (y < 1 || y > (height - 2))
            {
                Console.Write("#");
            }
            else if (x == snakePosX && y == snakePosY)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (x == candyX && y == candyY)
            {
                Console.Write("¤");
            }
            else
            {
                Console.Write("-");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine("Points: " + result);



}

void MoveSnake(int width, int height)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.LeftArrow)
    {
        if (0 != snakePosX - 1)
        {
            snakePosX--;
        }
    }
    else if (keyInfo.Key == ConsoleKey.RightArrow)
    {
        if (width - 1 != snakePosX + 1)
        {
            snakePosX++;
        }

    }
    else if (keyInfo.Key == ConsoleKey.UpArrow)
    {
        if (0 != snakePosY - 1)
        {
            snakePosY--;
        }
    }
    else if (keyInfo.Key == ConsoleKey.DownArrow)
    {
        if (height - 1 != snakePosY + 1)
        {
            snakePosY++;
        }
    }
}


void EatCandy()
{
    if (snakePosX == candyX && snakePosY == candyY)
    {
        result++;
        NewCandy();
    }
}


CountDownTimer(4);
while (true)
{
    Console.Clear();
    DrawBox(width, height);
    MoveSnake(width, height);
    EatCandy();

}
