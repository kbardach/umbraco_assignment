using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Models.ViewModels
{
	public class ContactUsPageViewModel : BasePageViewModel<ContactUs>
	{
		public ContactUsPageViewModel(ContactUs content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
		{
		}
	}
}
