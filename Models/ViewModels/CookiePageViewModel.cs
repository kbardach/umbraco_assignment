﻿using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Models.ViewModels
{
    public class CookiePageViewModel : BasePageViewModel<CookieDeclaration>
    {
        public CookiePageViewModel(CookieDeclaration content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }
    }
}