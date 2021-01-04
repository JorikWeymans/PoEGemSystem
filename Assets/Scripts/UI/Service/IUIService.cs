//Created by Jorik Weymans 2020

using System;

namespace Jorik
{
    public enum DialogResult
    {
        None,
        OK,
        Cancel,
        Yes,
        No,
    }
	public interface IUIService
    {
        UIPanel TopMostPanel { get; }

        bool IsOpen(string panelName);
        UIPanel OpenPanel(string panelName, PanelParams parameters = null);
        void ClosePanel(string panelName);

        void HidePanel(string panelName);

        void ShowPanel(string panelName);

        void CloseAllPanels();

        void DisplayMessage(string text, Action<DialogResult> answerHandler = null);
        void AskQuestion(string text, Action<DialogResult> anwserFunc = null);

       

    }
}