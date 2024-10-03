using Game.Planets;
using UnityEngine;

namespace Game.Buildings {
	public class BuildingPlacement: MonoBehaviour {
		[SerializeField] public Planet _planet;

		public void PlaceHere() {
			transform.position = _planet.GetPointOnSurface(transform.position);
			transform.up = _planet.GetSurfaceNormal(transform.position);
		}
		public void SetPlanet(Planet planet) {
			_planet = planet;
		}
	}
}