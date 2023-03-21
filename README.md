# BookingTickets (Платформа бронирования билетов в сети кинотеатров)

Концепт максимально простой: есть сеть кинотеатров, в кинотеатрах есть залы и расписание сеансов.
Необходимо разработать серверную часть системы бронирования билетов объединяющую онлайн заказы, покупки на кассе и формирование расписания залов.

***Основные роли и их функционал:***
Все могут логиниться.

**Клиент:**
- Может регаться
- Может видеть расписание кинотеатра
- Может видеть в каких кинотеатрах идет фильм
- Может бронировать билеты на сеанс (получает уникальный код)
- Может отменять бронь

**Кассир:**
- Может подтверждать бронь билета по коду (как будто денежки заплатили и выкупили)
- Может продавать билетики
- Администратор кинотеатра:
- Создает кассиров
- Управляет расписанием залов
- Видит кучу статистики по кинотеатру
- Хочу копировать сеанс или день целиком

**Администратор системы:**
- Создает фильмы
- Создает кинотеатры
- Создает залы различной конфигурации
- Создает администраторов кинотеатра и кассиров
- Видит всю статистику
