using System;
using System.Collections;
using System.IO;

namespace OOP_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Army.Warrior player_warrior = new Army.Warrior("Игрок 1",123);
            Army.Hunter player_hunter = new Army.Hunter("Игрок 2",234);
            Army.Archer player_archer = new Army.Archer("Игрок 3",345);
            Army.Shaman player_shaman = new Army.Shaman("Игрок 4",456);
            Army.Physic player_physic = new Army.Physic("Игрок 5",678);

            Army army = new Army();
            army.Add(player_archer);
            army.Add(player_warrior);
            army.Add(player_hunter);
            army.Add(player_physic);
            army.Add(player_shaman);
            foreach(Army.Characters i in army.massive)
            {
                if (i == null) break;
                Console.WriteLine(i.ToString());
            }
            army.Sort();
            Console.WriteLine("\nОтсортированные элементы");
            foreach (Army.Characters i in army.massive)
            {
                if (i == null) break;
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("\nСамая большая атака у персонажа:" + army.GetTheStrongest(army));
            IActionable Iplayer_warrior = player_warrior as IActionable;
            Army.Characters Cplayer_warrior = player_warrior as Army.Characters;
            if (Iplayer_warrior is IActionable)
                Iplayer_warrior.Forward();
            if (Cplayer_warrior is Army.Characters)
                Cplayer_warrior.ScreamMotto_Attack();

            player_warrior.ScreamMotto_Attack();
            player_warrior.ScreamMotto_Defense();

            Console.WriteLine(player_archer._CurrentHP);

            Army army_stream = new Army();

            Console.WriteLine("Введите название файла: ");
            using (StreamReader stream = new StreamReader(Console.ReadLine()))
            {
                while (stream.ReadLine() is string line)
                {
                    switch (line)
                    {

                        case "#Hunter":
                            army_stream.Add(new Army.Hunter(stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;
                        case "#Warrior":
                            army_stream.Add(new Army.Hunter(stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;
                        case "#Archer":
                            army_stream.Add(new Army.Hunter(stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;
                        case "#Shaman":
                            army_stream.Add(new Army.Hunter(stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;
                        case "#Physic":
                            army_stream.Add(new Army.Hunter(stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;

                        default:
                            break;
                    }
                }
            }
            foreach (Army.Characters i in army.army_stream)
            {
                if (i == null) break;
                Console.WriteLine(i.ToString());
            }


        }
    }
}
