using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Action
{
    public class StadionControl
    {
        public void AddStadion(string name, int numberofplaces, double priceforplace)
        {
            //LibraryForObjects.Stadion stadion = new LibraryForObjects.Stadion(name,numberofplaces,priceforplace);
            using (var dbcon = new DB())
            {
                var gam = new List<DataAccess.Stadion>()
                {
                    new DataAccess.Stadion(){ Name=name, NumberOfPlaces=numberofplaces, PriceForPlace = priceforplace}
                };
                dbcon.Stadions.AddRange(gam);//зберігаємо за допомогою entity проміжково дані
                dbcon.SaveChanges();//синхронізуємо з бд
            }
        }//Додавання стадіону
        public void DeleteStadion(string name)
        {
            using (var dbcon = new DB())
            {
                var remov = dbcon.Stadions.SingleOrDefault(Stadion => Stadion.Name == name);
                if (remov != null)
                {
                    dbcon.Stadions.Remove(remov);
                    dbcon.SaveChanges();
                }
            }
        }//видалення стадіону
        public string ModifyStadion(string name, string newname, int numberofplaces, double priceforplace)
        {
            string result;
            using (var dbcon = new DB())
            {
                var modify = dbcon.Stadions.Where(Stadion => Stadion.Name == name)
                                         .FirstOrDefault();
                if (modify != null)
                {
                    modify.Name = newname;
                    modify.NumberOfPlaces = numberofplaces;
                    modify.PriceForPlace = priceforplace;
                    result = "Data modify!";
                }
                else
                    result = "There are no data with that name.";
                return result;
            }
        }//Змінюємо дані
        public List<string> StadionNameReturning()//повертаємо stadions name
        {
            List<string> gi = new List<string>();
            using (var dbcon = new DB())
            {
                foreach (DataAccess.Stadion stadion in dbcon.Stadions)
                {
                    gi.Add(stadion.Name);
                }
            }
            return gi;
        }
        public List<string> ReturnValues(string a)
        {
            List<string> stadion = new List<string>();
            using (var dbcon = new DB())
            {
                var comp = dbcon.Stadions
                           .Where(Stadion => Stadion.Name == a);
                foreach (DataAccess.Stadion compId1 in comp)
                {
                    stadion.Insert(0, compId1.Name);
                    stadion.Insert(1, Convert.ToString(compId1.NumberOfPlaces));
                    stadion.Insert(2, Convert.ToString(compId1.PriceForPlace));
                }
            }
            return stadion;
        }//повернення значень по назві стадіону
        public List<string> ShowStadion()//повертаємо значення для виведення даних
        {
            List<string> full = new List<string>();
            using (var dbcon = new DB())
            {
                int i = 0;
                var comp = dbcon.Stadions;
                foreach (DataAccess.Stadion compl in comp)
                {
                    full.Insert(i, (i + 1) + ". " + compl.Name + "; Кількість місць:" + compl.NumberOfPlaces + "; " + "Ціна: " + Convert.ToString(compl.PriceForPlace) + " грн.;" + " ");
                    i++;
                }
            }
            return full;
        }
        public List<string> ShowStadionByName(string name)//повертаємо значення для виведення даних
        {
            List<string> full = new List<string>();
            
            using (var dbcon = new DB())
            {
                int i = 0;
                var comp = dbcon.Stadions.Where(Stadion=>Stadion.Name == name);
                foreach (DataAccess.Stadion compl in comp)
                {
                    full.Insert(i, (i + 1) + ". " + compl.Name + "; Кількість місць:" + compl.NumberOfPlaces + "; " + "Ціна: " + Convert.ToString(compl.PriceForPlace) + " грн.;" + " ");
                    i++;
                }
            }
            return full;
        }
        static void Main(string[] args)
        {
            //List<string> str = new List<string>();
            //StadionControl control = new StadionControl();
            //str = control.StadionReturning();
            //foreach(string i in str)
            //{
            //    Console.WriteLine(i);
            //}
            ////control.addthings();
            ////control.AddGamer("Юра", "Макко", true, true, 3000, "Zara");
            //////control.DeleteGamer("Юрій","Юхименко");
            //////Console.WriteLine(control.ModifyGamer("Олег", "Юхименко", "Денис", "Юхименко", true, false, 90000, "Dinamo"));
            //Console.WriteLine("Its OK!!!");
        }
    }
}
