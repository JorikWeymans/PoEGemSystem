//Created by Jorik Weymans 2020

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Jorik
{
    [Serializable]
	public sealed class UIButtonGroup
	{
        [SerializeField] private List<Button> _Buttons = null;

        private bool HasNoButtons => _Buttons.Count == 0;
        public void Initialize()
        {
            if (HasNoButtons) return;
        }

        public void Enter()
        {
            if (HasNoButtons) return;
        }
        public void Update(float elapsed)
        {
            if (HasNoButtons) return;
        }

        public void Exit()
        {
            if (HasNoButtons) return;
        }

        public Button GetButton(string buttonName)
        {
            return _Buttons.FirstOrDefault(b => b.name == buttonName);
        }
        public void SetIsHidden(string buttonName, bool value)
        {
            foreach (Button b in _Buttons.Where(b => b.name == buttonName))
            {
                b.gameObject.SetActive(!value);
            }

        }
    }
}