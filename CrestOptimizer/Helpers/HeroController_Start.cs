using CrestOptimizer.Settings;
using HarmonyLib;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(HeroController), "Start")]
    public static class HeroController_Start
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance)
        {
            SharedData.witchBindMultiplier = 1f;
        }
    }
}
