using App.Services;

namespace App.ViewModels
{
    class SettingsViewModel
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public SettingsViewModel()
        {
            Port = Constants.HostPort();
            Host = Constants.HostIP();
        }
    }
}
