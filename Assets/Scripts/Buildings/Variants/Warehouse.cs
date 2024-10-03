using Game.Logging;
using Game.Planets.Resources;
using UnityEngine;

namespace Game.Buildings.Variants {
	public sealed class Warehouse: Building {
		[Min(0)]
		[SerializeField] private int _amount = 1;
		[SerializeField] private Resource _resource;
		[Space]
		[SerializeField] private GameLogger _logger;

		private ResourceStorage _storage;

		private void Awake() {
			_storage = Planet.Storage.GetOrCreate(_resource);
		}

		private void OnEnable() {
			_storage.IncreaseCapacity(_amount);
			_logger?.Log($"IncreaseCapacity of {_storage.Resource.Id} by {_amount}. Current: {_storage.Capacity}");
		}
		private void OnDisable() {
			_storage.DecreaseCapacity(_amount);
			_logger?.Log($"DecreaseCapacity of {_storage.Resource.Id} by {_amount}. Current: {_storage.Capacity}");
		}
	}
}