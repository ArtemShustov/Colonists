using Game.Planets.Resources;
using UnityEngine;

namespace Game.Planets {
	public class Planet: MonoBehaviour {
		[SerializeField] private PlanetPresset _presset;
		[field: SerializeField] public TickManager TickManager { get; private set; }
		[field: SerializeField] public PlanetStorage Storage { get; private set; }

		public float Radius => _presset.Radius;

		public Vector2 GetPointOnSurface(Vector2 pointOver) {
			Vector2 direction = pointOver - (Vector2)transform.position;
			var point = (Vector2)transform.position + direction.normalized * Radius;
			return point;
		}
		public Vector2 GetSurfaceNormal(Vector2 pointOver) {
			return (pointOver - (Vector2)transform.position).normalized;
		}
	}
}