using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.C__dz17_cardGame
{
	internal class Player
	{
		public string Name { get; set; }
		Queue<Card> cards = new Queue<Card>();
		public void AddCards(Card card)
		{
			cards.Enqueue(card);
		}
		public void ShowCards()
		{
			foreach (Card card in cards)
			{
				card.PtintCard();
			}
		}
		public Card PutCard()
		{
			if (cards.Count != 0)
			{
				cards.Peek().PtintCard();
				Card card = new Card { Suit = cards.Peek().Suit, Type_Card = cards.Peek().Type_Card, Prioritet = cards.Peek().Prioritet };
				cards.Dequeue();
				return card;
			}
			else
			{ return null; }
		}
		public int CountQueue()
		{
			return cards.Count;
		}
	}
}
