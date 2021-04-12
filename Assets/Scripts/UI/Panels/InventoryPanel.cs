//Created by Jorik Weymans 2021

using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Jorik
{
    public sealed class InventoryPanel : UIPanel
    {
        [SerializeField] private GameObject _GoInventorySlotHolder = null;
        private List<BaseItemSlot> _Slots = new List<BaseItemSlot>();  
        protected override void InternalAwake()
        {
            BaseItemSlot[] slots = _GoInventorySlotHolder.GetComponentsInChildren<BaseItemSlot>();
            foreach (BaseItemSlot itemSlot in slots)
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