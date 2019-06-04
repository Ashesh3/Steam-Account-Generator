using System;
using System.Diagnostics;

namespace SACModuleBase.Attributes
{
    [DebuggerDisplay("{Name} / {Version} | {Guid}")]
    public class SACModuleInfoAttribute : Attribute
    {
        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public Version Version { get; private set; }

        public SACModuleInfoAttribute(string guid, string name, string version) : this(Guid.Parse(guid), name, Version.Parse(version)) { }
        public SACModuleInfoAttribute(Guid guid, string name, string version) : this(guid, name, Version.Parse(version)) { }
        public SACModuleInfoAttribute(string guid, string name, Version version) : this(Guid.Parse(guid), name, version) { }
        public SACModuleInfoAttribute(Guid guid, string name, Version version)
        {
            Guid = guid;
            Name = name ?? throw new ArgumentNullException();
            Version = version ?? throw new ArgumentNullException();
        }
    }
}
