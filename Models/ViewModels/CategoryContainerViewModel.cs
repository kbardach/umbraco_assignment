using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;
using System.Collections.Generic;

namespace umbraco_assignment.Models.ViewModels
{
    public class CategoryContainerViewModel : BasePageViewModel<CategoryContainer>
    {
        public CategoryContainerViewModel(CategoryContainer content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }

        public IEnumerable<Category> Categories { get; set; }
    }
}
