using CrestOptimizer.Settings;
using HarmonyLib;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(HeroController), "AddSilkParts", new System.Type[] { typeof(int) })]
    public static class HeroController_AddSilkParts
    {
        [HarmonyPrefix]
        public static void Prefix(HeroController __instance, ref int amount)
        {
            amount *= ConfigSettings.silkValueMultiplier.Value;
            //CrestOptimizer.Instance.Log($"Silk fragment value: {amount}");
        }
    }
}