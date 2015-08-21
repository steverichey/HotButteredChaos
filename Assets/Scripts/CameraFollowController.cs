using UnityEngine;
using System.Collections;

public class CameraFollowController : MonoBehaviour {
	public Camera followCamera;
	public Vector3 distance;
	
	void Update () {
		followCamera.transform.position = transform.position + distance;
	}
}
