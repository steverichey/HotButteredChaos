using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 6;
	public float jumpHeight = 12;

	private Vector3 velocity;
	private Rigidbody playerRigidbody;

	void Awake() {
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		float up = 0;

		if (Input.GetKeyDown (KeyCode.Space)) {
			up = jumpHeight;
		}

		velocity.Set (h, up, v);
		velocity = velocity * speed * Time.deltaTime;
		playerRigidbody.position += velocity;
	}
}
