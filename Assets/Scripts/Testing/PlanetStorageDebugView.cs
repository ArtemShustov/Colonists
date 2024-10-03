using Game.Planets;
using UnityEngine;

namespace Game.Testing {
	public class PlanetStorageDebugView: MonoBehaviour {
		[Range(0, 128)]
		[SerializeField] private int _fontSize;
		[SerializeField] private Planet _planet;

		private void OnGUI() {
			if (_planet == null) {
				return;
			}
			var style = new GUIStyle();
			style.fontSize = _fontSize;
			foreach (var storage in _planet.Storage.List) {
				var text = $"x{storage.Value}/{storage.Capacity} of {storage.Resource.Id}";
				GUILayout.TextArea(text, style);
			}
		}
	}
}