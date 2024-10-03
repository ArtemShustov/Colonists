using UnityEngine;

namespace Game.Buildings {
	public class AutoPlace: MonoBehaviour {
		[SerializeField] private BuildingPlacement _placement;

		private void OnEnable() {
			_placement.PlaceHere();
		}
	}
}