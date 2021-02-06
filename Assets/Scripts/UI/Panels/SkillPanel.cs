//Created by Jorik Weymans 2020

using System;
using TMPro;
using UnityEngine;

namespace Jorik
{
	public sealed class SkillPanel : UIPanel
	{
        public static readonly string Name = "MessagePanel";

        [SerializeField] private TMP_Text _Text = null;

        private MessagePanelParams _myParams;
        protected override void InternalAwake()
        {

        }
        protected override void OnOpen(PanelParams parameters)
        {
        }

        protected override void InternalUpdate(float elapsed)
        {
            //
        }

        private void CloseWithAnswer(DialogResult answer)
        {
            _myParams.AnswerHandler?.Invoke(answer);
        }
    }
}