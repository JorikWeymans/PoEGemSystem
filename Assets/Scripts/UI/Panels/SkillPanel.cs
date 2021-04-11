//Created by Jorik Weymans 2021


using UnityEngine;

namespace Jorik
{
	public sealed class SkillPanel : UIPanel
    {
        [SerializeField] private SkillLine _Line = null;
        protected override void InternalAwake()
        {

        }
        protected override void OnOpen(PanelParams parameters)
        {
            _Line.HideSkillLine(false);
        }

        protected override void OnClose()
        {
            _Line.HideSkillLine(true);
        }

        protected override void InternalUpdate(float elapsed)
        {
            //
        }

        private void CloseWithAnswer(DialogResult answer)
        {
            
        }
    }
}