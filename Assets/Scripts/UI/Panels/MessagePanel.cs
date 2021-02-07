//Created by Jorik Weymans 2020

using System;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Jorik
{
    public sealed class MessagePanel : UIPanel
    {

        [SerializeField] private TMP_Text _Text = null;

        private const string btnOkName  = "btnOk";
        private const string btnYesName = "btnYes";
        private const string btnNoName  = "btnNo";

        private MessagePanelParams _myParams;
        protected override void InternalAwake()
        {
            _Buttons.GetButton(btnOkName).onClick.AddListener(OnOkClicked);
            _Buttons.GetButton(btnYesName).onClick.AddListener(OnYesClicked);
            _Buttons.GetButton(btnNoName).onClick.AddListener(OnNoClicked);
        }
        protected override void OnOpen(PanelParams parameters)
        {
            _myParams = parameters as MessagePanelParams;
            if (_myParams == null) return;

            _Text.text = _myParams.Message;
            switch (_myParams.Type)
            {
                case MessageType.YesNoQuestion:
                    _Buttons.SetIsHidden(btnOkName, true);
                    _Buttons.SetIsHidden(btnYesName, false);
                    _Buttons.SetIsHidden(btnNoName, false);
                    break;
                case MessageType.Message:
                    _Buttons.SetIsHidden(btnOkName, false);
                    _Buttons.SetIsHidden(btnYesName, true);
                    _Buttons.SetIsHidden(btnNoName, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void InternalUpdate(float elapsed)
        {
            //
        }

        public void OnOkClicked()
        {
            CloseWithAnswer(DialogResult.OK);
        }

        public void OnYesClicked()
        {
            CloseWithAnswer(DialogResult.Yes);
        }

        public void OnNoClicked()
        {
            CloseWithAnswer(DialogResult.No);
        }

        private void CloseWithAnswer(DialogResult answer)
        {
            ServiceLocator.UI.ClosePanel(PanelNames.MessagePanel);
            _myParams.AnswerHandler?.Invoke(answer);
        }
    }
    public enum MessageType
    {
        Message,
        YesNoQuestion
    }
    public class MessagePanelParams : PanelParams
    {
        public MessageType Type { get; set; }
        public Action<DialogResult> AnswerHandler { get; set; }
        public string Message { get; set; }
    }
}
