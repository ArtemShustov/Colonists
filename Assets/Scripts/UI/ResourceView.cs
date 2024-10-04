using Game.Planets;
using Game.Planets.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
	public class ResourceView: MonoBehaviour {
		[SerializeField] private string _pattern = "{2}: {0}/{1}";
		[SerializeField] private Resource _resource;
		[SerializeField] private Planet _planet;
		[SerializeField] private TMP_Text _label;
		[SerializeField] private Image _icon;

		private ResourceStorage _storage;

		private void Awake() {
			_storage = _planet.Storage.GetOrCreate(_resource);
			_icon.sprite = _resource.Icon;
		}

		private void UpdateLabel(ResourceStorage storage) {
			_label.text = string.Format(_pattern, storage.Value, storage.Capacity, storage.Resource.Id);
		}

		private void OnEnable() {
			_storage.Changed += UpdateLabel;
		}
		private void OnDisable() {
			_storage.Changed -= UpdateLabel;
		}
	}
}