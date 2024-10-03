using System;
using UnityEngine;

namespace Game.Planets.Resources {
	[Serializable]
	public class ResourceStorage {
		[Min(0)]
		[field: SerializeField] public int Capacity { get; private set; }
		[field: SerializeField] public Resource Resource { get; private set; }
		
		public int Value { get; private set; }

		public ResourceStorage(Resource resource) {
			Resource = resource;
		}

		public void Add(int count) {
			Value = Mathf.Min(Value + Mathf.Abs(count), Capacity);
		}
		public bool Take(int count) {
			if (count <= Value) {
				Value -= count;
				return true;
			}
			return false;
		}

		public void IncreaseCapacity(int amount) {
			Capacity += Mathf.Abs(amount);
		}
		public void DecreaseCapacity(int amount) {
			Capacity = Mathf.Max(0, Capacity - Mathf.Abs(amount));

			if (Value > Capacity) {
				Value = Capacity;
			}
		}
	}
}