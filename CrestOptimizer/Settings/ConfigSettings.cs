using BepInEx.Configuration;
using TeamCherry.Localization;

namespace CrestOptimizer.Settings
{
    public static class ConfigSettings
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        #region Hunter
        /// <summary>
        /// Hits required to achieve Focus at Lv 2
        /// </summary>
        public static ConfigEntry<int> focusHits;

        /// <summary>
        /// The Hunter Crest's Focus damage modifier
        /// </summary>
        public static ConfigEntry<float> focusDamage;

        /// <summary>
        /// Hits required to achieve Focus at Lv 3
        /// </summary>
        public static ConfigEntry<int> focusHits2;

        /// <summary>
        /// The Hunter Crest's Focus damage modifier at Lv 3
        /// </summary>
        public static ConfigEntry<float> focusDamage2;

        /// <summary>
        /// Hits required to achieve Focus 2 at Lv 3
        /// </summary>
        public static ConfigEntry<int> focusHits2S;

        /// <summary>
        /// The Hunter Crest's Focus 2 damage modifier at Lv 3
        /// </summary>
        public static ConfigEntry<float> focusDamage2S;
        #endregion

        #region Reaper
        /// <summary>
        /// The multiplier for the Reaper Crest's Silk fragment spawn count
        /// </summary>
        public static ConfigEntry<int> silkCountMultiplier;

        /// <summary>
        /// The multiplier for value of a Reaper Crest's silk fragment
        /// </summary>
        public static ConfigEntry<int> silkValueMultiplier;
        #endregion

        #region Wanderer
        /// <summary>
        /// The Wanderer Crest's critical chance
        /// </summary>
        public static ConfigEntry<float> critChance;

        /// <summary>
        /// The Wanderer Crest's critical modifier
        /// </summary>
        public static ConfigEntry<float> critDamage;

        /// <summary>
        /// Whether or not to replace one of Wanderer Crest's yellow slots with a red slot
        /// </summary>
        public static ConfigEntry<bool> replaceTool;
        #endregion

        #region Beast
        /// <summary>
        /// Whether or not the Beast Crest should get additional I-Frames at the start of down-slashing
        /// </summary>
        public static ConfigEntry<bool> downSlashIFrames;

        /// <summary>
        /// Maximum Masks that can be healed while in Beast Crest's fury mode
        /// </summary>
        public static ConfigEntry<int> furyCap;
        #endregion

        #region Witch
        /// <summary>
        /// How much to increase of size of the Witch Crest's tentacle bind
        /// </summary>
        public static ConfigEntry<float> bindSizeMultiplier;

        /// <summary>
        /// How much to increase of size of the Witch Crest's tentacle bind when Longclaw is equipped
        /// </summary>
        public static ConfigEntry<float> longclawBindSizeMultiplier;

        /// <summary>
        /// Maximum Masks that can be healed with Witch Crest
        /// </summary>
        public static ConfigEntry<int> witchCap;

        /// <summary>
        /// Whether or not to refund Silk on failed bind
        /// </summary>
        public static ConfigEntry<bool> refundSilk;
        #endregion

        #region Architect
        /// <summary>
        /// Chance for enemies to spawn shell shards on hit with Architect Crest
        /// </summary>
        public static ConfigEntry<int> scavengerChance;

        /// <summary>
        /// Number of Masks healed by Craft Bind
        /// </summary>
        public static ConfigEntry<int> craftMaskCount;
        #endregion

