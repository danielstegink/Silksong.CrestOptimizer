using System;
using TeamCherry.Localization;
using UnityEngine;

namespace CrestOptimizer.Helpers
{
    internal class SpellTool : ToolItem
    {
        public override UsageOptions Usage => throw new NotImplementedException();

        public override LocalisedString DisplayName => throw new NotImplementedException();

        public override LocalisedString Description => throw new NotImplementedException();

        public override Sprite GetHudSprite(IconVariants iconVariant)
        {
            throw new NotImplementedException();
        }

        public override Sprite GetInventorySprite(IconVariants iconVariant)
        {
            throw new NotImplementedException();
        }

        internal SpellTool() : base()
        {
            type = ToolItemType.Skill;
            zapDamageTicks = 1;
        }
    }
}