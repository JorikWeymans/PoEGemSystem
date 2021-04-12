//Created by Jorik Weymans 2020

using UnityEngine;
using UnityEngine.EventSystems;

namespace Jorik
{
	public interface IItemSlot
    {
        bool SlotCanBeModified { get; }



        void TriggerEnter(Collider2D coll);
        void PointerHovering(PointerEventData eventData);
        void PointerUp(PointerEventData eventData);

    }
}