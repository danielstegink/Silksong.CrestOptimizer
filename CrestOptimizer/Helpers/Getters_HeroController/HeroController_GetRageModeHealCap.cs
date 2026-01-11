using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_HeroController
{
    [HarmonyPatch(typeof(HeroController), "GetRageModeHealCap")]
    public static class HeroController_GetRageModeHealCap
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance, ref int __result)
        {
            int newCap = ConfigSettings.furyCap.Value;
            if (Gameplay.MultibindTool.IsEquipped)
            {
                newCap++;
            }
            __result = newCap;
        }
    }
}