        #region Shaman
        /// <summary>
        /// Whether or not Shaman Crest bind should "drop" the player
        /// </summary>
        public static ConfigEntry<bool> noDropBind;
        #endregion
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        /// <summary>
        /// Initializes the settings
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(ConfigFile config)
        {
            #region Hunter
            LocalisedString name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_1_NAME");
            LocalisedString description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_1_DESC");
            int defaultValueInt = 6;
            if (name.Exists &&
                description.Exists)
            {
                focusHits = config.Bind("Hunter", name, defaultValueInt, description);
            }
            else
            {
                focusHits = config.Bind("Hunter", "1", defaultValueInt, "1");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_D1_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_D1_DESC");
            float defaultValueFloat = 1.3f;
            if (name.Exists &&
                description.Exists)
            {
                focusDamage = config.Bind("Hunter", name, defaultValueFloat, description);
            }
            else
            {
                focusDamage = config.Bind("Hunter", "1", defaultValueFloat, "2s");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_2_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_2_DESC");
            defaultValueInt = 6;
            if (name.Exists &&
                description.Exists)
            {
                focusHits2 = config.Bind("Hunter", name, defaultValueInt, description);
            }
            else
            {
                focusHits2 = config.Bind("Hunter", "1", defaultValueInt, "2");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_D2_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_D2_DESC");
            defaultValueFloat = 1.3f;
            if (name.Exists &&
                description.Exists)
            {
                focusDamage2 = config.Bind("Hunter", name, defaultValueFloat, description);
            }
            else
            {
                focusDamage2 = config.Bind("Hunter", "1", defaultValueFloat, "2");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_2S_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_2S_DESC");
            defaultValueInt = 6;
            if (name.Exists &&
                description.Exists)
            {
                focusHits2S = config.Bind("Hunter", name, defaultValueInt, description);
            }
            else
            {
                focusHits2S = config.Bind("Hunter", "1", defaultValueInt, "2");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_D2S_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FOCUS_D2S_DESC");
            defaultValueFloat = 1.5f;
            if (name.Exists &&
                description.Exists)
            {
                focusDamage2S = config.Bind("Hunter", name, defaultValueFloat, description);
            }
            else
            {
                focusDamage2S = config.Bind("Hunter", "1", defaultValueFloat, "2");
            }
            #endregion

            #region Reaper
            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "SILK_COUNT_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "SILK_COUNT_DESC");
            defaultValueInt = 1;
            if (name.Exists &&
                description.Exists)
            {
                silkCountMultiplier = config.Bind("Reaper", name, defaultValueInt, description);
            }
            else
            {
                silkCountMultiplier = config.Bind("Reaper", "1", defaultValueInt, "2");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "SILK_VALUE_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "SILK_VALUE_DESC");
            defaultValueInt = 1;
            if (name.Exists &&
                description.Exists)
            {
                silkValueMultiplier = config.Bind("Reaper", name, defaultValueInt, description);
            }
            else
            {
                silkValueMultiplier = config.Bind("Reaper", "1", defaultValueInt, "2");
            }
            #endregion

            #region Wanderer
            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CRIT_CHANCE_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CRIT_CHANCE_DESC");
            defaultValueFloat = 2f;
            if (name.Exists &&
                description.Exists)
            {
                critChance = config.Bind("Wanderer", name, defaultValueFloat, description);
            }
            else
            {
                critChance = config.Bind("Wanderer", "1", defaultValueFloat, "2");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CRIT_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CRIT_DESC");
            defaultValueFloat = 3f;
            if (name.Exists &&
                description.Exists)
            {
                critDamage = config.Bind("Wanderer", name, defaultValueFloat, description);
            }
            else
            {
                critDamage = config.Bind("Wanderer", "1", defaultValueFloat, "2");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "WANDERER_SLOT_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "WANDERER_SLOT_DESC");
            bool defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                replaceTool = config.Bind<bool>("Wanderer", name, defaultValueBool, description);
            }
            else
            {
                replaceTool = config.Bind("Wanderer", "1", defaultValueBool, "2");
            }
            #endregion

            #region Beast
            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "POGO_INV_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "POGO_INV_DESC");
            defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                downSlashIFrames = config.Bind("Beast", name, defaultValueBool, description);
            }
            else
            {
                downSlashIFrames = config.Bind("Beast", "Down Slash I-Frames", defaultValueBool, "Applies invulnerability at the start of down-slashing with the Beast Crest");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FURY_CAP_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "FURY_CAP_DESC");
            defaultValueInt = 3;
            if (name.Exists &&
                description.Exists)
            {
                furyCap = config.Bind("Beast", name, defaultValueInt, description);
            }
            else
            {
                furyCap = config.Bind("Beast", "Fury Heal Cap", defaultValueInt, "Maximum Masks that can be healed using Beast Crest's Fury mode");
            }
            #endregion

            #region Witch
            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BIND_SIZE_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BIND_SIZE_DESC");
            defaultValueFloat = 1f;
            if (name.Exists &&
                description.Exists)
            {
                bindSizeMultiplier = config.Bind("Witch", name, defaultValueFloat, description);
            }
            else
            {
                bindSizeMultiplier = config.Bind("Witch", "1", defaultValueFloat, "2");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "LN_BIND_SIZE_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "LN_BIND_SIZE_DESC");
            defaultValueFloat = 1f;
            if (name.Exists &&
                description.Exists)
            {
                longclawBindSizeMultiplier = config.Bind("Witch", name, defaultValueFloat, description);
            }
            else
            {
                longclawBindSizeMultiplier = config.Bind("Witch", "Witch Bind Multiplier (Longclaw)", defaultValueFloat, "How much to enlarge Witch Crest's tentacle bind with longclaw equipped");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "WITCH_CAP_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "WITCH_CAP_DESC");
            defaultValueInt = 3;
            if (name.Exists &&
                description.Exists)
            {
                witchCap = config.Bind("Witch", name, defaultValueInt, description);
            }
            else
            {
                witchCap = config.Bind("Witch", "Witch Heal Cap", defaultValueInt, "Maximum Masks that can be healed using Witch Crest");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "WITCH_REFUND_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "WITCH_REFUND_DESC");
            defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                refundSilk = config.Bind("Witch", name, defaultValueBool, description);
            }
            else
            {
                refundSilk = config.Bind("Witch", "With Silk Refund", defaultValueBool, "Refund some Silk on a failed bind");
            }
            #endregion

            #region Architect
            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "SHARD_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "SHARD_DESC");
            defaultValueInt = 0;
            if (name.Exists &&
                description.Exists)
            {
                scavengerChance = config.Bind("Architect", name, defaultValueInt, description);
            }
            else
            {
                scavengerChance = config.Bind("Architect", "1", defaultValueInt, "2");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CRAFT_MASK_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CRAFT_MASK_DESC");
            defaultValueInt = 0;
            if (name.Exists &&
                description.Exists)
            {
                craftMaskCount = config.Bind("Architect", name, defaultValueInt, description);
            }
            else
            {
                craftMaskCount = config.Bind("Architect", "1", defaultValueInt, "2");
            }
            #endregion

            #region Shaman
            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "NO_DROP_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "NO_DROP_DESC");
            defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                noDropBind = config.Bind("Shaman", name, defaultValueBool, description);
            }
            else
            {
                noDropBind = config.Bind("Shaman", "1", defaultValueBool, "2");
            }
            #endregion
        }
    }
}