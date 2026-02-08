using CrestOptimizer.Settings;
using GlobalSettings;
using HarmonyLib;
using UnityEngine;

namespace CrestOptimizer.Helpers
{
    [HarmonyPatch(typeof(HealthManager), "TakeDamage")]
    public static class HealthManager_TakeDamage
    {
        [HarmonyPrefix]
        public static void Prefix(HealthManager __instance, ref HitInstance hitInstance)
        {
            int defaultDamage = hitInstance.DamageDealt;
            if (Gameplay.CursedCrest.IsEquipped &&
                (PlayerData.instance.health + PlayerData.instance.healthBlue) <= 2)
            {
                float multiplier = ConfigSettings.fotfMultiplier.Value - 1;
                int bonusDamage = (int)(multiplier * defaultDamage);
                hitInstance.DamageDealt += bonusDamage;
            }

            if (Gameplay.CloaklessCrest.IsEquipped)
            {
                float multiplier = ConfigSettings.punchBonus.Value - 1;
                int bonusDamage = (int)(multiplier * defaultDamage);
                hitInstance.DamageDealt += bonusDamage;
            }
        }

        [HarmonyPostfix]
        public static void Postfix(HealthManager __instance, ref HitInstance hitInstance)
        {
            if (HeroController.instance.IsArchitectCrestEquipped() &&
                hitInstance.DamageDealt > 0)
            {
                int shards = 0;
                int probability = ConfigSettings.scavengerChance.Value;
                while (probability >= 100)
                {
                    shards++;
                    probability -= 100;
                }

                int random = UnityEngine.Random.Range(1, 101);
                if (random <= probability)
                {
                    shards++;
                }

                FlingUtils.Config config = new FlingUtils.Config()
                {
                    Prefab = Gameplay.ShellShardPrefab,
                    AmountMin = shards,
                    AmountMax = shards,
                    SpeedMin = 15,
                    SpeedMax = 30,
                    AngleMin = 80,
                    AngleMax = 100
                };
                FlingUtils.SpawnAndFlingShellShards(config, __instance.transform, Vector3.zero);
            }
        }
    }
}