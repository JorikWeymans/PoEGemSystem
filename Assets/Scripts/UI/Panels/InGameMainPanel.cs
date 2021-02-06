//Created by Jorik Weymans 2020

using UnityEngine;

namespace Jorik
{
	public sealed class InGameMainPanel : UIPanel
	{

        private MessagePanelParams _myParams;
        protected override void InternalAwake()
        {
        }
        protected override void OnOpen(PanelParams parameters)
        {
            
        }

        protected override void InternalUpdate(float elapsed)
        {
          // if (Input.GetKeyUp(KeyCode.A))
          // {
          //     ServiceLocator.UI.AskQuestion("Are you sure?", result =>
          //     {
          //         if (result == DialogResult.Yes)
          //         {
          //             Debug.Log("Ye sure");
          //         }
          //         else if( result == DialogResult.No)
          //         {
          //             Debug.Log("Ye not sure");
          //         }
          //     });
          // }
          //
          //
          // if (Input.GetKeyUp(KeyCode.Q))
          // {
          //     ServiceLocator.UI.DisplayMessage("Read this message", result =>
          //     {
          //         if (result == DialogResult.OK)
          //         {
          //             Debug.Log("Ok man");
          //         }
          //     });
          // }
        }

    }
}

