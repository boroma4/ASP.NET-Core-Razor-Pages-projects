﻿using System;
using System.Collections.Generic;
using GameEngine;
using MenuSystem;
using ConsoleUI;

namespace ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            var startMenu = new Menu(2)
            {
                Title = "Select Board Size",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Small board",
                            CommandToExecute = StartNewGame.SmallBoard
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Medium board",
                            CommandToExecute = StartNewGame.MediumBoard
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Large board",
                            CommandToExecute = StartNewGame.LargeBoard
                        }
                    },
                    {
                        "4", new MenuItem()
                        {
                            Title = "Custom size board",
                            CommandToExecute = StartNewGame.CustomSizeBoard
                        }
                    },
                }
            };

            var gameMenu = new Menu(1)
            {
                Title = "Start a new game of Connect4",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Computer starts",
                            CommandToExecute = null
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Human starts",
                            CommandToExecute = null
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Human against Human",
                            CommandToExecute = startMenu.Run
                        }
                    },
                }
            };

            var menu0 = new Menu(0)
            {
                Title = "Connect4 Main Menu",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "S", new MenuItem()
                        {
                            Title = "Start game",
                            CommandToExecute = gameMenu.Run
                        }
                    },
                    {
                        "L", new MenuItem()
                        {
                            Title = "Load game",
                            CommandToExecute = StartLoadedGame.StartFromAutosave
                        }
                    }
                }
            };
            menu0.Run();
        }
        
    }
}
