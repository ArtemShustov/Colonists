using UnityEngine;

namespace Game.Logging {
	[CreateAssetMenu(menuName = "GameLogger")]
	public class GameLogger: ScriptableObject {
		[SerializeField] private bool _enabled = true;

		public void Log(object message) {
			if (_enabled) {
				Debug.Log($"[{this.name}] {message}");
			}
		}
	}
}