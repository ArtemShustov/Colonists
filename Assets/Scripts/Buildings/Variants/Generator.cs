using Game.Logging;
using Game.Planets.Resources;
using UnityEngine;

namespace Game.Buildings.Variants {
	public sealed class Generator: Building {
		[SerializeField] private Resource _resource;
		[SerializeField] private Rate _rate;
		[Space]
		[SerializeField] private GameLogger _logger;

		private ResourceStorage _storage;
		private int _timer = 0;

		private void Awake() {
			_storage = Planet.Storage.GetOrCreate(_resource);
		}

		private void OnGeneratorsTick() {
			_timer += 1;
			if (_timer >= _rate.Time) {
				_timer = 0;
				_storage.Add(_rate.Count);
				_logger?.Log($"Added {_rate.Count} of {_resource.Id}. Total: {_storage.Value}/{_storage.Capacity}");
			}
		}

		private void OnEnable() {
			Planet.TickManager.GeneratorsTick += OnGeneratorsTick;
		}
		private void OnDisable() {
			Planet.TickManager.GeneratorsTick -= OnGeneratorsTick;
		}
	}
}