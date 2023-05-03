using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IStatisticsDays
    {
        List<StatisticDays_OutputModel> StatisticOfDays(StatisticDays_InputModel inputModel);
    }
}
