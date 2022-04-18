using System;
using System.Collections.Specialized;

namespace API.Service.Person
{
    /// <summary>
    /// Тип документа
    /// </summary>
    public enum TypeDoc
    {
        Паспорт_гражданина_РФ = 21,
        Паспорт_гражданина_СССР = 1,
        Свидетельство_о_рождении = 3,
        Паспорт_иностранного_гражданина = 10,
        Вид_на_жительство_в_РФ = 12,
        Разрешение_на_временное_проживание_в_РФ = 15,
        Свидетельство_о_предоставлении_временного_убежища = 19,
        Свидетельство_о_рождении_иностранного_государства = 23,
        Вид_на_жительство_иностранного_гражданина = 62
    }

    public class INN
    {
        public INN() { }
        public INN(string fullName) 
        {
            string[] s_name = fullName.Split(' ');
            firstName = s_name[1];
            lastName = s_name[0];
            secondName = s_name[2];  
        }
        public INN(string firstName, string lastName, string secondName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.secondName = secondName;
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string firstName;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string lastName;

        /// <summary>
        /// Отчество
        /// </summary>
        public string secondName;

        /// <summary>
        /// Дата рождения в формате дд.мм.гггг
        /// </summary>
        public string dateOfBirthdate;

        /// <summary>
        /// Серия и номер документа слитно.
        /// </summary>
        public string numberPassport;

        /// <summary>
        /// Тип документа
        /// </summary>
        public TypeDoc type = 0;

        private const string baseUrl = "https://service.nalog.ru/inn-new-proc.do";
        private const string baseUrl2 = "https://service.nalog.ru/inn-new-proc.json";
        private string jsonStringResponse;

        /// <summary>
        /// Отправляет данные на сервер.
        /// </summary>
        public void Send()
        {
            try
            {
                jsonStringResponse = Request();
            }
            catch (Exception ex)
            {
                Console.WriteLine("При получении данных возникла ошибка:\n"+ex.Message);
            }
            
        }

        /// <summary>
        /// Получить JSON строку
        /// </summary>
        /// <returns>string {"id":"baf50c76-0c5f-4c00-bc46-12340921d34a","state":1.0,"inn":"999999999999","entityId":1.00065260058E11}</returns>
        public string GetJson() { return jsonStringResponse; }

        /// <summary>
        /// Получает INN номер
        /// </summary>
        /// <returns>string 999999999999</returns>
        public string GetInnNumber() {  return Utils.Utils.GetValueFromStringJSON(jsonStringResponse, "inn"); }

        private string Request()
        {
            var collection = new NameValueCollection();
            collection.Add("c", "find");
            collection.Add("captcha", "");
            collection.Add("captchaToken", "");
            collection.Add("fam", lastName);
            collection.Add("nam", firstName);
            collection.Add("otch", secondName);
            collection.Add("bdate", dateOfBirthdate);
            collection.Add("doctype", ((int)type).ToString());
            if (((int)type) == 21)
            {
                collection.Add("docno",
                    numberPassport.Substring(0, 2) + " " +
                    numberPassport.Substring(2, 2) + " " +
                    numberPassport.Substring(4));
            }
            else
                collection.Add("docno", numberPassport);
            collection.Add("docdt", "");
            string queryString = Utils.Utils.toQueryString(collection);

            string getTaskString = baseUrl + queryString;

            string responce = Utils.Utils.GetRequest(getTaskString);
            string requestId = Utils.Utils.GetValueFromStringJSON(responce, "requestId");

            string getInnString = baseUrl2 + $"?c=get&requestId={requestId}";
            string inn = Utils.Utils.GetRequest(getInnString);
            return inn;
        }
    }
}
