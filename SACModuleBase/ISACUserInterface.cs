namespace SACModuleBase
{
    public interface ISACUserInterface : ISACBase
    {
        string ShowButtonCaption { get; }
        void ShowWindow();
    }
}
