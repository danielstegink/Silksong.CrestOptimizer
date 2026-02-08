using GlobalSettings;
using HarmonyLib;
using UnityEngine;
using CrestOptimizer.Settings;
using DanielSteginkUtils.Utilities;
using System.Diagnostics;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(HeroController), "Update")]
    public static class HeroController_Update
    {
        /// <summary>
        /// Timer for tracking passive healing with Cloakless Crest
        /// </summary>
        internal static Stopwatch cloaklessHealTimer = new Stopwatch();

        [HarmonyPostfix]
        public static void Postfix(HeroController __instance)
        {
            ToolCrest wandererCrest = ToolItemManager.GetCrestByName("Wanderer");
            if (wandererCrest != null)
            {
                ToolItemType newType = ConfigSettings.replaceTool.Value ? ToolItemType.Red : ToolItemType.Yellow;
                if (newType != wandererCrest.Slots[4].Type)
                {
                    wandererCrest.Slots[4].Type = newType;
                    __instance.UpdateConfig();
                }
            }

            BuffTentacles();

            if (Gameplay.WarriorCrest.IsEquipped &&
                __instance.crestAttacksFSM.FsmVariables.GetFsmBool("In Crest Attack").Value)
            {
                Rigidbody2D rb2d = __instance.rb2d;
                float x = rb2d.linearVelocity.x;
                float y = rb2d.linearVelocity.y;

                if (ConfigSettings.beastDash.Value)
                {
                    y = 0;
                }

                if (ConfigSettings.beastPogo.Value)
                {
                    x = 0;
                }

                rb2d.SetVelocity(x, y);
                ClassIntegrations.SetField(__instance, "rb2d", rb2d);
                //CrestOptimizer.Instance.Log($"Velocity: {__instance.rb2d.linearVelocity}");
            }

            if (GameManager.instance.isPaused)
            {
                cloaklessHealTimer.Stop();
            }
            else
            {
                if (Gameplay.CloaklessCrest.IsEquipped &&
                    ConfigSettings.healTime.Value > 0)
                {
                    cloaklessHealTimer.Start();
                    if (cloaklessHealTimer.ElapsedMilliseconds >= ConfigSettings.healTime.Value * 1000)
                    {
                        __instance.AddHealth(1);
                        cloaklessHealTimer.Restart();
                    }
                }
                else
                {
                    cloaklessHealTimer.Stop();
                }
            }
        }

        /// <summary>
        /// Applies the size modifier to the Witch Bind tentacles
        /// </summary>
        private static void BuffTentacles()
        {
            float modifier = ConfigSettings.bindSizeMultiplier.Value;
            if (Gameplay.LongNeedleTool.IsEquipped)
            {
                modifier = ConfigSettings.longclawBindSizeMultiplier.Value;
            }
            if (SharedData.witchBindMultiplier == modifier)
            {
                return;
            }

            GameObject bindEffects = UnityEngine.GameObject.Find("Bind Effects");
            if (bindEffects == null)
            {
                //WitchBindExtended.Instance.Log("Error getting bind effects");
                return;
            }

            GameObject witchBind = UnityEngine.GameObject.Find("Witch Bind");
            if (witchBind == null)
            {
                //WitchBindExtended.Instance.Log("Error getting witch bind");
                return;
            }

            Transform[] witchObjects = witchBind.GetComponentsInChildren<Transform>();
            foreach (Transform t in witchObjects)
            {
                GameObject gameObject = t.gameObject;
                if (gameObject.name.Contains("Damager") ||
                    gameObject.name.Contains("Tendril"))
                {
                    //WitchBindExtended.Instance.Log($"Tendril/Damager found: {gameObject.name}");
                    GameObject parent = gameObject.transform.parent.gameObject;
                    if (parent != null &&
                        parent.name.Equals("Witch Bind"))
                    {
                        // First, reset the tentacles to normal size
                        Vector3 oldScale = gameObject.transform.localScale;
                        gameObject.transform.localScale /= SharedData.witchBindMultiplier;

                        // Then, apply the new multiplier
                        gameObject.transform.localScale *= modifier;
                        //WitchBindExtended.Instance.Log($"{gameObject.name} : {oldScale} -> {gameObject.transform.localScale}");
                    }
                }
            }

            SharedData.witchBindMultiplier = modifier;
        }
    }
}