# Прогноз погоды
Средний уровень сложности

## Проектирование сервиса
* Сервис написан на c#, фреймворк asp .net core
* Собран в Docker контейнер и развернут в Kubernetes
* Сервис представляет из webhook listner
* В качестве пользовательского интерфейса выбран [Телеграм бот](http://t.me/Naughtysoft_weather_bot)

## Работа с ботом
Боту можно отправить геолокацию или написать адрес в собщении
в случае успешного определения погоды Вы получите сообщение

```
Погода рядом с вами:
Температура: ℃
Скорость ветра: м/с
```

в случае неудачи Вы увидите другое сообщение

```
К сожалению Я не смог определить температуру рядом с Вами
```

## Пошаговая работа бота
* Бот настроен на отправку новых сообщений через webhook на адрес сервиса
* Сервис принимает сообщения
* Если в сообщении геопозиция сервис через RestApi openweathermap получает погоду по координатам
* Если в сообщении адрес, то сервис через RestApi nominatim преобразует адрес в координаты, после чего получает погоду
* Сервис в любом случае отправит сообщение пользователю независимо от результата обработки
