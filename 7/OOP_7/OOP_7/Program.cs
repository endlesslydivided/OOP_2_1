using System;
using System.Exception;
using System.IO;
using System.Diagnostics;
using OOP_7.Exceptions;
using OOP_7.Logger_;
using System.Linq;
using System.Threading.Tasks;


namespace OOP_7
{
    class Program
    {
        static async Task Main(string[] args)
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

#region LAB_6
            Army army_stream = new Army();

            Console.WriteLine("Введите название файла: ");
            using (StreamReader stream = new StreamReader(Console.ReadLine()))
            {
                while (stream.ReadLine() is string line)
                {
                    switch (line)
                    {

                        case "#Hunter":
                            army_stream.Add(new Army.Hunter(stream.ReadLine(), Convert.ToInt32(stream.ReadLine()), stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;
                        case "#Warrior":
                            army_stream.Add(new Army.Warrior(stream.ReadLine(), Convert.ToInt32(stream.ReadLine()), stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;
                        case "#Archer":
                            army_stream.Add(new Army.Archer(stream.ReadLine(), Convert.ToInt32(stream.ReadLine()), stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;
                        case "#Shaman":
                            army_stream.Add(new Army.Shaman(stream.ReadLine(), Convert.ToInt32(stream.ReadLine()), stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;
                        case "#Physic":
                            army_stream.Add(new Army.Physic(stream.ReadLine(), Convert.ToInt32(stream.ReadLine()), stream.ReadLine(), Convert.ToInt32(stream.ReadLine())));
                            break;

                        default:
                            break;
                    }
                }
            }
            foreach (Army.Characters i in army_stream)
            {
                if (i == null) break;
                Console.WriteLine(i.ToString());
            }
            #endregion

            #region LAB_7
            //Debugger.Break();
            string filepath = @"log.txt";
            //Debugger.Break();
            try
            {
                //Army.Warrior warrior_1 = new Army.Warrior("Имя", 34);
                //await Logger_.Logger_.WriteLog(warrior_1, toFile: true);
                Army.Warrior warrior_2 = new Army.Warrior("Warrio_2", 50, "", 210);
                await Logger_.Logger_.WriteLog(warrior_2, toFile: true);
                //Army.Warrior warrior_3 = new Army.Warrior("Warrio_3", 50, "Огненный молот", 2100);
                //await Logger_.Logger_.WriteLog(warrior_3, toFile: true);
                //Army.Warrior warrior_4 = new Army.Warrior("Warrio_4", 1001, "Огненный молот", 100);
                //await Logger_.Logger_.WriteLog(warrior_4, toFile: true);
                //Army.Warrior warrior_5 = new Army.Warrior("012345678901234567891",999, "Огненный молот", 100);
                //await Logger_.Logger_.WriteLog(warrior_5, toFile: true);
            }
            catch (InvalidNameException e)
            {
                filepath = @"log_error_name.txt";
                await FileLogger.WriteLog(e, _FilePath: @"log_error_name.txt");
            }
            catch (CharactersException e)
            {
                filepath = @"log_error_characters.txt";
                await FileLogger.WriteLog(e, _FilePath: @"log_error_characters.txt");
            }
            catch (AttackException e)
            {
                filepath = @"log_error_attack.txt";
                await FileLogger.WriteLog(e, _FilePath: @"log_error_attack.txt");
            }
            catch (MaxHPException e)
            {
                filepath = @"log_error_maxHP.txt";
                await FileLogger.WriteLog(e, _FilePath: @"log_error_maxHP.txt");
            }
            finally
            {
                await Task.Delay(0);
                Console.WriteLine("Нажмите на любую клавишу для открытия протокола\n");
                Console.ReadKey();
                Process.Start((new ProcessStartInfo(filepath) { UseShellExecute = true }));
                Console.WriteLine("Нажмите на любую клавишу для закрытия протокола");
                Console.ReadKey();
                Debugger.Break();
                var process = from proc in Process.GetProcesses() where proc.ProcessName == "notepad" select proc;
                foreach (var item in process)
                {
                    item.Kill();
                }
                Debugger.Break();
            }
            #endregion 
        }
    }
}
