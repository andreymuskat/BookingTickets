using BookingTickets.BLL.Statistics;
using BookingTickets.DAL;
using BookingTickets.DAL.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

Statistics_Film stat = new Statistics_Film();

DateOnly start = new DateOnly(2023, 01, 01);
DateOnly end = new DateOnly(2024, 01, 01);

var year = 2023;
var month = 4;

var date = new DateTime(year, month, 1);
var allDaysInTheMonth = new List<OrderDto>();

for (int i = 1;  date.Month != month+1; date = date.AddDays(i))
{
    var order = new OrderDto() { Date = date };
    allDaysInTheMonth.Add(order);
}

int a = stat.NotPurchasedTicketsOnFilmInCinema(5, 1, start, end);
int b = stat.PurchasedTicketsOnFilmInCinema(5, 1, start, end);
int c = stat.AmountTicketsOnFilmInCinema(5, 1, start, end);


Console.WriteLine("");