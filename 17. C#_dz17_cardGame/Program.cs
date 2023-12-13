using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.C__dz17_cardGame
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Menu menu = new Menu(new List<string> { "Запустить игру в ручном режиме", "Запустить игру на указанное число раундов", "Выход" });
			menu.setMenuPoint = 0;
			int index;

			do
			{
				index = menu.KlacKlac_CS_v1();

				if (index == 0)
				{
					GameLogic newgame = new GameLogic();
					newgame.game();
				}
				if (index == 1)
				{
					GameLogic newgame = new GameLogic();
					int round;
                    Console.WriteLine();
                    Console.Write("Введите количество раундов(не более 100): ");
                    round = Convert.ToInt32 (Console.ReadLine());
					newgame.game(round);
				}
				if (index == 2)
				{
                    Console.WriteLine();
                    index = -1;
				}
			} while (index != -1);
		}
	}
}
