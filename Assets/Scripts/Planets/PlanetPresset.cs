using UnityEngine;

namespace Game.Planets {
	[CreateAssetMenu(menuName = "Game/PlanetPresset")]
	public class PlanetPresset: ScriptableObject {
		[Min(0)]
		[field: SerializeField] public float Radius { get; private set; }
	}
}