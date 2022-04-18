using API.Service;
using API.Service.Person;

namespace API
{
    /// <summary>
    /// Набор классов для проверки людей
    /// </summary>
    public class Person
    {
        /*=======================================================================================================================*/
        
        /// <summary>
        /// Предоставляет набор методов класса INN
        /// </summary>
        /// <returns>INN</returns>
        public static INN INN() { return new INN(); }

        /// <summary>
        /// Предоставляет набор методов класса INN
        /// </summary>
        /// <param name="fullName">ФИО полностью. Прим. Иванов Иван Иванович</param>
        /// <returns></returns>
        public static INN INN(string fullName) { return new INN(fullName); }

        /// <summary>
        /// Предоставляет набор методов класса INN
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="secondName">Отчество</param>
        /// <returns></returns>
        public static INN INN(string firstName, string lastName, string secondName) { return new INN(firstName, lastName, secondName); }

        /*=======================================================================================================================*/
    }

    /// <summary>
    /// Набор классов для проверки организаций
    /// </summary>

    public static class Company
    {
        /*=======================================================================================================================*/
        /// <summary>
        /// Предоставляет набор методов класса Bankrot
        /// </summary>
        /// <returns>Bankrot</returns>
        public static Bankrot Bankrot() { return new Bankrot(); }

        /// <summary>
        /// Предоставляет набор методов класса Bankrot
        /// </summary>
        /// <param name="data">Наименование лица, ИНН, номера дела</param>
        /// <returns>Bankrot</returns>
        public static Bankrot Bankrot(string data) { return new Bankrot(data); }

        /// <summary>
        /// Предоставляет набор методов класса Bankrot
        /// </summary>
        /// <param name="status">Статус дела</param>
        /// <param name="region">Регион дела. Обратите внимание, реальный номер региона и regionId отличаются!</param>
        /// <returns>Bankrot</returns>
        public static Bankrot Bankrot(Status status, RegionId region) { return new Bankrot(status, region); }

        /// <summary>
        /// Предоставляет набор методов класса Bankrot
        /// </summary>
        /// <param name="data">Наименование лица, ИНН, номера дела</param>
        /// <param name="status">Статус дела</param>
        /// <param name="region">Регион дела. Обратите внимание, реальный номер региона и regionId отличаются!</param>
        /// <returns>Bankrot</returns>
        public static Bankrot Bankrot(string data, Status status, RegionId region) { return new Bankrot(data, status, region); }

        /*=======================================================================================================================*/



        
    }





    /// <summary>
    /// Набор классов для проверки автомобилей
    /// </summary>

    public class Auto
    {
        
    }
}
