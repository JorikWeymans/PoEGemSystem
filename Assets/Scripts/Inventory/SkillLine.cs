//Created by Jorik Weymans 2020

using System.Collections.Generic;
using UnityEngine;

namespace Jorik
{
	public sealed class SkillLine : MonoBehaviour
    {
        private List<SkillPanelItemSlot> _Support = new List<SkillPanelItemSlot>();
        private SkillPanelItemSlot _Active = null;

        private void Awake()
        {
            SkillPanelItemSlot[] slots = GetComponentsInChildren<SkillPanelItemSlot>(true);

            foreach (SkillPanelItemSlot slot in slots)
            {
                if(slot.Type == GemType.Support)
                {
                    _Support.Add(slot);
                }
                else
                {
                    _Active = slot;
                }
               
            }

            _Active.AddOnGemAddedListener(gem =>
            {
                ActiveGem activeGem = (ActiveGem) gem;

                for (int i = 0; i < activeGem.MaxSupportGems; i++)
                {
                    _Support[i].gameObject.SetActive(true);
                }
            });


            _Active.AddOnGemRemovedListener(() =>
            {
                _Support.ForEach(slot => slot.gameObject.SetActive(false) );
            });
        }


        public void HideSkillLine(bool hide)
        {
            _Active.HideSlot(hide);
            _Support.ForEach(slot => slot.HideSlot(hide));
        }
    }
}

