//Created by Jorik Weymans 2020

using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Jorik
{
	public sealed class UINullService : IUIService
    {
        public UIPanel TopMostPanel { get; } = null;
        public bool IsOpen(string panelName) => false;

        public UIPanel OpenPanel(string panelName, PanelParams parameters) => null;

        public void ClosePanel(string panelName) { }

        public void HidePanel(string panelName)  { }

        public void ShowPanel(string panelName) { }

        public void CloseAllPanels() { }

        public void DisplayMessage(string text, Action<DialogResult> answerHandler = null) { }
        public void AskQuestion(string text, Action<DialogResult> answerHandler = null) { }
    }
}