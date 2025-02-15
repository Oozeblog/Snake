﻿using Snake;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.SetWindowSize(80, 25);
        Console.SetBufferSize(80, 25);

        Walls walls = new Walls(80, 25);
        walls.Draw();

        //Отрисовка точек

        Point p = new Point(4, 5, '*');

        Snakee snake = new Snakee(p, 4, Direction.RIGHT);
        snake.Draw();

        FoodCreator foodCreator = new FoodCreator(80, 25, '$');
        Point food = foodCreator.CreateFood();
        food.Draw();

        while (true)
        {
            if (walls.IsHit(snake) || snake.IsHitTail())
            {
                break;
            }
            if (snake.Eat(food))
            {
                food = foodCreator.CreateFood();
                food.Draw();
            }
            else
            {
                snake.Move();
            }

            Thread.Sleep(100);
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                snake.HandleKey(key.Key);
            }
        }
        WriteGameOver();
        Console.ReadLine();
    }


    static void WriteGameOver()
    {
        int xOffset = 25;
        int yOffset = 8;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(xOffset, yOffset++);
        WriteText("============================", xOffset, yOffset++);
        WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
        yOffset++;
        WriteText("Автор: ooze", xOffset + 2, yOffset++);
        WriteText("Курс Основы ООП от GeekBrains", xOffset + 1, yOffset++);
        WriteText("============================", xOffset, yOffset++);
    }

    static void WriteText(String text, int xOffset, int yOffset)
    {
        Console.SetCursorPosition(xOffset, yOffset);
        Console.WriteLine(text);
    }



}
