﻿//Created by Jorik Weymans 2021

using System;
using System.Collections.Generic;
using UnityEngine;
using Jorik.Input;

namespace Jorik
{
	public sealed class UIController : MonoBehaviour, IUIService
	{
        private Dictionary<string, UIPanel> _Panels = new Dictionary<string, UIPanel>();
        private List<UIPanel> _ActivePanels = new List<UIPanel>();
        public UIPanel TopMostPanel => _ActivePanels.Count > 0 ? _ActivePanels[0] : null;

        private Input.Input _Input = default;

        private void Awake()
        {
            var panels = gameObject.GetComponentsInChildren<UIPanel>(true);

            foreach (var panel in panels)
            {
                if(panel == null) continue;

                _Panels.Add(panel.name, panel);
                panel.gameObject.SetActive(false);
            }

            _Input = Resources.Load<Input.Input>("DefaultInput");
            _Input.Generate();
            
            _Input.UIInput.TogglePanels.SkillPanel.performed += _ => ToggleSkillPanel();
            _Input.UIInput.TogglePanels.InventoryPanel.performed += _ => ToggleInventoryPanel();

            ServiceLocator.UI = this;
        }
        private void Update()
        {

            TopMostPanel?.UpdatePanel(Time.deltaTime);
        }

        public bool IsOpen(string panelName)
        {
            if (!_Panels.ContainsKey(panelName)) 
                return false;
            
            UIPanel thePanel = _Panels[panelName];
            return _ActivePanels.Contains(thePanel);

        }

        public UIPanel OpenPanel(string panelName, PanelParams parameters = null)
        {
            UIPanel returnPanel = null;
            if (!_Panels.ContainsKey(panelName)) 
                return null; 

            returnPanel = _Panels[panelName];

            if (!_ActivePanels.Contains(returnPanel))
            {
                returnPanel.gameObject.SetActive(true);
                _ActivePanels.Insert(0,returnPanel);
                returnPanel.Open(parameters);
            }

            return returnPanel;
        }

        public void ClosePanel(string panelName)
        {
            if (!_Panels.ContainsKey(panelName))
                return;

            UIPanel panel = _Panels[panelName];
            if (!_ActivePanels.Contains(panel))
                return;

            _ActivePanels.Remove(panel);
            panel.gameObject.SetActive(false);
            panel.Close();
        }

        public void HidePanel(string panelName)
        {
            if (!_Panels.ContainsKey(panelName))
                return;

            UIPanel panel = _Panels[panelName];
            if (!_ActivePanels.Contains(panel)) 
                return;
            
            panel.Hide();
        }

        public void ShowPanel(string panelName)
        {
            if (!_Panels.ContainsKey(panelName)) 
                return;
            
            UIPanel panel = _Panels[panelName];
            if (!_ActivePanels.Contains(panel)) 
                return;
            
            panel.Show();
        }

        public void CloseAllPanels()
        {
            foreach (string panelsKey in _Panels.Keys)
            {
                UIPanel panel = _Panels[panelsKey];
                if (_ActivePanels.Contains(panel))
                {
                    ClosePanel(panelsKey);
                }
            }
        }

        public void DisplayMessage(string text, Action<DialogResult> answerHandler = null)
        {
            var newParams = new MessagePanelParams { AnswerHandler = answerHandler, Message = text, Type = MessageType.Message };
            OpenPanel(PanelNames.MessagePanel, newParams);
        }
        public void AskQuestion(string text, Action<DialogResult> answerHandler = null)
        {
            var newParams = new MessagePanelParams { AnswerHandler = answerHandler, Message = text, Type = MessageType.YesNoQuestion };
            OpenPanel(PanelNames.MessagePanel, newParams);
        }

        private void ToggleSkillPanel()
        {
            if (IsOpen(PanelNames.SkillPanel))
            {
                ClosePanel(PanelNames.SkillPanel);
            }
            else
            {
                OpenPanel(PanelNames.SkillPanel);
            }
        }

        private void ToggleInventoryPanel()
        {
            if (IsOpen(PanelNames.InventoryPanel))
            {
                ClosePanel(PanelNames.InventoryPanel);
            }
            else
            {
                OpenPanel(PanelNames.InventoryPanel);
            }
        }
    }
}

