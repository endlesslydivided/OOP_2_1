using System;

namespace OOP_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior player_warrior = new Warrior("Игрок 1");
            Hunter player_hunter = new Hunter("Игрок 2");
            Archer player_archer = new Archer("Игрок 3");
            Shaman player_shaman = new Shaman("Игрок 4");
            Physic player_physic = new Physic("Игрок 5");
            Characters[] massive = new Characters[5];
            massive[0] = player_warrior;
            massive[1] = player_hunter;
            massive[2] = player_archer;
            massive[3] = player_shaman;
            massive[4] = player_physic;
            foreach (Characters i in massive)
            {
               Console.WriteLine(Printer.IAmPrinting(i));
            }
            IAction Iplayer_warrior = player_warrior as IAction;
            if (Iplayer_warrior is IAction)
                Iplayer_warrior.Forward();
            
            player_warrior.ScreamMotto_Attack();
            player_warrior.ScreamMotto_Defense();

            player_warrior.SayName();
            (player_warrior as IAction).Forward();
            (player_warrior as IAction).Right();
            (player_warrior as IAction).Left();
            (player_warrior as IAction).Back();
            Console.WriteLine(player_archer._CurrentHP);
          


        }
    }
}
