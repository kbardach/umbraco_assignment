using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace umbraco_assignment.Models.PublishedModels
{
    public class BaseContentModel : PublishedContentModel
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public BaseContentModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
            _umbracoContextAccessor = StaticServiceProvider.Instance.GetService<IUmbracoContextAccessor>();
        }

        public Start StartPage
        {
            get
            {
                if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
                {
                    var content = umbracoContext.Content;

                    return content.GetAtRoot().DescendantsOrSelf<Start>().FirstOrDefault();
                }

                return null;
            }
        }

        public Settings SettingsPage
        {
            get
            {
                if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
                {
                    var content = umbracoContext.Content;

                    return content.GetAtRoot().DescendantsOrSelf<Settings>().FirstOrDefault();
                }

                return null;
            }
        }
        public Search SearchPage
        {
            get
            {
                if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
                {
                    var content = umbracoContext.Content;

                    return content.GetAtRoot().DescendantsOrSelf<Search>().FirstOrDefault();
                }

                return null;
            }
        }

    }
}
