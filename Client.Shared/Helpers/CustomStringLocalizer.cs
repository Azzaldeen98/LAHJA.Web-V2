using Shared.Interfaces;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Client.Shared.Helpers
{
    public interface ICustomStringLocalizer:ITScope
    {
        public string GetLocalizedString(string key);
    }

    public class CustomStringLocalizer
    {
        private readonly ResourceManager _resourceManager;

        public CustomStringLocalizer(string resourceFilePath)
        {
            _resourceManager = new ResourceManager(resourceFilePath, Assembly.GetExecutingAssembly());
        }

        public string GetLocalizedString(string key)
        {
            return _resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
    }
}
