//Created by Jorik Weymans 2021

using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Jorik
{
    public sealed class InventoryPanel : UIPanel
    {
        [SerializeField] private GameObject _GoInventorySlotHolder = null;
        private List<ItemSlot> _Slots = new List<ItemSlot>();  
        protected override void InternalAwake()
        {
            ItemSlot[] slots = _GoInventorySlotHolder.GetComponentsInChildren<ItemSlot>();
            foreach (ItemSlot itemSlot in slots)
            {
                _Slots.Add(itemSlot);
            }
        }
        protected override void OnOpen(PanelParams parameters)
        {
            _Slots.ForEach(slot => slot.HideSlot(false));
        }

        protected override void OnClose()
        {
            _Slots.ForEach(slot => slot.HideSlot(true) );
        }

        protected override void InternalUpdate(float elapsed)
        {
            //
        }

        private void CloseWithAnswer(DialogResult answer)
        {

        }
    }
}