//Created by Jorik Weymans 2020

using System;
using UnityEngine;

namespace Jorik
{ 
    public class UIPanel : MonoBehaviour
	{
        public virtual bool HidesHUD => true;
        protected PanelParams Params { get; private set; }
        protected IUIService Controller => ServiceLocator.UI;

        [SerializeField] protected UIButtonGroup _Buttons = null;
        private void Awake()
        {
            _Buttons.Initialize();
            InternalAwake();
        }
        public void Open(PanelParams parameters)
        {
            Params = parameters;
            _Buttons.Enter();
            Show();
            OnOpen(parameters);

        }
        public virtual void Close()
        {
            _Buttons.Exit();
            OnClose();
        }
        public virtual void Hide()
        {
            var canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0.0f;
            }
        }
        public virtual void Show()
        {
            var canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1.0f;
            }
        }

        //this cannot be called Update if there are parameters -> "Script error (MessagePanel): Update() can not take parameters."
        public void UpdatePanel(float elapsed)
        {

            _Buttons.Update(elapsed);

            InternalUpdate(elapsed);
        }

        protected virtual void InternalUpdate(float elapsed) { }
        protected virtual void InternalAwake() { }
        protected virtual void OnOpen(PanelParams parameters) { }
        protected virtual void OnClose() { }

    }

    public class PanelParams
    {
        public Action<UIPanel> CallbackOnExit { get; set; }

        public string PreviousPanelName { get; set; }
    }

}

