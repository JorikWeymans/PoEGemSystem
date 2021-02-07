//Created by Jorik Weymans 2020

using UnityEngine;

namespace Jorik
{
	public sealed class InventorySlot : MonoBehaviour
    {
        private BaseGem _Gem = null;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.CompareTag("Gem"))
            {
                BaseGem baseGem = coll.gameObject.GetComponent<BaseGem>();
                if (baseGem == null) return;

                if (baseGem._State == GemState.Cursor)
                {
                    baseGem._State = GemState.CharacterInventory;

                    
                    RectTransform rect = GetComponent<RectTransform>();

                    Vector3 newPosition = rect.transform.position;
                   //newPosition.x += rect.rect.width;//* .5f;
                   //newPosition.y += rect.rect.height;// * .5f;

                    coll.gameObject.transform.position = newPosition;

                }
            }
            else
            {
                Debug.Log("It's something else");
            }
        }

    }
}

