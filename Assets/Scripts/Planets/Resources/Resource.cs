using UnityEngine;

namespace Game.Planets.Resources {
	[CreateAssetMenu(menuName = "Game/Resource")]
	public class Resource: ScriptableObject {
		[field: SerializeField] public Sprite Icon { get; private set; }
		[field: SerializeField] public string Id { get; private set; }
	}
}