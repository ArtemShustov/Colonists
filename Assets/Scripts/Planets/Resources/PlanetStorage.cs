using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Planets.Resources {
	public class PlanetStorage: MonoBehaviour {
		private List<ResourceStorage> _storages = new List<ResourceStorage>();

		public IReadOnlyList<ResourceStorage> List => _storages;

		public ResourceStorage Get(Resource resource) {
			return _storages.First(i => i.Resource == resource);
		}
		public ResourceStorage Create(Resource resource){
			var storage = new ResourceStorage(resource);
			_storages.Add(storage);
			return storage;
		}
		public ResourceStorage GetOrCreate(Resource resource) {
			var storage = _storages.FirstOrDefault(i => i.Resource == resource);
			return storage ?? Create(resource);
		}
	}
}