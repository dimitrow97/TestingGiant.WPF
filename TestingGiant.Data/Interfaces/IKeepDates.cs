using System;

namespace TestingGiant.Data.Interfaces
{
    public interface IKeepDates
    {
        DateTime? CreatedOn { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }

        DateTime? LastEditedOn { get; set; }
    }
}
