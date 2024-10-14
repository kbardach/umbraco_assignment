using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using umbraco_assignment.Models.kim_umbraco.Models;

namespace umbraco_assignment.Models.ViewModels
{
    public class StartPageViewModel : BasePageModel<Start>
    {
        public StartPageViewModel(Start content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }
    }
}
