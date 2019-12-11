using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Action
{
    public class GamerControl
    {
        public void AddGamer(string fname, string sname, bool status, bool healthstatus, double salery, string command)
        {
            //FootballGamer footballGamer = new FootballGamer(fname, sname, status, healthstatus, salery, command);
            int stId = StatusValue(status, healthstatus);//визначаємо який стан здоров'я та чи грає гравець в іграх
            int compId = CompanyValue(command);// визначаємо id команди за яку грає гравець
            using (var dbcon = new DB())
            {
                var gam = new List<Gamer>()
                {
                    new Gamer(){ FirstName=fname, SecondName=sname, StatusId=stId, CompanyId=compId, Salery=salery}
                };
                dbcon.Gamers.AddRange(gam);//зберігаємо за допомогою entity проміжково дані
                dbcon.SaveChanges();//синхронізуємо з бд

                //Можливий варіант збереження даних
                //var gamer = new Gamer()
                //{
                //    FirstName = fname,
                //    SecondName = sname,
                //    StatusId = stId,
                //    CompanyId = compId,
                //    Salery = salery
                //};
                //dbcon.Gamers.Add(gamer);//зберігаємо за допомогою entity проміжково дані
                //dbcon.SaveChanges();//синхронізуємо з бд 
            }
        }//Додавання гравця 
        public int StatusValue(bool status, bool healthstatus)
        {
            int stId;
            if (status && healthstatus)
                stId = 4;
            else if (status && !healthstatus)
                stId = 3;
            else if (!status && healthstatus)
                stId = 2;
            else
                stId = 1;
            return stId;
        }//визначаємо який стан здоров'я та чи грає гравець в іграх
        public int CompanyValue(string command)// визначаємо id команди за яку грає гравець
        {
            int compId = new int();
            using (var dbcon = new DB())
            {
                var comp = dbcon.Companies
                           .Where(Company => Company.Name == command);

                foreach (Company compId1 in comp)
                {
                    compId = Convert.ToInt32(compId1.Id);
                }
            }
            return compId;
        }

        public void DeleteGamer(string name, string sname)
        {
            using (var dbcon = new DB())
            {
                var remov = dbcon.Gamers.FirstOrDefault(Gamer => (Gamer.FirstName == name) && (Gamer.SecondName == sname)); 
                if (remov != null)
                {
                    dbcon.Gamers.Remove(remov);
                    dbcon.SaveChanges();
                }
            }
        }//видалення гравця по імені та призвищу
        public string ModifyGamer(string name, string sname, string newname, string newsname, bool status, bool healthstatus, double salery, string command)
        {
            string result;
            using (var dbcon = new DB())
            {
                var modify = dbcon.Gamers.Where(Gamer => Gamer.FirstName == name)
                                         .Where(Gamer => Gamer.SecondName == sname)
                                         .FirstOrDefault();
                if (modify != null)
                {
                    modify.FirstName = newname;
                    modify.SecondName = newsname;
                    int stat = StatusValue(status, healthstatus);
                    modify.StatusId = stat;
                    modify.Salery = salery;
                    int comp = CompanyValue(command);
                    modify.CompanyId = comp;
                    dbcon.SaveChanges();
                    result = "Data modify!";
                }
                else
                    result = "There are no data with that name and secondname.";
                return result;
            }
        }//Змінюємо дані про гравця

        public List<string> StadionReturning()//повертаємо значення назв Команд
        {
            List<string> stadion = new List<string>();
            using (var dbcon = new DB())
            {
                //var stad = dbcon.Stadions.SingleOrDefault();
                foreach (DataAccess.Company stad in dbcon.Companies)
                {
                    stadion.Add(stad.Name);
                }
            }
            return stadion;
        }//повертаємо значення стадіонів
        public List<string> GamerFirstNameReturning()//повертаємо значення імені gamers
        {
            List<string> gi = new List<string>();
            using (var dbcon = new DB())
            {
                foreach (DataAccess.Gamer gamer in dbcon.Gamers)
                {
                    gi.Add(gamer.FirstName);
                }                
            }
            return gi;
        }
        public List<string> GamerSecondNameReturning()//повертаємо значення призвища гравців
        {
            List<string> gi = new List<string>();
            using (var dbcon = new DB())
            {
                foreach (DataAccess.Gamer gamer in dbcon.Gamers)
                {
                    gi.Add(gamer.SecondName);
                }
            }
            return gi;
        }
        public List<string> ReturnValues(string a,string b)
        {
            List<string> footballgamer = new List<string>();
            using (var dbcon = new DB())
            {
                var comp = dbcon.Gamers
                           .Where(Gamer => Gamer.FirstName == a)
                           .Where(Gamer => Gamer.SecondName == b);
                foreach (Gamer compId1 in comp)
                {
                    footballgamer.Insert(0,compId1.FirstName);
                    footballgamer.Insert(1,compId1.SecondName);
                    footballgamer.Insert(2,Convert.ToString(compId1.Salery));
                    footballgamer.Insert(3, statusforgamevalue(compId1.StatusId));
                    footballgamer.Insert(4, healthstatusvalue(compId1.StatusId));
                    footballgamer.Insert(5, comandvalue(compId1.CompanyId));
                }                               
            }            
            return footballgamer;
        }//повернення значень по имені і призвищу
        //public List<string> statusReturn(int compId,int compId1)
        //{
        //    List<string> footballgamer = new List<string>();
        //    using (var dbcon = new DB())
        //    {
        //        var comp1 = dbcon.Companies
        //                  .Where(Company => Company.Id == compId1);
        //        var comp2 = dbcon.Statuses
        //                  .Where(Status => Status.Id == compId);
        //        foreach (Status stat in comp2)
        //        {

        //            footballgamer.Insert(0,Convert.ToString(stat.StatusForGame));
        //            footballgamer.Insert(1,Convert.ToString(stat.HealthStatus));
        //        }
        //        foreach (Company comp in comp1)
        //        {
        //            footballgamer.Insert(2,comp.Name);
        //        }
        //    }
        //    return footballgamer;
        //}//повернення значень статусу та назви команди по id від гравця
        public List<string> ShowGamer()//поверьаємо значення для виведення даних про гравця
        {
            List<string> full = new List<string>();
            using (var dbcon = new DB())
            {
                List<int> a1 = new List<int>();
                List<int> a2 = new List<int>();
                int i = 0;
                var comp = dbcon.Gamers;
                foreach (Gamer compl in comp)
                {
                    a1.Insert(i,compl.StatusId);
                    a2.Insert(i,compl.CompanyId);
                    full.Insert(i,(i+1)+". " + compl.FirstName + " " + compl.SecondName + " : " + "Заробіток: "+ Convert.ToString(compl.Salery) + " грн.;" + " ");
                    i++;
                }
                for(int j=0;j<full.Count;j++)
                {
                    string statusforgame="", healthstatus="", comand="";
                    statusforgame = statusforgamevalue(a1[j]);
                    healthstatus = healthstatusvalue(a1[j]);
                    comand = comandvalue(a2[j]);
                    string value;
                    value = full.ElementAt(j);
                    full.RemoveAt(j);
                    full.Insert(j, value + "Статус здоров'я: " + healthstatus + "; Cтатус для гри: " + statusforgame + "; " + "Команда: " + comand + " ");             
                }          
            }           
            return full;
        }
        public string statusforgamevalue(int a)
        {
            string statusforgame="";
            using(var dbcon = new DB())
            {
                foreach (Status stat in dbcon.Statuses.Where(Status=> Status.Id ==a))
                {
                    statusforgame = Convert.ToString(stat.StatusForGame);
                }
            }
            
            return statusforgame;
        }//повертає значення статусу для гри по id
        public string healthstatusvalue(int a)
        {
            string healthstatus = "";
            using (var dbcon = new DB())
            {
                foreach (Status stat in dbcon.Statuses.Where(Status => Status.Id == a))
                {
                    healthstatus = Convert.ToString(stat.HealthStatus);
                }
            }

            return healthstatus;
        }//повертає значення статусу здоров'я по id
        public string comandvalue(int a)
        {
            string comand = "";
            using (var dbcon = new DB())
            {
                foreach (Company stat in dbcon.Companies.Where(Company => Company.Id == a))
                {
                    comand = Convert.ToString(stat.Name);
                }
            }
            return comand;
        }//повертає значення назви команди по id
        public List<List<string>> FindGamer(string name, string sname)
        {
            List<List<string>> full = new List<List<string>>();

            List<string> names = new List<string>();
            List<string> snames = new List<string>();
            List<string> salaries = new List<string>();
            List<string> ForGame = new List<string>();
            List<string> Health = new List<string>();
            List<string> Comand = new List<string>();

            List<int> a1 = new List<int>();
            List<int> a2 = new List<int>();

            using (var dbcon = new DB())
            {
                int i = 0;
                var comp = dbcon.Gamers.Where(Gamer => (Gamer.FirstName==name) && (Gamer.SecondName == sname));
                foreach (Gamer compl in comp)
                {
                    names.Insert(i, compl.FirstName);
                    snames.Insert(i, compl.SecondName);
                    salaries.Insert(i, Convert.ToString(compl.Salery));
                    a2.Insert(i, compl.CompanyId);
                    a1.Insert(i, compl.StatusId);
                    i++;
                }
                for (int j = 0; j < names.Count; j++)
                {
                    ForGame.Insert(j, statusforgamevalue(a1[j]));
                    Health.Insert(j, healthstatusvalue(a1[j]));
                    Comand.Insert(j, comandvalue(a2[j]));
                }
            }
                full.Add(names);
                full.Add(snames);
                full.Add(salaries);
                full.Add(ForGame);
                full.Add(Health);
                full.Add(Comand);
            
            return full;
        }
    }
}
