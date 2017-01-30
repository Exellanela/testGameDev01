using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	public Rigidbody2D ballRB;
//	public Player PlayerScript;
	Vector3 startPosition;
	Transform parent;

	void Start () {
		startPosition = transform.position;
		parent = transform.parent;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -4f) {
			ResetBall ();
		}
	}

	void ResetBall() {
		ballRB.isKinematic = true;
		transform.parent = parent;
		transform.position = startPosition;
	}
}
