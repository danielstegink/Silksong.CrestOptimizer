using HarmonyLib;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(PlayerData), "AddHealth")]
    public static class PlayerData_AddHealth
    {
        [HarmonyPostfix]
        public static void Postfix(PlayerData __instance, int amount)
        {
            FsmState_OnExit.masksHealed = true;
        }
    }
}