using Microsoft.Xna.Framework.Input;

namespace Celeste.Mod.AltEnterFullscreen {
    public class AltEnterFullscreenModuleSettings : EverestModuleSettings {
        public ButtonBinding HeldKey { get; set; } = new(0, Keys.LeftAlt, Keys.RightAlt);

        public ButtonBinding PressedKey { get; set; } = new(0, Keys.Enter);
    }
}
