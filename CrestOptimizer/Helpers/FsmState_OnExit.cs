using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;
using HutongGames.PlayMaker;
using System.Collections;
using UnityEngine;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(FsmState), "OnExit")]
    public static class FsmState_OnExit
    {
        /// <summary>
        /// Tracks if bind has healed
        /// </summary>
        internal static bool masksHealed = false;

        /// <summary>
        /// Stores Claw Mirror burst for future use
        /// </summary>
        private static GameObject? mirrorBurst;

        [HarmonyPostfix]
        public static void Postfix(FsmState __instance)
        {
            //if (__instance.Fsm.Name.Equals("Bind"))
            //{
            //    CrestOptimizer.Instance.Log($"Exiting {__instance.Name} ({__instance.Fsm.Name})");
            //}

            if (__instance.Name.Equals("SpinBall Antic") &&
                __instance.Fsm.Name.Equals("Crest Attacks"))
            {
                if (ConfigSettings.downSlashIFrames.Value)
                {
                    HeroController.instance.StartDownspikeInvulnerabilityLong();
                }
            }

            // When we start a bind, make a note of current health
            if (__instance.Name.Equals("Bind Start") &&
                __instance.Fsm.Name.Equals("Bind"))
            {
                masksHealed = false;
            }

            // When we finish a bind, check if we regained any health
            if (__instance.Name.Equals("End Bind") &&
                __instance.Fsm.Name.Equals("Bind"))
            {
                // If not, refund Silk if Witch Crest equipped and setting enabled
                if (!masksHealed &&
                    ConfigSettings.refundSilk.Value &&
                    Gameplay.WitchCrest.IsEquipped)
                {
                    HeroController.instance.AddSilk(5, true);
                }
            }

            // If we successfully complete Craft Bind and the setting is enabled, heal
            if (__instance.Name.Equals("Quick Craft Burst") &&
                __instance.Fsm.Name.Equals("Bind") &&
                ConfigSettings.craftMaskCount.Value > 0)
            {
                HeroController.instance.AddHealth(ConfigSettings.craftMaskCount.Value);
            }

            // After the first dazzle, if Witch Crest, Multibinder and Claw Mirror are all equipped,
            // trigger a second, delayed blast
            if (__instance.Name.Equals("Dazzle?") &&
                __instance.Fsm.Name.Equals("Bind") &&
                Gameplay.WitchCrest.IsEquipped &&
                Gameplay.MultibindTool.IsEquipped &&
                __instance.Fsm.Variables.GetFsmBool("Is Dazzle Equipped").Value &&
                ConfigSettings.doubleMirror.Value)
            {
                mirrorBurst = __instance.Fsm.Variables.GetFsmGameObject("Dazzle Flash").Value;
                GameManager.instance.StartCoroutine(SpawnFlash());
            }
        }

        /// <summary>
        /// Triggers the Claw Mirror burst on the player's location after a short delay
        /// </summary>
        /// <returns></returns>
        private static IEnumerator SpawnFlash()
        {
            yield return new WaitForSeconds(0.5f);

            if (HeroController.instance != null &&
                HeroController.instance.gameObject != null &&
                mirrorBurst != null)
            {
                mirrorBurst.Spawn(HeroController.instance.transform.position);
            }
        }
    }
}