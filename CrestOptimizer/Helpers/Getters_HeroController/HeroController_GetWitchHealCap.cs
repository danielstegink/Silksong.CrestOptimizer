using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_HeroController
{
    [HarmonyPatch(typeof(HeroController), "GetWitchHealCap")]
    public static class HeroController_GetWitchHealCap
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance, ref int __result)
        {
            int newCap = ConfigSettings.witchCap.Value;
            if (Gameplay.MultibindTool.IsEquipped)
            {
                newCap++;
            }
            __result = newCap;
        }
    }
}