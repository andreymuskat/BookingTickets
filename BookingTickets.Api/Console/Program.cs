using BookingTickets.BLL.Statistics;

DateTime trueDate = new DateTime(2023, 4, 20, 10, 30, 0);
DateTime dateCopy = new DateTime(2023, 4, 20);

var x = dateCopy.AddHours(trueDate.Hour).AddMinutes(trueDate.Minute);

Console.WriteLine(x);