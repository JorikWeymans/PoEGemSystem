//Created by Jorik Weymans 2020

using UnityEngine;

namespace Jorik
{
	public sealed class ServiceLocator
	{
		public static IUIService UI { get; set; } = new UINullService();
	}
}