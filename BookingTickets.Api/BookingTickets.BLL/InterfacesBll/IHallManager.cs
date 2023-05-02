using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IHallManager
    {
        void CreateHall(CreateAndUpdateHallInputModel hall);

        void DeleteHall(int hallId);

        void EditHall(CreateAndUpdateHallInputModel newHall, int hallId);
    }
}