﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace GameSquad
{
    public class Player
    {
        Random random = new Random();
        private string name;
        private List<int> cards = new List<int>();
        private static string topCard;
        private static bool gameRunning = true;

        public string Name {  get { return name; } }
        public static string TopCard { get { return topCard; } set { topCard = value; } }

        public static bool GameRunning { get { return gameRunning; } set { gameRunning = value; } }

        public static void clearConsole()
        {
            Console.Clear();
            Console.WriteLine("Top Card: " + TopCard);
        }

        public Player(string name)
        {
            cards.Add(random.Next(1, 11));
            cards.Add(random.Next(1, 11));
            cards.Add(random.Next(1, 11));
            cards.Add(random.Next(1, 11));
            this.name = name;
        }



        public void showPlayerLeftAndRightCards()
        {
            Console.WriteLine($"{name}, " + "Here are your left and right Cards\n" + $"{cards[0]} ? ? {cards[3]}");
        }
        
        public int Draw()
        {
            clearConsole();
            int randomCard = random.Next(1, 11);
            return randomCard;
        }

        public void Replace(int card)
        {

            int cardToReplaceIndex;
            bool retryReplace = false;
            do
            {
                clearConsole();
                Console.WriteLine("Select the card index in hand you want to replace (1-4)");
                if(!int.TryParse(Console.ReadLine(), out cardToReplaceIndex))
                {
                    retryReplace = true;
                } else
                {
                    break;
                }
            } while(cardToReplaceIndex < 1 || cardToReplaceIndex > 4 || retryReplace);
            int cardToReplace = cards[cardToReplaceIndex - 1];
            cards[cardToReplaceIndex - 1] = card; // replacing the card in the players deck
            TopCard = cardToReplace.ToString(); // setting the top card to be the thrown card from the player's deck
            clearConsole();
            Console.WriteLine(name + $" you have threw the card {cardToReplace} from your hand, and made it the top card!");
            Console.ReadLine();
        }   

        public void Drop(int card)
        {
            clearConsole();
            Console.WriteLine($"You have dropped the card into the graveyard and made {card} the top card");
            TopCard = card.ToString();
            Console.ReadLine();
        }

        public int Reveal()
        {
            GameRunning = false;
            Console.WriteLine(name + " Cards :\n");
            for(int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine(cards[i] + "\n");
            }
            Console.WriteLine(name + " Sum: " + cards.Sum());
            Console.ReadLine();
            return cards.Sum();
        }
            
    }
}
