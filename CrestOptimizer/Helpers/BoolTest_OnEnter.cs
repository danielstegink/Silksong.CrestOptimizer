using CrestOptimizer.Settings;
using HarmonyLib;
using HutongGames.PlayMaker.Actions;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(BoolTest), "OnEnter")]
    public static class BoolTest_OnEnter
    {
        [HarmonyPrefix]
        public static void Prefix(BoolTest __instance)
        {
            // If we're binding in the air and we have No Drop enabled, override the value
            if (IsShamanDropCheck(__instance) &&
                ConfigSettings.noDropBind.Value)
            {
                __instance.boolVariable.Value = false;
            }
        }

        [HarmonyPostfix]
        public static void Postfix(BoolTest __instance)
        {
            // Make sure to reset after the fact
            if (IsShamanDropCheck(__instance))
            {
                __instance.boolVariable.Value = HeroController.instance.IsShamanCrestEquipped();
            }
        }

        /// <summary>
        /// Determines if this is the BoolTest that decides if we "drop" during the Bind
        /// </summary>
        /// <param name="__instance"></param>
        /// <returns></returns>
        private static bool IsShamanDropCheck(BoolTest __instance)
        {
            return __instance.State.Name.Equals("Bind Air") &&
                    __instance.Fsm.Name.Equals("Bind") &&
                    __instance.boolVariable.Name.Equals("Is Shaman Equipped");
        }
    }
}