using UnityEngine;
using UnityEngine.InputSystem;

namespace Game {
	public class PlanetCameraTestInput: MonoBehaviour {
		[SerializeField] private float _speed = 20;
		[SerializeField] private PlanetCamera _camera;
		[SerializeField] private InputAction _rotationAxis;

		private void Awake() {
			_rotationAxis.Enable();
		}
		private void Update() {
			var input = _rotationAxis.ReadValue<float>() * -_speed * Time.deltaTime;
			_camera.SetAngle(_camera.Angle + input);
		}
	}
}