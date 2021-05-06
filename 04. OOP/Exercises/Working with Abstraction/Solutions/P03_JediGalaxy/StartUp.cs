using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        private static int[,] galaxy;
        private static long playerStars = 0;

        private static void Main()
        {
            var input = Console.ReadLine()?
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            CreateGalaxy(input);

            string command;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                var playerPosition = command?
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evilPosition = Console.ReadLine()?
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                MoveEvil(evilPosition);
                MovePlayer(playerPosition);
            }

            Console.WriteLine(playerStars);
        }

        private static void MovePlayer(int[] playerPosition)
        {
            if (playerPosition != null)
            {
                var playerRow = playerPosition[0];
                var playerCol = playerPosition[1];

                while (playerRow >= 0
                       && playerCol < galaxy.GetLength(1))
                {
                    if (playerRow >= 0
                        && playerRow < galaxy.GetLength(0)
                        && playerCol >= 0 && playerCol < galaxy.GetLength(1))

                        playerStars += galaxy[playerRow, playerCol];

                    playerCol++;
                    playerRow--;
                }
            }
        }

        private static void MoveEvil(int[] evil)
        {
            if (evil != null)
            {
                var evilRow = evil[0];
                var evilCol = evil[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (evilRow >= 0
                        && evilRow < galaxy.GetLength(0)
                        && evilCol >= 0
                        && evilCol < galaxy.GetLength(1))

                        galaxy[evilRow, evilCol] = 0;
                    evilRow--;
                    evilCol--;
                }
            }
        }

        private static void CreateGalaxy(int[] input)
        {
            if (input != null)
            {
                var rows = input[0];
                var cols = input[1];

                galaxy = new int[rows, cols];

                var starValue = 0;

                for (var row = 0; row < rows; row++)
                    for (var col = 0; col < cols; col++)
                        galaxy[row, col] = starValue++;
            }
        }
    }
}