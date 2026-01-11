using CrestOptimizer.Settings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_HeroController
{
    [HarmonyPatch(typeof(HeroController), "GetReaperPayout")]
    public static class HeroController_GetReaperPayout
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance, ref int __result)
        {
            __result *= ConfigSettings.silkCountMultiplier.Value;
            //CrestOptimizer.Instance.Log($"Silk fragment count: {__result}");
        }
    }
}