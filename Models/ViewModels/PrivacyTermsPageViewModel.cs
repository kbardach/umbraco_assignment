using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Models.ViewModels
{
	public class PrivacyTermsPageViewModel : BasePageViewModel<PrivacyTerms>
	{
		public PrivacyTermsPageViewModel(PrivacyTerms content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
		{
		}
	}
}