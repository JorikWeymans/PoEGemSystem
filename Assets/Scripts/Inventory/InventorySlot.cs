//Created by Jorik Weymans 2021

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Jorik
{
    [RequireComponent(typeof(JButton))]
	public sealed class InventorySlot : MonoBehaviour
    {
        private BaseGem _Gem = null;

        private void Awake()
        {
            JButton button = GetComponent<JButton>();
            button.AddListener(JButton.ActionType.OnTriggerEnter, TriggerEnter);
            button.AddListener(JButton.ActionType.OnPointerUp, PointerUp);
            button.AddListener(JButton.ActionType.OnPointerHover, PointerHovering);
        }


        private void TriggerEnter(Collider2D coll)
        {

        }

        private void PointerHovering(PointerEventData eventData)
        {
        }
        private void PointerUp(PointerEventData eventData)
        {
            Debug.Log("Pointer UP");
            if (Cursor.HasGem())
            {
                _Gem = Cursor.RemoveGem();

                RectTransform rect = GetComponent<RectTransform>();

                Vector3 newPosition = rect.transform.position;

                _Gem.gameObject.transform.position = newPosition;
            }
            else if(_Gem)
            {
                Cursor.SetGem(_Gem);
                _Gem = null;
            }
        }

    }
}

