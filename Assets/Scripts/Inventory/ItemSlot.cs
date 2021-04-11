//Created by Jorik Weymans 2021

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Jorik
{
    [RequireComponent(typeof(JButton))]
	public class ItemSlot : MonoBehaviour
    {
        private BaseGem _Gem = null;
        public BaseGem Gem => _Gem;

        [SerializeField] protected bool _SlotCanBeModified = true;
        public bool SlotCanBeModified => _SlotCanBeModified;
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
            if (!_SlotCanBeModified) return;

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

        public void HideSlot(bool hide)
        {
            _Gem?.gameObject.SetActive(!hide);
        }
    }
}

