using TestingGiant.Data.Models;

namespace TestingGiant.Data.Interfaces
{
    interface IKeepDatesAndCreator : IKeepDates
    {
        int CreatorId { get; set; }
    }
}
