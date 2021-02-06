//Created by Jorik Weymans 2020

using UnityEngine;

namespace Jorik.Input
{
	[CreateAssetMenu(fileName = "new Input", menuName = "Input")]
	public sealed class Input : ScriptableObject
	{
		public UIInputSettings UIInput {  set; get; } = default;

        public void Generate()
        {
            UIInput = new UIInputSettings();
            UIInput.Enable();
        }
	}
}

