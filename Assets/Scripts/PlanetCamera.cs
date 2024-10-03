using System;
using UnityEngine;

namespace Game {
	public class PlanetCamera: MonoBehaviour {
		[Range(0, 360)]
		[SerializeField] private float _angle = 0;
		[Min(0)]
		[SerializeField] private float _radius = 10;
		[SerializeField] private float _zOffset = -10;
		[Space]
		[SerializeField] private Transform _planet;
		[SerializeField] private Camera _camera;

		public float Angle => _angle;

		public void SetAngle(float angle) {
			_angle = angle % 360;
			var position = _planet.position + Quaternion.Euler(0, 0, _angle) * Vector2.up * _radius;
			_camera.transform.position = position + Vector3.forward * _zOffset;
			_camera.transform.rotation = Quaternion.Euler(0, 0, _angle);
		}

		private void OnValidate() {
			if (Application.isPlaying) {
				SetAngle(_angle);
			}
		}
	}
}