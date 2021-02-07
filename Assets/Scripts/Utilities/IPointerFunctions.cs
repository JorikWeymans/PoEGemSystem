//Created by Jorik Weymans 2020

using UnityEngine;
using UnityEngine.EventSystems;

namespace Jorik.Utilities
{
	public interface IPointerFunctions : IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        void OnPointerDrag(PointerEventData eventData);
        void OnPointerHover(PointerEventData eventData);
    }
}