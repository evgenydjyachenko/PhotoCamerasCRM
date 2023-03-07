PhotoCamerasCRM
=============================
CRM приложение на платформе WinForms с применением Entity Framework 6 и ADO.NET.

Краткое описание
------------
> Приложение для регистрации и учета закупок и продаж фототехники. Есть 3 роли: Директор, Менеджер и Работник.
> Все имеют разный доступ к приложению. Директор занимается мониторингом статистики продаж и закупок в компании, принятию и увольнению
> новых сотрудников, а так же их распределением к менеджерам. Менеджер в свою очередь занимается мониторингом заказов, работает в Базе данных
> с продукцией, магазинами, поставщиками и запчастями. Работник - это своего рода оператор базы даннх. В его задачи входит регистрация заказов и их закрытие. 
> 

Установка
------------
После скачивания проекта откройте Visual Studio и зайдите в пакетный менеджер Nuget и подключите следующие паеты:


<image
  src="/Pictures/nuget.jpg"
  alt="Текст с описанием картинки"
  caption="Подпись под картинкой">

 Далее откройте конфигурационный файл App.config и добавьте элемент connectionStrings с следующими атрибутами: 
  
  <image
  src="/Pictures/AppConfig.png"
  alt="Текст с описанием картинки"
  caption="Сервер SQLEXPRESS у Вас может отличаться. Проверить это можно в MS SQL Server Management Studio">
  **!Обратите внимание, что название сервера (в примере выше - SQLEXPRESS) у Вас может отличаться. Проверить это можно в MS SQL Server Management Studio.
    
  Для создания базы данных напишите нижеперечисленные команды в консоле диспетчера пакетов:
   
      enable-migrations                       активация миграции           
      add-migration 'InitialCreate'           добавление миграции с коммитом
      update-database                         обновить изменения в базе данных


