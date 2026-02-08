using BepInEx.Configuration;
using TeamCherry.Localization;
using UnityEngine;

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

        /// <summary>
        /// Removes drop from down slash
        /// </summary>
        public static ConfigEntry<bool> beastDash;

        /// <summary>
        /// Removes dash from down slash
        /// </summary>
        public static ConfigEntry<bool> beastPogo;

        /// <summary>
        /// Adjusts the size of the up slash
        /// </summary>
        public static ConfigEntry<Vector3> biggerUpSlash;

        ///// <summary>
        ///// Replaces down slash
        ///// </summary>
        //public static ConfigEntry<bool> newDownSlash;
        #endregion

        #region Cursed
        ///// <summary>
        ///// Enables custom Suicide Bind
        ///// </summary>
        //public static ConfigEntry<bool> cursedBind;

        ///// <summary>
        ///// Multiplier for getting max masks
        ///// </summary>
        //public static ConfigEntry<float> extraMasksMultiplier;

        /// <summary>
        /// Damage multiplier when at low health
        /// </summary>
        public static ConfigEntry<float> fotfMultiplier;
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

        /// <summary>
        /// If Multibinder is equipped, Claw Mirror(s) will trigger twice
        /// </summary>
        public static ConfigEntry<bool> doubleMirror;
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

        /// <summary>
        /// Craft Bind is the default bind
        /// </summary>
        public static ConfigEntry<bool> craftBindDefault;
        #endregion

        #region Shaman
        /// <summary>
        /// Whether or not Shaman Crest bind should "drop" the player
        /// </summary>
        public static ConfigEntry<bool> noDropBind;

        /// <summary>
        /// Turns Needle attacks into spell attacks
        /// </summary>
        public static ConfigEntry<bool> spellNail;
        #endregion

        #region Cloakless
        /// <summary>
        /// Damage multiplier for unarmed attacks
        /// </summary>
        public static ConfigEntry<float> punchBonus;

        /// <summary>
        /// Attack speed bonus
        /// </summary>
        public static ConfigEntry<float> punchSpeedBonus;

        /// <summary>
        /// Movement speed bonus
        /// </summary>
        public static ConfigEntry<float> speedBonus;

        /// <summary>
        /// Time (in seconds) to wait before healing 1 Mask
        /// </summary>
        public static ConfigEntry<float> healTime;
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
                focusHits = config.Bind("Hunter", "FOCUS_1_NAME", defaultValueInt, "FOCUS_1_DESC");
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
                focusDamage = config.Bind("Hunter", "FOCUS_D1_NAME", defaultValueFloat, "FOCUS_D1_DESC");
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
                focusHits2 = config.Bind("Hunter", "FOCUS_2_NAME", defaultValueInt, "FOCUS_2_DESC");
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
                focusDamage2 = config.Bind("Hunter", "FOCUS_D2_NAME", defaultValueFloat, "FOCUS_D2_DESC");
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
                focusHits2S = config.Bind("Hunter", "FOCUS_2S_NAME", defaultValueInt, "FOCUS_2S_DESC");
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
                focusDamage2S = config.Bind("Hunter", "FOCUS_D2S_NAME", defaultValueFloat, "FOCUS_D2S_DESC");
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
                silkCountMultiplier = config.Bind("Reaper", "SILK_COUNT_NAME", defaultValueInt, "SILK_COUNT_DESC");
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
                silkValueMultiplier = config.Bind("Reaper", "SILK_VALUE_NAME", defaultValueInt, "SILK_VALUE_DESC");
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
                critChance = config.Bind("Wanderer", "CRIT_CHANCE_NAME", defaultValueFloat, "CRIT_CHANCE_DESC");
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
                critDamage = config.Bind("Wanderer", "CRIT_NAME", defaultValueFloat, "CRIT_DESC");
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
                replaceTool = config.Bind("Wanderer", "WANDERER_SLOT_NAME", defaultValueBool, "WANDERER_SLOT_DESC");
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
                downSlashIFrames = config.Bind("Beast", "POGO_INV_NAME", defaultValueBool, "POGO_INV_DESC");
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
                furyCap = config.Bind("Beast", "FURY_CAP_NAME", defaultValueInt, "FURY_CAP_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BEAST_DASH_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BEAST_DASH_DESC");
            defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                beastDash = config.Bind("Beast", name, defaultValueBool, description);
            }
            else
            {
                beastDash = config.Bind("Beast", "BEAST_DASH_NAME", defaultValueBool, "BEAST_DASH_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BEAST_POGO_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BEAST_POGO_DESC");
            defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                beastPogo = config.Bind("Beast", name, defaultValueBool, description);
            }
            else
            {
                beastPogo = config.Bind("Beast", "BEAST_POGO_NAME", defaultValueBool, "BEAST_POGO_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BEAST_UP_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BEAST_UP_DESC");
            Vector3 defaultValueVector3 = Vector3.one;
            if (name.Exists &&
                description.Exists)
            {
                biggerUpSlash = config.Bind("Beast", name, defaultValueVector3, description);
            }
            else
            {
                biggerUpSlash = config.Bind("Beast", "BEAST_UP_NAME", defaultValueVector3, "BEAST_UP_DESC");
            }

            //name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BEAST_DOWN_NAME");
            //description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "BEAST_DOWN_DESC");
            //defaultValueBool = false;
            //if (name.Exists &&
            //    description.Exists)
            //{
            //    newDownSlash = config.Bind("Beast", name, defaultValueBool, description);
            //}
            //else
            //{
            //    newDownSlash = config.Bind("Beast", "New Down Slash", defaultValueBool, "Replaces down slash");
            //}
            #endregion

            #region Cursed
            //name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CURSED_MASKS_NAME");
            //description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CURSED_MASKS_DESC");
            //defaultValueFloat = 1f;
            //if (name.Exists &&
            //    description.Exists)
            //{
            //    extraMasksMultiplier = config.Bind("Cursed", name, defaultValueFloat, description);
            //}
            //else
            //{
            //    extraMasksMultiplier = config.Bind("Cursed", "CURSED_MASKS_NAME", defaultValueFloat, "CURSED_MASKS_DESC");
            //}

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CURSED_FURY_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CURSED_FURY_DESC");
            defaultValueFloat = 1f;
            if (name.Exists &&
                description.Exists)
            {
                fotfMultiplier = config.Bind("Cursed", name, defaultValueFloat, description);
            }
            else
            {
                fotfMultiplier = config.Bind("Cursed", "CURSED_FURY_NAME", defaultValueFloat, "CURSED_FURY_DESC");
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
                bindSizeMultiplier = config.Bind("Witch", "BIND_SIZE_NAME", defaultValueFloat, "BIND_SIZE_DESC");
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
                longclawBindSizeMultiplier = config.Bind("Witch", "LN_BIND_SIZE_NAME", defaultValueFloat, "LN_BIND_SIZE_DESC");
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
                witchCap = config.Bind("Witch", "WITCH_CAP_NAME", defaultValueInt, "WITCH_CAP_DESC");
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
                refundSilk = config.Bind("Witch", "WITCH_REFUND_NAME", defaultValueBool, "WITCH_REFUND_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "DOUBLE_MIRROR_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "DOUBLE_MIRROR_DESC");
            defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                doubleMirror = config.Bind("Witch", name, defaultValueBool, description);
            }
            else
            {
                doubleMirror = config.Bind("Witch", "DOUBLE_MIRROR_NAME", defaultValueBool, "DOUBLE_MIRROR_DESC");
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
                scavengerChance = config.Bind("Architect", "SHARD_NAME", defaultValueInt, "SHARD_DESC");
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
                craftMaskCount = config.Bind("Architect", "CRAFT_MASK_NAME", defaultValueInt, "CRAFT_MASK_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CRAFT_DEFAULT_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "CRAFT_DEFAULT_DESC");
            defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                craftBindDefault = config.Bind("Architect", name, defaultValueBool, description);
            }
            else
            {
                craftBindDefault = config.Bind("Architect", "CRAFT_DEFAULT_NAME", defaultValueBool, "CRAFT_DEFAULT_DESC");
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
                noDropBind = config.Bind("Shaman", "NO_DROP_NAME", defaultValueBool, "NO_DROP_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "SPELL_NEEDLE_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "SPELL_NEEDLE_DESC");
            defaultValueBool = false;
            if (name.Exists &&
                description.Exists)
            {
                spellNail = config.Bind("Shaman", name, defaultValueBool, description);
            }
            else
            {
                spellNail = config.Bind("Shaman", "SPELL_NEEDLE_NAME", defaultValueBool, "SPELL_NEEDLE_DESC");
            }
            #endregion

            #region Cloakless
            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "PUNCH_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "PUNCH_DESC");
            defaultValueFloat = 1f;
            if (name.Exists &&
                description.Exists)
            {
                punchBonus = config.Bind("Cloakless", name, defaultValueFloat, description);
            }
            else
            {
                punchBonus = config.Bind("Cloakless", "PUNCH_NAME", defaultValueFloat, "PUNCH_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "UNARMED_ATTACK_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "UNARMED_ATTACK_DESC");
            defaultValueFloat = 1f;
            if (name.Exists &&
                description.Exists)
            {
                punchSpeedBonus = config.Bind("Cloakless", name, defaultValueFloat, description);
            }
            else
            {
                punchSpeedBonus = config.Bind("Cloakless", "UNARMED_ATTACK_NAME", defaultValueFloat, "UNARMED_ATTACK_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "UNARMED_MOVE_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "UNARMED_MOVE_DESC");
            defaultValueFloat = 1f;
            if (name.Exists &&
                description.Exists)
            {
                speedBonus = config.Bind("Cloakless", name, defaultValueFloat, description);
            }
            else
            {
                speedBonus = config.Bind("Cloakless", "UNARMED_MOVE_NAME", defaultValueFloat, "UNARMED_MOVE_DESC");
            }

            name = new LocalisedString($"Mods.{CrestOptimizer.Id}", "UNARMED_HEAL_NAME");
            description = new LocalisedString($"Mods.{CrestOptimizer.Id}", "UNARMED_HEAL_DESC");
            defaultValueFloat = -1f;
            if (name.Exists &&
                description.Exists)
            {
                healTime = config.Bind("Cloakless", name, defaultValueFloat, description);
            }
            else
            {
                healTime = config.Bind("Cloakless", "UNARMED_HEAL_NAME", defaultValueFloat, "UNARMED_HEAL_DESC");
            }
            #endregion
        }
    }
}