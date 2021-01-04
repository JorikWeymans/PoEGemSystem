//Created by Jorik Weymans 2020

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jorik
{
	public sealed class UIController : MonoBehaviour, IUIService
	{
        private Dictionary<string, UIPanel> _Panels = new Dictionary<string, UIPanel>();
        private List<UIPanel> _ActivePanels = new List<UIPanel>();
        public UIPanel TopMostPanel => _ActivePanels.Count > 0 ? _ActivePanels[0] : null;

        private void Awake()
        {
            var panels = gameObject.GetComponentsInChildren<UIPanel>(true);

            foreach (var panel in panels)
            {
                if(panel == null) continue;

                _Panels.Add(panel.name, panel);
                panel.gameObject.SetActive(false);
            }

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
            OpenPanel(MessagePanel.Name, newParams);
        }
        public void AskQuestion(string text, Action<DialogResult> answerHandler = null)
        {
            var newParams = new MessagePanelParams { AnswerHandler = answerHandler, Message = text, Type = MessageType.YesNoQuestion };
            OpenPanel(MessagePanel.Name, newParams);
        }
    }
}

