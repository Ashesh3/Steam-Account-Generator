using System;

namespace SteamAccCreator
{
    public class ModuleLogger : SACModuleBase.ISACLogger
    {
        private SACModuleBase.ISACBase Module;
        private SACModuleBase.Attributes.SACModuleInfoAttribute ModuleAttribute;
        private string LoggerName => $"{ModuleAttribute.Name}/{ModuleAttribute.Version} | {ModuleAttribute.Guid}";

        public ModuleLogger(SACModuleBase.ISACBase module)
        {
            Module = module;
            ModuleAttribute = Module.GetInfoAttribute();
        }

        public void Debug(string message)
            => Logger.Debug(LoggerName, message);

        public void Error(string message, Exception exception)
            => Logger.Error(LoggerName, message, exception);

        public void Fatal(string message, Exception exception)
            => Logger.Fatal(LoggerName, message, exception);

        public void Info(string message)
            => Logger.Info(LoggerName, message);

        public void Trace(string message)
            => Logger.Trace(LoggerName, message);

        public void Warn(string message)
            => Logger.Warn(LoggerName, message);

        public void Warn(string message, Exception exception)
            => Logger.Warn(LoggerName, message, exception);
    }
}
