using BepInEx;
using RoR2;

namespace ChatQuickView
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    public class ChatQuickView : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Rorroh";
        public const string PluginName = "ChatQuickView";
        public const string PluginVersion = "1.0.0";

        private static LocalUser localUser;

        public void Awake()
        {
            On.RoR2.Run.Start += (orig, self) =>
            {
                localUser = LocalUserManager.GetFirstLocalUser();
                orig(self);
            };

            On.RoR2.UI.ChatBox.UpdateFade += (orig, self, dt) =>
            {
                if (localUser.inputPlayer.GetButton("info"))
                    self.ResetFadeTimer();
                orig(self, dt);
            };
        }
    }
}