using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(HeroController), "Move")]
    public static class HeroController_Move
    {
        [HarmonyPrefix]
        public static void Prefix(HeroController __instance, ref float moveDirection, ref bool useInput)
        {
            if (Gameplay.CloaklessCrest.IsEquipped)
            {
                moveDirection *= ConfigSettings.speedBonus.Value;
            }
        }
    }
}