using System;
using UnityEngine;

namespace Game.Planets.Resources {
	[Serializable]
	public class ResourceSource {
		[field: SerializeField] public Resource Resource { get; private set; }

		public ResourceSource(Resource resource) {
			Resource = resource;
		}
	}
}