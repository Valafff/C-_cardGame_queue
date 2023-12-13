using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.C__dz17_cardGame
{
	internal class GameLogic
	{
		Random random = new Random();
		//Колода карт
		public List<Card> deck = new List<Card>();
		//Масти
		public byte[] S = { 3, 4, 5, 6 };
		public string[] T = { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
		public string[] Name_player = { "Игрок 1", "Игрок 2" };
		//Игроки
		public List<Player> players = new List<Player>();

		//Поиск карты по приоритету
		List<Card> max_find = new List<Card>();
		public void setPlayer()
		{
			players.Add(new Player { Name = "Игрок 1" });
			players.Add(new Player { Name = "Игрок 2" });
		}
		//Составление калоды карт
		public void cardDeck()
		{
			for (int i = 0; i < S.Length; i++)
			{
				for (int j = 0; j < T.Length; j++)
				{
					deck.Add(new Card { Suit = S[i], Type_Card = T[j], Prioritet = j });
				}
			}
		}
		//Отрисовка карт игроков
		public void ShowCards()
		{
			Console.SetCursorPosition(0, 3);
			for (int i = 0; i < players.Count; i++)
			{
				Console.WriteLine(players[i].Name);
				players[i].ShowCards();
				//Console.WriteLine();
				Console.WriteLine();
			}
		}
		public void mixCards()
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < deck.Count; j++)
				{
					int ind = random.Next(deck.Count);
					Card card = new Card();
					card.CopyCard(deck[ind]);
					deck.RemoveAt(ind);
					deck.Add(card);
				}
			}
		}
		public void takeCard()//раздача карт
		{
			do
			{
				for (int i = 0; i < Name_player.Length; i++)
				{
					players[i].AddCards(deck[0]);
					deck.RemoveAt(0);
				}
			} while (deck.Count != 0);
		}
		//Отрисовка выложенной карты каждого игрока
		public void PutCard()
		{
			for (int i = 0; i < players.Count; i++)
			{
				if (players[i].CountQueue() > 0)
				{
					Console.SetCursorPosition(20 + (i * 10), 8);
					Console.WriteLine(players[i].Name);
					Console.SetCursorPosition(20 + (i * 10), 10);
					max_find.Add(players[i].PutCard());
				}
				else { players.RemoveAt(i); }
			}
		}
		public void MaxFind()
		{
			int max = max_find[0].Prioritet, ind = 0;
			for (int i = 0; i < max_find.Count; i++)
			{
				if (max_find[i].Prioritet > max)
				{
					max = max_find[i].Prioritet;
					ind = i;
				}
			}
			for (int i = 0; i < max_find.Count; i++)
			{
				players[ind].AddCards(max_find[i]);
			}
			max_find.Clear();
		}
		public void game(int arg_rounds = 0)
		{
			if(arg_rounds <= 0)	{ arg_rounds = 0; }
			if(arg_rounds > 100){ arg_rounds = 100; }
			cardDeck();
			mixCards();
			setPlayer();
			takeCard();
			ShowCards();
			if (arg_rounds == 0)
			{
				ConsoleKey key;
				do
				{

					key = Console.ReadKey(true).Key;
					if (key == ConsoleKey.Escape)
					{
						break;
					}
					do
					{
						Console.Clear();
						ShowCards();
						Console.Clear();
						PutCard();
						ShowCards();
						MaxFind();
						key = Console.ReadKey(true).Key;
						//PrinrBlack();
						ShowCards();
						key = Console.ReadKey(true).Key;
						if (key == ConsoleKey.Escape)
						{
							break;
						}
					} while (players.Count != 1);
					if (players[0].CountQueue() > players[1].CountQueue())
					{
						Console.WriteLine(players[0].Name + " победил");
					}
					else
					{
						Console.WriteLine(players[1].Name + " победил");
					}


					key = Console.ReadKey(true).Key;
					Console.Clear();
				} while (key != ConsoleKey.Escape);
			}
			else 
			{
				int count = 0;
				do
				{
					Console.Clear();
					//ShowCards();
					//Console.Clear();
					PutCard();
					ShowCards();
					MaxFind();

					//PrinrBlack();
					//ShowCards();
					count++;
					if ( count >= arg_rounds-1)
					{
						break;
					}
				} while (players.Count != 1);
				//Console.WriteLine(players[0].Name + " победил");
				ShowCards();
				if (players[0].CountQueue() > players[1].CountQueue())
				{
					Console.WriteLine(players[0].Name + " победил");
				}
				else
				{
					Console.WriteLine(players[1].Name + " победил");
				}
			}

		}



	}
}
