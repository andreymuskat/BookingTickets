# BookingTickets (Платформа бронирования билетов в сети кинотеатров)

Концепт максимально простой: есть сеть кинотеатров, в кинотеатрах есть залы и расписание сеансов.
Необходимо разработать серверную часть системы бронирования билетов объединяющую онлайн заказы, покупки на кассе и формирование расписания залов.

***Основные роли и их функционал:***
Все могут логиниться.

**Клиент:**
- [x] Может регаться
- [x] Может видеть расписание кинотеатра
- [x] Может видеть в каких кинотеатрах идет фильм
- [x] Может бронировать билеты на сеанс (получает уникальный код)
- [x] Может отменять бронь

**Кассир:**
- [x] Может подтверждать бронь билета по коду (как будто денежки заплатили и выкупили)
- [x] Может продавать билетики

**Администратор кинотеатра:**
- [x] Создает кассиров
- [x] Управляет расписанием залов
- [x] Видит кучу статистики по кинотеатру
- [x] Хочу копировать сеанс или день целиком

**Администратор системы:**
- [x] Создает фильмы
- [x] Создает кинотеатры
- [x] Создает залы различной конфигурации
- [x] Создает администраторов кинотеатра и кассиров
- [x] Видит всю статистику
