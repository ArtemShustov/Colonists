using System;
using UnityEngine;

namespace Game.Buildings {
	[Serializable]
	public struct Rate {
		[SerializeField] public int Time;
		[SerializeField] public int Count;
	}
}