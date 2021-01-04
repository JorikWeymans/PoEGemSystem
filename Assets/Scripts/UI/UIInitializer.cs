//Created by Jorik Weymans 2020

using UnityEngine;

namespace Jorik
{
	public sealed class UIInitializer : MonoBehaviour
	{
        private void Start()
        {
            ServiceLocator.UI.OpenPanel("MainPanel");
        }
	}
}

