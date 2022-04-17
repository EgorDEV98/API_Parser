#API Для сервисов.

Bankrot - https://bankrot.fedresurs.ru/ (17.04.2022)

#Пример использования: 
Конструкторы:

var test = Company.Bankrot();  - Необходимо задавать в ручную статус , регион и данные
test.Status = Status.Все;
test.RegionId = RegionId.Москва;
test.data = "Имя какой то компании";

var test = Company.Bankrot(Status.Все, RegionId.Москва);
test.data = "Имя какой то компании";

var test = Company.Bankrot("Имя какой то компании", Status.Все, RegionId.Москва);

var test = Company.Bankrot("Имя какой то компании");

test.GetJSON();      //Получить JSON
