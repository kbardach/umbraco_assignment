using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Interfaces
{
    public interface IBaseContentModel
    {
        BaseContentModel CurrentPage { get; }
    }
}
