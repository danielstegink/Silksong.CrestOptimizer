using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(HeroController), "DidAttack")]
    public static class HeroController_DidAttack
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance)
        {
            if (Gameplay.CloaklessCrest.IsEquipped)
            {
                __instance.attack_cooldown /= ConfigSettings.punchSpeedBonus.Value;
            }
        }
    }
}