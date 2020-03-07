namespace Assets.Source.Modes.Shared
{
    public interface IOverlayMode
    {
        bool Is(string modeName);

        void Enable();

        void Disable();
    }
}