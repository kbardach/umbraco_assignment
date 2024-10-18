using Umbraco.Cms.Core.Models.PublishedContent;

namespace umbraco_assignment.Interfaces
{
    public interface IPageModel : IPublishedContent
    {
        IPublishedContent Content { get; }
    }
}
