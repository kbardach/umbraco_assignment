using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Interfaces
{
    public interface IBasePageModel
    {
        Start StartPage { get; }

        Settings SettingsPage { get; }
    }
}
