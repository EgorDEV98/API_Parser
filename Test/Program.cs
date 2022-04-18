using System;
using API;
using API.Service;
using API.Service.Person;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var test = Company.Bankrot(Status.Все, RegionId.Все);          //Вызов метода
            //test.data = "";                         //Параметры поиска
            //Console.WriteLine(test.GetJSON());      //Получить JSON

            var inn = Person.INN("Солоницын Егор Антонович");
            inn.type = TypeDoc.Паспорт_гражданина_РФ;
            inn.numberPassport = "3317511981";
            inn.dateOfBirthdate = "08.02.1998";
            inn.Send(); //Отправляет данные, ставит задачу, получает ответ

            string jsonString = inn.GetJson(); //Получает JSON
            string innNumber = inn.GetInnNumber(); //Получает ИНН

            Console.WriteLine(jsonString);
            Console.WriteLine(innNumber);
        }
    }
}
