# Столовые приборы
_Тестовые задания WorldSkills. Сессия 1. Репозиторий содержит в себе:_
- /ClientApp: Приложение на WPF C# (использован паттерн MVVM).
- /Database: MS SQL-скрипт базы данных (Trade).
- /Diagramms: ER-диаграмма базы данных (Trade).
## Начало работы
Для того, чтобы использовать приложение, вам нужно клонировать данный репозиторий (git clone ...), и следовать НЕОБХОДИМЫМ УСЛОВИЯМ
### Необходимые условия
Для того, чтобы приложение запустилось корректно, вам нужно:
- Иметь установленное приложение Microsoft Sql Server
- Иметь установленное приложение Microsoft Sql Management Studio
- Иметь установленное приложение Visual Studio
### Установка
- Шаг 1)Запустить сервер РСУБД
- Шаг 2) Запустить скрипт, находящийся по пути (/Database/script.sql), и выполнить его. Данный скрипт создает базу данных Trade, со всеми нужными значениями
- Шаг 3) Запустить проект на WPF. Это можно сделать двумя способами: либо через Visual Studio (/ClientApp/Tableware/Tableware.sln), либо по ярлыку в папке: (/ClientApp/Tableware.exe)
_Пример работы программы:_
- Я запустил приложение по ярлыку и ввел данные:
![alt text](https://sun9-50.userapi.com/impg/7hM3VoE-BmdUozXJsf-_DPQ3slrbzactKvO11A/kCNhvty38FQ.jpg?size=986x593&quality=96&sign=72468d7562955cf8066bf507bad24c9a&type=album)
- И вот как выглядит панель администратора: 
![alt text](https://sun9-88.userapi.com/impg/XxoaDjjLNagBPsntt3gFozYEwl4YYwg1FkE8bA/tTEo1fJMr3E.jpg?size=986x593&quality=96&sign=83fa878602e42c27cc4503832e0f71c0&type=album)
- А так производится сортировка по убыванию и возрастанию
![alt text](https://sun9-85.userapi.com/impg/ZY0sXM33ndlJvRgERSt45pjMWRtwNzHXwSMBLw/HDmO_P_T8Q8.jpg?size=986x593&quality=96&sign=cd1090ce8637629297d92ff519a25980&type=album)


## Авторы
* **Даниил Paranoic** - *Initial work* - [zmqp](https://github.com/prn-ic)
See also the list of [contributors](https://github.com/prn-ic/-1/graphs/contributors) who participated in this project.
