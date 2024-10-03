using Game.Planets.Resources;
using UnityEngine;

namespace Game.Buildings.Variants {
	public sealed class Factory: Building {
		[SerializeField] private Rate _rate;
		[SerializeField] private int _inputCount;
		[SerializeField] private Resource _input;
		[SerializeField] private int _outputCount;
		[SerializeField] private Resource _output;

		private ResourceStorage _inputStorge;
		private ResourceStorage _outputStorge;

		private int _timer = 0;

		private void Awake() {
			_inputStorge = Planet.Storage.GetOrCreate(_input);
			_outputStorge = Planet.Storage.GetOrCreate(_output);
		}

		private void OnTick() {
			_timer++;
			if (_timer >= _rate.Time) {
				_timer = 0;
				for (var i = 0; i < _rate.Count; i++) {
					if (_inputStorge.Take(_inputCount)) {
						_outputStorge.Add(_outputCount);
					}
				}
			}
		}

		private void OnEnable() {
			Planet.TickManager.Tick += OnTick;
		}
		private void OnDisable() {
			Planet.TickManager.Tick -= OnTick;
		}
	}
}