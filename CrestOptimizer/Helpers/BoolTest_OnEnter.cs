using CrestOptimizer.Settings;
using HarmonyLib;
using HutongGames.PlayMaker.Actions;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(BoolTest), "OnEnter")]
    public static class BoolTest_OnEnter
    {
        /// <summary>
        /// Stores if the up key was pressed
        /// </summary>
        private static bool upKeyPressed = false;

        [HarmonyPrefix]
        public static void Prefix(BoolTest __instance)
        {
            // If we're binding in the air and we have No Drop enabled, override the value
            if (IsShamanDropCheck(__instance) &&
                ConfigSettings.noDropBind.Value)
            {
                __instance.boolVariable.Value = false;
            }

            // If Craft Bind Default is enabled, invert the up-key check
            if (IsCraftBindCheck(__instance))
            {
                upKeyPressed = __instance.boolVariable.Value;
                if (ConfigSettings.craftBindDefault.Value)
                {
                    __instance.boolVariable.Value = !__instance.boolVariable.Value;
                }
            }
        }

        /// <summary>
        /// When modifying values in an FSM, always reset after the fact
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPostfix]
        public static void Postfix(BoolTest __instance)
        {
            if (IsShamanDropCheck(__instance))
            {
                __instance.boolVariable.Value = HeroController.instance.IsShamanCrestEquipped();
            }

            if (IsCraftBindCheck(__instance))
            {
                __instance.boolVariable.Value = upKeyPressed;
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

        /// <summary>
        /// Determines if this is the BoolTest that checks if the up key is pressed
        /// </summary>
        /// <param name="__instance"></param>
        /// <returns></returns>
        private static bool IsCraftBindCheck(BoolTest __instance)
        {
            return __instance.State.Name.Equals("Quick Craft?") &&
                    __instance.Fsm.Name.Equals("Bind");
        }
    }
}