using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.Category
{
    public class EditCategoryDisplayMessage : BaseMessage
    {
        public CategoryModel CategoryModel { get; set; }
    }
}
