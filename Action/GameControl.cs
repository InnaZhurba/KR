using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Action
{
    public class GameControl
    {
        public void AddGame(string command1, string command2, int stadionID, DateTime data, int numberofviewers, int resultID)
        {
            using (var dbcon = new DB())
            {
                var gam = new List<DataAccess.Game>()
                {
                    new DataAccess.Game(){ CommandFirst=command1, CommandSecond=command2, StadionId = stadionID, Data=data,NumberOfViewers=numberofviewers,ResultId=resultID}
                };
                dbcon.Games.AddRange(gam);//зберігаємо за допомогою entity проміжково дані
                dbcon.SaveChanges();//синхронізуємо з бд
            }
        }//Додавання гри
        public int AddResults(bool gamestatus,bool both, string winerName, string loserName)
        {
            int resultId = 1;
            using (var dbcon = new DB())
            {
                var gam = new List<DataAccess.Result>()
                {
                    new DataAccess.Result(){ GameStatus=gamestatus, Both=both, WinerId=winerName, LoserId=loserName}                    
                };
                dbcon.Results.AddRange(gam);//зберігаємо за допомогою entity проміжково дані
                dbcon.SaveChanges();//синхронізуємо з бд

                var remov = dbcon.Results.Where(Result => Result.WinerId == winerName).Where(Result => Result.LoserId == loserName);
                foreach (DataAccess.Result stad in remov)
                {
                    resultId = stad.Id;
                }
            }
            return resultId;
        }
        public List<string> DataReturning(string name1, string name2)
        {
            List<string> list = new List<string>();
            using (var dbcon = new DB())
            {
                var remov = dbcon.Games.Where(Game => (Game.CommandSecond == name2) && (Game.CommandFirst == name1));
                foreach(DataAccess.Game game in remov)
                {
                    list.Add(Convert.ToString(game.Data));
                }
            }
            return list;
        }

        public List<string> DataForFirstComand(string name1)
        {
            List<string> list = new List<string>();
            using (var dbcon = new DB())
            {
                var remov = dbcon.Games.Where(Game =>(Game.CommandFirst == name1));
                foreach (DataAccess.Game game in remov)
                {
                    list.Add(Convert.ToString(game.Data));
                }
            }
            return list;
        }//findgame 
        public List<string> SecondComandReturning(string name1, DateTime data)
        {
            List<string> list = new List<string>();
            using (var dbcon = new DB())
            {
                var remov = dbcon.Games.Where(Game => (Game.CommandFirst == name1) && (Game.Data == data));
                foreach (DataAccess.Game game in remov)
                {
                    list.Add(Convert.ToString(game.CommandSecond));
                }
            }
            return list;
        }//findgame 

        public void DeleteGame(string name, string sname, DateTime data)
        {
            using (var dbcon = new DB())
            {
                int i = 0;
                var resultId = dbcon.Games.Where(Game => (Game.CommandFirst == name) && (Game.CommandSecond == sname) && (Game.Data == data));
                foreach(DataAccess.Game game in resultId)
                {
                    i = game.ResultId;
                }
                var removResult = dbcon.Results.SingleOrDefault(Result => (Result.Id == i));
                var remov = dbcon.Games.SingleOrDefault(Game => (Game.CommandFirst == name) && (Game.Data == data) && (Game.CommandSecond == sname));
                if (remov != null && removResult!=null)
                {
                    dbcon.Results.Remove(removResult);
                    dbcon.Games.Remove(remov);
                    dbcon.SaveChanges();
                }
            }
        }//видалення гравця по імені та призвищу
        public void ModifyResults(string a, string b, DateTime data, bool gamestatus, bool both, string winerName, string loserName)
        {
            using(var dbcon = new DB())
            {
                int resid = 0;
                var id = dbcon.Games.Where(Game => (Game.CommandFirst == a) && (Game.CommandSecond == b) && (Game.Data == data));
                foreach(DataAccess.Game game in id)
                {
                    resid = game.ResultId;
                }
                var res = dbcon.Results.Where(Result => Result.Id == resid).FirstOrDefault();
                if(res !=null)
                {
                    res.GameStatus = gamestatus;
                    res.Both = both;
                    res.WinerId = winerName;
                    res.LoserId = loserName;
                    dbcon.SaveChanges();
                }
            }
        }
        public void ModifyGame(string name, string sname, string command1, string command2, int stadionID, DateTime data, int numberofviewers)
        {
            using (var dbcon = new DB())
            {
               

                var modify = dbcon.Games.Where(Game => Game.CommandFirst == name)
                                         .Where(Game => Game.CommandSecond == sname)
                                         .FirstOrDefault();
                if (modify != null)
                {
                    modify.CommandFirst= command1;
                    modify.CommandSecond = command2;
                    modify.StadionId = stadionID;
                    modify.Data = data;
                    modify.NumberOfViewers = numberofviewers;
                    dbcon.SaveChanges();
                }
            }
        }//Змінюємо дані про гравця

        public List<string> CommandsReturning()
        {
            List<string> stadion = new List<string>();
            using (var dbcon = new DB())
            {
                foreach (DataAccess.Company stad in dbcon.Companies)
                {
                    stadion.Add(stad.Name);
                }
            }
            return stadion;
        }//повертаємо значення команд
        public List<string> StadionReturning()
        {
            List<string> stadion = new List<string>();
            using (var dbcon = new DB())
            {
                foreach (DataAccess.Stadion stad in dbcon.Stadions)
                {
                    stadion.Add(stad.Name);
                }
            }
            return stadion;
        }//повертаємо значення стадіонів
        public int MaxNumberOfViewers(string name)
        {
            int number = 0;
            using (var dbcon = new DB())
            {
                var remov = dbcon.Stadions.Where(Stadion => Stadion.Name == name);
                foreach(DataAccess.Stadion stad in remov)
                {
                    number = stad.NumberOfPlaces;
                }
            }
            return number;
        }
        public int FindIdStadion(string name)
        {
            int number = 1;
            using (var dbcon = new DB())
            {
                var remov = dbcon.Stadions.Where(Stadion => Stadion.Name == name);
                foreach (DataAccess.Stadion stad in remov)
                {
                    number = stad.Id;
                }
            }
            return number;
        }

        public List<string> CommandsNameReturning()//повертаємо значення імені gamers
        {
            List<string> gi = new List<string>();
            int i = 0;
            using (var dbcon = new DB())
            {
                foreach (DataAccess.Game gamer in dbcon.Games)
                {
                    gi.Insert(i,gamer.CommandFirst+"-"+ gamer.CommandSecond);
                    i++;
                }
            }
            return gi;
        }
        public List<string> ReturnValues(string a, string b, DateTime data)
        {
            List<string> game = new List<string>();
            using (var dbcon = new DB())
            {
                var comp = dbcon.Games
                           .Where(Game => (Game.CommandFirst == a) && (Game.CommandSecond == b) && (Game.Data == data));
                foreach (DataAccess.Game compId1 in comp)
                {
                    game.Insert(0, compId1.CommandFirst);
                    game.Insert(1, compId1.CommandSecond);
                    game.Insert(2, Convert.ToString(compId1.Data));
                    game.Insert(3, Convert.ToString(compId1.StadionId));
                    game.Insert(4, Convert.ToString(compId1.ResultId));
                    game.Insert(5, Convert.ToString(compId1.NumberOfViewers));
                }
            }
            return game;
        }//повернення значень по имені і призвищу
        public string stadionreturningname(int a)
        {
            string name = "";
            using (var dbcon = new DB())
            {
                var remov = dbcon.Stadions.Where(Stadion => Stadion.Id == a);
                foreach (DataAccess.Stadion stad in remov)
                {
                    name = stad.Name;
                }
            }
            return name;
        }
        public List<string> resultsreturningname(int a)
        {
            List<string> name = new List<string>();
            using (var dbcon = new DB())
            {
                var remov = dbcon.Results.Where(Result => Result.Id == a);
                foreach (DataAccess.Result stad in remov)
                {
                    name.Add(Convert.ToString(stad.GameStatus));
                    name.Add(Convert.ToString(stad.Both));
                    name.Add(stad.WinerId);
                    name.Add(stad.LoserId);
                }
            }
            return name;
        }
        public List<string> ShowGame()//поверьаємо значення для виведення даних про гравця
        {
            List<string> full = new List<string>();
            using (var dbcon = new DB())
            {
                List<string> a2 = new List<string>();
                int i = 0;
                var comp = dbcon.Games;
                foreach (DataAccess.Game compl in comp)
                {
                    //a1.Insert(i, compl.StadionId);
                    //a2.Insert(i, compl.ResultId);
                    string stadionname = "", gamestatus="";

                    a2 = resultsreturningname(compl.ResultId);
                    if (Convert.ToBoolean(a2.ElementAt(0)) == true)
                    {
                        if (Convert.ToBoolean(a2.ElementAt(1)) == true)
                            gamestatus = "Нічия.";
                        else
                            gamestatus = "Переможець - " + a2.ElementAt(2);
                    }
                    else
                        gamestatus = "Гра ще не проведена.";
                        
                        

                    stadionname = stadionreturningname(compl.StadionId);
                    full.Insert(i, (i + 1) + ". " + compl.CommandFirst + " - " + compl.CommandSecond + " : " + "Стадіон: "+stadionname+" = " + Convert.ToString(compl.NumberOfViewers) + " глядачів; "+ "Результат гри: "+ gamestatus+" ");
                    i++;
                }
            }
            return full;
        }
        public List<string> result(int a)
        {
            List<string> list = new List<string>();
            //string healthstatus = "";
            using (var dbcon = new DB())
            {
                foreach (Result stat in dbcon.Results.Where(Result => Result.Id == a))
                {
                    // healthstatus = Convert.ToString(stat.HealthStatus);
                    list.Add(Convert.ToString(stat.GameStatus));
                    list.Add(Convert.ToString(stat.Both));
                    list.Add(stat.WinerId);
                    list.Add(stat.LoserId);
                }
            }
            return list;
            //return healthstatus;
        }//повертає значення result по id
        public List<string> stadion(int a)
        {
            List<string> list = new List<string>();
            //string healthstatus = "";
            using (var dbcon = new DB())
            {
                foreach (DataAccess.Stadion stat in dbcon.Stadions.Where(Stadion => Stadion.Id == a))
                {
                    //healthstatus = Convert.ToString(stat.HealthStatus);
                    list.Add(stat.Name);
                    list.Add(Convert.ToString(stat.NumberOfPlaces));
                }
            }
            return list;
            //return healthstatus;
        }//повертає значення result по id
    }
}
