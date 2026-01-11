using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;
using HutongGames.PlayMaker;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(FsmState), "OnExit")]
    public static class FsmState_OnExit
    {
        /// <summary>
        /// Tracks health before binding
        /// </summary>
        private static int prevHealth = 0;

        [HarmonyPostfix]
        public static void Postfix(FsmState __instance)
        {
            if (__instance.Name.Equals("SpinBall Antic") &&
                __instance.Fsm.Name.Equals("Crest Attacks"))
            {
                if (ConfigSettings.downSlashIFrames.Value)
                {
                    HeroController.instance.StartDownspikeInvulnerabilityLong();
                }
            }

            // When we start a bind, make a note of current health
            if (__instance.Name.Equals("Bind Start") &&
                __instance.Fsm.Name.Equals("Bind"))
            {
                prevHealth = PlayerData.instance.GetInt("health");
            }

            // When we finish a bind, check if we regained any health
            if (__instance.Name.Equals("End Bind") &&
                __instance.Fsm.Name.Equals("Bind"))
            {
                // If not, refund Silk if Witch Crest equipped and setting enabled
                int currentHealth = PlayerData.instance.GetInt("health");
                if (currentHealth <= prevHealth &&
                    ConfigSettings.refundSilk.Value &&
                    Gameplay.WitchCrest.IsEquipped)
                {
                    HeroController.instance.AddSilk(5, true);
                }
            }

            // If we successfully complete Craft Bind and the setting is enabled, heal
            if (__instance.Name.Equals("Quick Craft Burst") &&
                __instance.Fsm.Name.Equals("Bind") &&
                ConfigSettings.craftMaskCount.Value > 0)
            {
                HeroController.instance.AddHealth(ConfigSettings.craftMaskCount.Value);
            }
        }
    }
}