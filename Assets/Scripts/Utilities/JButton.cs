//Created by Jorik Weymans 2021

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Jorik.Utilities;
using UnityEngine.InputSystem;

namespace Jorik
{
    [RequireComponent(typeof(Collider2D))] //the button does not have the be a square, it just needs to have a collider
    public sealed class JButton : MonoBehaviour, IOverlapFunctions2D, IPointerFunctions
	{
        //[SerializeField] private IntractableImage[] _IntractableImages = null;

        private event Action<PointerEventData> _OnPointerDown = default, _OnPointerDrag = default, _OnPointerUp = default;
        private event Action<PointerEventData> _OnPointerEnter = default, _OnPointerHover = default, _OnPointerExit = default;
        private event Action<Collider2D> _OnTriggerEnter = default, _OnTriggerExit = default, _OnTriggerStay = default;
        public bool IsActive { get; private set; } = true;

        private bool _IsHovering = false;
        private PointerEventData _CachedData = default;
        private void Awake()
        {
           // //Hooking up the intractableImages actions
           // foreach (var i in _IntractableImages)
           // {
           //     AddListener(ActionType.OnMouseDown, () => i.OnMouseDown());
           //     AddListener(ActionType.OnMouseDrag, () => i.OnMouseDrag());
           //     AddListener(ActionType.OnMouseUp, () => i.OnMouseUp());
           //
           //     AddListener(ActionType.OnMouseEnter, () => i.OnMouseEnter());
           //     AddListener(ActionType.OnMouseOver, () => i.OnMouseOver());
           //     AddListener(ActionType.OnMouseExit, () => i.OnMouseExit());
           // }
        }

        public void SetActive(bool value)
        {
            IsActive = value;
        }

        private void Update()
        {
            if (!IsActive) return;

            if (_IsHovering)
            {
                _CachedData.position = Mouse.current.position.ReadValue();
                _OnPointerHover?.Invoke(_CachedData);
            }

        }
        //Pointer functions
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!IsActive) return;

            _OnPointerDown?.Invoke(eventData);
        }

        public void OnPointerDrag(PointerEventData eventData)
        {
            if (!IsActive) return;

            _OnPointerDrag?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!IsActive) return;

            _OnPointerUp?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!IsActive) return;

            _IsHovering = true;
            _CachedData = eventData;
            _OnPointerEnter?.Invoke(eventData);
        }

        public void OnPointerHover(PointerEventData eventData)
        {
            if (!IsActive) return;

    

            _OnPointerHover?.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!IsActive) return;
            _IsHovering = false;
            _CachedData = null;
            _OnPointerExit?.Invoke(eventData);
        }


        //Overlap functions
        public void OnTriggerEnter2D(Collider2D coll)
        {
            if (!IsActive) return;

            _OnTriggerEnter?.Invoke(coll);
        }

        public void OnTriggerExit2D(Collider2D coll)
        {
            if (!IsActive) return;

            _OnTriggerExit?.Invoke(coll);
        }

        public void OnTriggerStay2D(Collider2D coll)
        {
            if (!IsActive) return;

            _OnTriggerStay?.Invoke(coll);
        }

        //*******************************//
        //** Adding/Removing Listeners **//
        //*******************************//
        public enum ActionType
        {
            OnPointerDown, OnPointerDrag, OnPointerUp,
            OnPointerEnter, OnPointerHover, OnPointerExit,
            OnTriggerEnter, OnTriggerExit, OnTriggerStay
        }

        public void AddListener(ActionType type, Action<PointerEventData> action)
        {
            switch (type)
            {
                case ActionType.OnPointerDown:
                    _OnPointerDown += action;
                    break;
                case ActionType.OnPointerDrag:
                    _OnPointerDrag += action;
                    break;
                case ActionType.OnPointerUp:
                    _OnPointerUp += action;
                    break;
                case ActionType.OnPointerEnter:
                    _OnPointerEnter += action;
                    break;
                case ActionType.OnPointerHover:
                    _OnPointerHover += action;
                    break;
                case ActionType.OnPointerExit:
                    _OnPointerExit += action;
                    break;
                case ActionType.OnTriggerEnter:
                case ActionType.OnTriggerExit:
                case ActionType.OnTriggerStay:
                    throw new Exception("You can't add a trigger action without a collider as input");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        public void RemoveListener(ActionType type, Action<PointerEventData> action)
        {
            switch (type)
            {
                case ActionType.OnPointerDown:
                    _OnPointerDown -= action;
                    break;
                case ActionType.OnPointerDrag:
                    _OnPointerDrag -= action;
                    break;
                case ActionType.OnPointerUp:
                    _OnPointerUp -= action;
                    break;
                case ActionType.OnPointerEnter:
                    _OnPointerEnter -= action;
                    break;
                case ActionType.OnPointerHover:
                    _OnPointerHover -= action;
                    break;
                case ActionType.OnPointerExit:
                    _OnPointerExit -= action;
                    break;
                case ActionType.OnTriggerEnter:
                case ActionType.OnTriggerExit:
                case ActionType.OnTriggerStay:
                    throw new Exception("You can't remove a trigger action without a collider as input");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        public void AddListener(ActionType type, Action<Collider2D> action)
        {
            switch (type)
            {
                case ActionType.OnPointerDown:
                case ActionType.OnPointerDrag:
                case ActionType.OnPointerUp:
                case ActionType.OnPointerEnter:
                case ActionType.OnPointerHover:
                case ActionType.OnPointerExit:
                    throw new Exception("You can't add a mouse action with a collider as input");

                case ActionType.OnTriggerEnter:
                    _OnTriggerEnter += action;
                    break;
                case ActionType.OnTriggerExit:
                    _OnTriggerExit += action;
                    break;
                case ActionType.OnTriggerStay:
                    _OnTriggerStay += action;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        public void RemoveListener(ActionType type, Action<Collider2D> action)
        {
            switch (type)
            {
                case ActionType.OnPointerDown:
                case ActionType.OnPointerDrag:
                case ActionType.OnPointerUp:
                case ActionType.OnPointerEnter:
                case ActionType.OnPointerHover:
                case ActionType.OnPointerExit:
                    throw new Exception("You can't remove a mouse action with a collider as input");

                case ActionType.OnTriggerEnter:
                    _OnTriggerEnter -= action;
                    break;
                case ActionType.OnTriggerExit:
                    _OnTriggerExit -= action;
                    break;
                case ActionType.OnTriggerStay:
                    _OnTriggerStay -= action;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }



    }
}

