using Umbraco.Cms.Core.Models.PublishedContent;

namespace umbraco_assignment.Business.Services.Interfaces
{
    public interface ISitemapService
    {
        List<IPublishedContent> Pages();
    }
}
