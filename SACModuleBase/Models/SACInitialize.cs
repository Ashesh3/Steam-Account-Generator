namespace SACModuleBase.Models
{
    public class SACInitialize
    {
        private string _ConfigurationPath;
        public string ConfigurationPath
        {
            get => _ConfigurationPath ?? string.Empty;
            set { if (string.IsNullOrEmpty(_ConfigurationPath)) _ConfigurationPath = value; }
        }

        public ISACLogger Logger { get; private set; }

        public SACInitialize(ISACLogger logger)
        {
            Logger = logger;
        }
    }
}
