using System;
using UnityEngine;

namespace Game.Planets {
	public class TickManager: MonoBehaviour {
		[field: Min(1)]
		[field: SerializeField] public int TickRate { get; private set; } = 1;

		private float _timer = 0;

		public float TickTime => 1f / TickRate;

		public event Action GeneratorsTick;
		public event Action Tick;

		private void Update() {
			_timer += Time.deltaTime;
			while (_timer >= TickTime) {
				OnTick();
				_timer -= TickTime;
			}
		}

		private void OnTick() {
			GeneratorsTick?.Invoke();
			Tick?.Invoke();
		}
	}
}