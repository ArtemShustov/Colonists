using System;
using UnityEngine;

namespace Game.Planets.Resources {
	[Serializable]
	public class ResourceStorage {
		[Min(0)]
		[field: SerializeField] public int Capacity { get; private set; }
		[field: SerializeField] public Resource Resource { get; private set; }
		
		public int Value { get; private set; }

		public event Action<ResourceStorage> Changed;

		public ResourceStorage(Resource resource) {
			Resource = resource;
		}

		public void Add(int count) {
			Value = Mathf.Min(Value + Mathf.Abs(count), Capacity);
			Changed?.Invoke(this);
		}
		public bool Take(int count) {
			if (count <= Value) {
				Value -= count;
				Changed?.Invoke(this);
				return true;
			}
			return false;
		}

		public bool CanTake(int count) {
			return count <= Value;
		}

		public void IncreaseCapacity(int amount) {
			Capacity += Mathf.Abs(amount);
			Changed?.Invoke(this);
		}
		public void DecreaseCapacity(int amount) {
			Capacity = Mathf.Max(0, Capacity - Mathf.Abs(amount));

			if (Value > Capacity) {
				Value = Capacity;
			}

			Changed?.Invoke(this);
		}
	}
}