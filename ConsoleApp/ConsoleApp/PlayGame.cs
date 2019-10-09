﻿using System;
using ConsoleUI;
using GameEngine;

namespace ConsoleApp
{
    public  static class PlayGame
    {
        public static string SmallBoard()
        {
            StartGame(4, 5);
            return "";
        }

        public static string MediumBoard()
        {
            StartGame(7, 8);
            return "";
        }

        public static string LargeBoard()
        {
            StartGame(7, 10);
            return "";
        }
        public static string CustomSizeBoard()
        {
            Console.Clear();
            Console.WriteLine("Enter height of the board");
            Console.Write(">");
            var height = Console.ReadLine();
            
            Console.WriteLine("Enter width of the board");
            Console.Write(">");
            var width = Console.ReadLine();
            
            int.TryParse(height, out var h);
            int.TryParse(width, out var w);
            StartGame(h, w);
            return "";
        }
        private static string StartGame(int h, int w)
        {
            var turn = 0;
            var isPlayerOne = true;
            var game = new Game(h,w);
            var yCoordinate= new int [w];
            for (var i = 0; i < w; i++)
            {
                yCoordinate[i] = h-1;
            }
            Console.Clear();
            var done = false;
            do
            {
                Console.Clear();
                GameUI.PrintBoard(game);
                var userXint = -1;
                do
                {
                    Console.WriteLine ("Enter column number, Player " + (isPlayerOne ? "One" : "Two" ));
                    Console.Write(">");
                    var userX = Console.ReadLine();
                    if (!int.TryParse(userX, out userXint))
                    {
                        Console.WriteLine($"{userX} is not a number!");
                        userXint = -1;
                    }
                    else if (userXint >= w) userXint = -1;
                } while (userXint < 0 || yCoordinate[userXint] < 0);
                
                if (game.Move(yCoordinate[userXint], userXint) == "Ok")
                {
                    turn++;
                    yCoordinate[userXint]--;
                    isPlayerOne = !isPlayerOne;
                }
                done = turn == h*w;
            } while (!done);
            
            GameUI.PrintBoard(game);
            Console.WriteLine("Game Over.\n" + "Press any key to go back to menu");
            Console.ReadKey();
            Console.Clear();
            return "";
        }
    }
}