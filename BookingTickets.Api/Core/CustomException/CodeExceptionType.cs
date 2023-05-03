namespace Core.CustomException
{
    public enum CodeExceptionType : int
    {
        DataTimeIsBusy = 100,
        NotEnoughTime = 101,
        NotFoundInDatabase = 777,
        ItsNotYourCinema = 205,
        SuchAnObjectAlreadyExists = 105,
        SeatsIsBusy = 500,
        PassedAnEmptyValueToAVariable = 300,
        VariableСannotBeNegativeOrLessThanZero = 000,
    }
}
