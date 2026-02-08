using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers.Getters_HeroController
{
    //[HarmonyPatch(typeof(PlayerData), "CurrentMaxHealth", MethodType.Getter)]
    //public static class PlayerData_CurrentMaxHealth
    //{
    //    [HarmonyPostfix]
    //    public static void Postfix(PlayerData __instance, ref int __result)
    //    {
    //        float multiplier = ConfigSettings.extraMasksMultiplier.Value;
    //        if (Gameplay.CursedCrest.IsEquipped)
    //        {
    //            __result = (int)(__result * multiplier);
    //        }
    //    }
    //}
}