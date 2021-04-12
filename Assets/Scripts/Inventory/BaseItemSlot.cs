//Created by Jorik Weymans 2021

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Jorik
{
    [RequireComponent(typeof(JButton))]
	public class BaseItemSlot : MonoBehaviour, IItemSlot
    {
        [SerializeField] protected BaseGem _Gem = null;
        public BaseGem Gem => _Gem;

        [SerializeField] protected bool _SlotCanBeModified = true;
        public bool SlotCanBeModified => _SlotCanBeModified;
        [SerializeField] private UnityEvent<BaseGem> _OnGemAdded = new UnityEvent<BaseGem>();
        [SerializeField] private UnityEvent _OnGemRemoved = new UnityEvent();
        
        private void Awake()
        {
            JButton button = GetComponent<JButton>();
            button.AddListener(JButton.ActionType.OnTriggerEnter, TriggerEnter);
            button.AddListener(JButton.ActionType.OnPointerUp, PointerUp);
            button.AddListener(JButton.ActionType.OnPointerHover, PointerHovering);
        }


        public void TriggerEnter(Collider2D coll)
        {

        }

        public void PointerHovering(PointerEventData eventData)
        {
        }
        public virtual void PointerUp(PointerEventData eventData)
        {
            if (!_SlotCanBeModified) return;

            if (Cursor.HasGem())
            {
                if (_Gem != null) return;

                AddGemToSlot();
            }
            else if(_Gem)
            {
                RemoveGemFromSlot();
            }
        }

        public void HideSlot(bool hide)
        {
            _Gem?.gameObject.SetActive(!hide);
        }


        public void AddOnGemAddedListener(UnityAction<BaseGem> func)
        {
            _OnGemAdded.AddListener(func);
            
        }
        public void RemoveOnGemAddedListener(UnityAction<BaseGem> func)
        {
            _OnGemAdded.RemoveListener(func);

        }

        public void AddOnGemRemovedListener(UnityAction func)
        {
            _OnGemRemoved.AddListener(func);

        }
        public void RemoveOnGemRemovedListener(UnityAction func)
        {
            _OnGemRemoved.RemoveListener(func);

        }


        protected void AddGemToSlot()
        {
            _Gem = Cursor.RemoveGem();
            RectTransform rect = GetComponent<RectTransform>();

            Vector3 newPosition = rect.transform.position;

            _Gem.gameObject.transform.position = newPosition;
            _OnGemAdded?.Invoke(_Gem);
        }

        protected void RemoveGemFromSlot()
        {
            Cursor.SetGem(_Gem);
            _Gem = null;
            _OnGemRemoved?.Invoke();
        }
    }
}

