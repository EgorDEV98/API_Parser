using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Web;


namespace API.Service
{

    /// <summary>
    /// Регион дела. Обратите внимание, что RegionID могет не совпадать с реальными номерами регионов
    /// </summary>
    public enum RegionId
    {
        Все = 0,
        Алтайский_край = 1,
        Амурская_область = 10,
        Архангельская_область = 11,
        Астраханская_область = 12,
        Белгородская_область = 14,
        Брянская_область = 15,
        Владимирская_область = 17,
        Волгоградская_область = 18,
        Вологодская_область = 19,
        Воронежская_область = 20,
        Москва = 45,
        Санкт_Петербург = 40,
        Севастополь = 201,
        Еврейская_автономная_область = 99,
        Забайкальский_край = 101,
        Ивановская_область = 24,
        Иные_территории, _включая_г_Байконур = 203,
        Иркутская_область = 25,
        Кабардино_Балкарская_Республика = 83,
        Калининградская_область = 27,
        Калужская_область = 29,
        Камчатский_край = 30,
        Карачаево_Черкесская_Республика = 91,
        Кемеровская_область = 32,
        Кировская_область = 33,
        Костромская_область = 34,
        Краснодарский_край = 3,
        Красноярский_край = 4,
        Курганская_область = 37,
        Курская_область = 38,
        Ленинградская_область = 41,
        Липецкая_область = 42,
        Магаданская_область = 44,
        Московская_область = 46,
        Мурманская_область = 47,
        Ненецкий_автономный_округ = 200,
        Нижегородская_область = 22,
        Новгородская_область = 49,
        Новосибирская_область = 50,
        Омская_область = 52,
        Оренбургская_область = 53,
        Орловская_область = 54,
        Пензенская_область = 56,
        Пермский_край = 57,
        Приморский_край = 5,
        Псковская_область = 58,
        Республика_Адыгея = 79,
        Республика_Алтай = 84,
        Республика_Башкортостан = 80,
        Республика_Бурятия = 81,
        Республика_Дагестан = 82,
        Республика_Ингушетия = 26,
        Республика_Калмыкия = 85,
        Республика_Карелия = 86,
        Республика_Коми = 87,
        Республика_Крым = 202,
        Республика_Марий_Эл = 88,
        Республика_Мордовия = 89,
        Республика_Якутия = 98,
        Республика_Северная_Осетия = 102,
        Республика_Татарстан = 92,
        Республика_Тыва = 93,
        Республика_Хакасия = 93,
        Ростовская_область = 60,
        Рязанская_область = 61,
        Самарская_область = 36,
        Саратовская_область = 63,
        Сахалинская_область = 64,
        Свердловская_область = 65,
        Смоленская_область = 66,
        Ставропольский_край = 7,
        Тамбовская_область = 68,
        Тверская_область = 28,
        Томская_область = 69,
        Тульская_область = 70,
        Тюменская_область = 71,
        Удмуртская_Республика = 94,
        Ульяновская_область = 73,
        Хабаровский_край = 8,
        Ханты_Мансийский_автономный_округ = 103,
        Челябинская_область = 75,
        Чеченская_Республика = 96,
        Чувашская_Республика = 97,
        Чукотский_автономный_округ = 77,
        Ямало_Ненецкий_автономный_округ = 104,
        Ярославская_область = 78
    }
    
    /// <summary>
    /// Статус дела
    /// </summary>
    public enum Status
    {
        Все = 0,
        В_работе = 1,
        Завершено = 2
    }
    


    public class Bankrot
    {
        private WebClient wk;
        private const string baseUrl = "https://bankrot.fedresurs.ru/backend/cmpbankrupts";

        public Status status = 0;
        public RegionId regionId = 0;

        public string data { get; set; }


        public Bankrot() { }
        public Bankrot(string data)
        {
            this.data = data;
        }
        public Bankrot(Status status, RegionId regionId)
        {
            this.status = status;
            this.regionId = regionId;
        }
        public Bankrot(string data, Status status, RegionId regionId) : this(data)
        {
            this.status = status;
            this.regionId = regionId;
        }


        public string GetJSON()
        {
            var collection = new NameValueCollection();
            if (!string.IsNullOrEmpty(data)) collection.Add("searchString", data);
            collection.Add("isActiveLegalCase", Utils.Utils.enumStatusToString(status));
            if (regionId != 0) collection.Add("regionId", Utils.Utils.enumRegionToString(regionId));
            collection.Add("limit", "15");
            collection.Add("offset", "0");

            string queryString = Utils.Utils.toQueryString(collection);

            wk = new WebClient();
            wk.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36");
            wk.Headers.Add(HttpRequestHeader.Referer, baseUrl + queryString);
            wk.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");

            var responseStream = new GZipStream(wk.OpenRead(baseUrl + queryString), CompressionMode.Decompress);
            var reader = new StreamReader(responseStream);
            var textResponse = reader.ReadToEnd();

            return textResponse;
        }       
    }
}
