//Created by Jorik Weymans 2020

using UnityEngine;
using UnityEngine.EventSystems;

namespace Jorik
{
	public sealed class SkillPanelItemSlot : BaseItemSlot
    {
        [SerializeField] private GemType _Type = GemType.Active;
        public GemType Type => _Type;
        public override void PointerUp(PointerEventData eventData)
        {
            if (!_SlotCanBeModified) return;

            if (Cursor.HasGem())
            {
                if (_Gem != null || 
                    _Type != Cursor.GetGem().Type) return;

                AddGemToSlot();
            }
            else if (_Gem)
            {
                RemoveGemFromSlot();
            }

        }
    }
}