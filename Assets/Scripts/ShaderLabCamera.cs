using UnityEngine;

public class ShaderLabCamera : MonoBehaviour
{
	private float _radius;
	private float _theta;
	private float _phi;

	public Material Shader;

	private void Start()
	{
		Vector3 position = transform.position;
		_radius = Mathf.Sqrt(position.x * position.x + position.y * position.y + position.z * position.z);
		_theta = Mathf.Atan2(position.z, position.x);
		_phi = Mathf.Atan2(Mathf.Sqrt(position.z * position.z + position.x * position.x), position.y);
	}

	private void LateUpdate()
	{
		_radius += Input.GetAxisRaw("Jump") * Time.deltaTime;
		_theta += Input.GetAxisRaw("Horizontal") * Time.deltaTime;
		_phi += Input.GetAxisRaw("Vertical") * Time.deltaTime;

		transform.position = new Vector3(
			_radius * Mathf.Cos(_phi) * Mathf.Cos(_theta),
			_radius * Mathf.Sin(_phi),
			_radius * Mathf.Cos(_phi) * Mathf.Sin(_theta)
		);
		transform.rotation = Quaternion.LookRotation(-transform.position);
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, Shader);
	}
}