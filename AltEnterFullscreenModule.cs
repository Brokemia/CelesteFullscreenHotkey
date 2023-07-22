using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Celese = Celeste;

namespace Celeste.Mod.AltEnterFullscreen {
    public class AltEnterFullscreenModule : EverestModule {
        public static AltEnterFullscreenModule Instance { get; private set; }

        public override Type SettingsType => typeof(AltEnterFullscreenModuleSettings);
        public static AltEnterFullscreenModuleSettings Settings => (AltEnterFullscreenModuleSettings) Instance._Settings;

        private static readonly MethodInfo SetFullScreenInfo = typeof(MenuOptions).GetMethod("SetFullscreen", BindingFlags.NonPublic | BindingFlags.Static);

        public AltEnterFullscreenModule() {
            Instance = this;
        }

        public override void Load() {
            On.Celeste.Celeste.Update += Celeste_Update;
        }

        private void Celeste_Update(On.Celeste.Celeste.orig_Update orig, Celeste self, GameTime gameTime) {
            orig(self, gameTime);
            if (Settings.HeldKey.Check && Settings.PressedKey.Pressed) {
                SetFullScreenInfo.Invoke(null, new object[] { !Celese.Settings.Instance.Fullscreen });
            }
        }

        public override void Unload() {
            On.Celeste.Celeste.Update -= Celeste_Update;
        }
    }
}