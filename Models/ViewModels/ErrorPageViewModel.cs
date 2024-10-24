using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Models.ViewModels
{
	public class ErrorPageViewModel : BasePageViewModel<Error>
	{
		public ErrorPageViewModel(Error content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
		{
		}
	}
}