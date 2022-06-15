using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target;

	private float smoothSpeed = 2f;
	private float _basicZoom = 1f;
	private float _maxZoom = 1.2f;
	private float _minZoom = .7f;
	private float _rotateSpeed = 70;
	private float _zoomSensitivity = .7f;
	private float _cameraDistantance = 8f;

	private float zoomSmoothV;
	private float _targetZoom;

	private void Start()
	{
		transform.LookAt(target);
		_targetZoom = _basicZoom;
	}

	private void Update()
	{
		// перекинуть в инпут, а здесь только обрабатывать запрос
		float _scroll = Input.GetAxisRaw("Mouse ScrollWheel") * _zoomSensitivity;

		if (_scroll != 0f)
		{
			_targetZoom = Mathf.Clamp(_targetZoom - _scroll, _minZoom, _maxZoom);
		}
		_basicZoom = Mathf.SmoothDamp(_basicZoom, _targetZoom, ref zoomSmoothV, .15f);
	}

	private void LateUpdate()
	{
		transform.position = target.position - transform.forward * _cameraDistantance * _basicZoom;
		transform.LookAt(target.position);

		float _rotateInput = Input.GetAxisRaw("Horizontal");
		transform.RotateAround(target.position, Vector3.up, -_rotateInput * _rotateSpeed * Time.deltaTime);
	}

}