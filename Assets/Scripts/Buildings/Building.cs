using Game.Planets;
using UnityEngine;

namespace Game.Buildings {
	public class Building: MonoBehaviour {
		[field: SerializeField] public Planet Planet { get; private set; }

		public void SetPlanet(Planet planet) {
			Planet = planet;
		}
	}
}