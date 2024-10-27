using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Notifications;
using umbraco_assignment.Business.Notifications;

namespace umbraco_assignment.Business.Composers
{
    public class ContentSavingComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<ContentSavingNotification, SetDefaultMetaRobotsDropdownHandler>();
        }
    }

}
