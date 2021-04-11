//Created by Jorik Weymans 2020

using System.Collections.Generic;
using UnityEngine;

namespace Jorik
{
	public sealed class SkillLine : MonoBehaviour
    {
        private List<ItemSlot> _Slots = new List<ItemSlot>();

        private void Awake()
        {
            ItemSlot[] slots = GetComponentsInChildren<ItemSlot>();

            foreach (ItemSlot slot in slots)
            {
                _Slots.Add(slot);
            }
        }


        public void HideSkillLine(bool hide)
        {
            _Slots.ForEach(slot => slot.HideSlot(hide));
        }
    }
}

