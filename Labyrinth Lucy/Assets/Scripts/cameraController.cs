using UnityEngine;

public class cameraController : MonoBehaviour {

	public float Sensitivity = 10.0f;
	public Transform Player;
	public float Offset = 2;
	public Vector2 pitchMinMax = new Vector2(-40, 85);

	public float rotationSmoothTime = 0.12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRoatation;

	float yaw;
	float pitch;

	void LateUpdate()
	{
		yaw += Input.GetAxis("Mouse X") * Sensitivity;
		pitch -= Input.GetAxis("Mouse Y") * Sensitivity;
		pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

		currentRoatation = Vector3.SmoothDamp(currentRoatation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRoatation;

		transform.position = Player.position - transform.forward * Offset;
	}

}
