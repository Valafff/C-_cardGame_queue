using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.C__dz17_cardGame
{
	internal class Card
	{
		public byte Suit { get; set; }
		public string Type_Card { get; set; }
		public int Prioritet { get; set; }
		public Card CopyCard(Card obj)
		{
			this.Suit = obj.Suit;
			this.Type_Card = obj.Type_Card;
			this.Prioritet = obj.Prioritet;
			return this;
		}
		public void PtintCard()
		{
			if (Suit == 3 || Suit == 4)
			{
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Red;
			}
			if (Suit == 5 || Suit == 6)
			{
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
			}
			Console.Write($"{Convert.ToChar(Suit)}{Type_Card}|");
			Console.ResetColor();
		}
	}
}
