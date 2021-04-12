//Created by Jorik Weymans 2020

using System.Collections.Generic;
using UnityEngine;

namespace Jorik
{
	public sealed class ActiveGem : BaseGem
	{
		//private List<BaseGem>

		private List<BaseGem> _Supports = new List<BaseGem>();
		public int MaxSupportGems { get; private set; } = 3;
	}
}