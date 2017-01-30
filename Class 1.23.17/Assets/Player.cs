using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	bool jumping;
//	public bool thrown;
	public float jumpSpd;
	float curJumpvel;
	public float gravity;
	float startY;
	public Rigidbody2D ballRB;
	public Vector2 flyforce;

	public SpriteRenderer spriteRenderer;
	public Sprite playerThrow;
	public Sprite playerIdle;

	void Start () {
		startY = transform.position.y;
	}
	

	void Update () {
		dealwithinput ();
		dealwithjumping ();
	}


	void dealwithinput() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (jumping) {
				throwball();
			} else { 
				jump();
			}
		}
	}

	void jump() {
		jumping = true;
		curJumpvel = jumpSpd;
	}


	void throwball() {
//		if (!thrown) {
			ballRB.isKinematic = false;
			ballRB.transform.parent = null;
			ballRB.AddForce (flyforce, ForceMode2D.Impulse);
		spriteRenderer.sprite = playerThrow;
//		}
	}
		

	void dealwithjumping() {
		transform.position += new Vector3 (0, curJumpvel, 0);
		curJumpvel -= gravity;
		if (transform.position.y <= startY) {
			jumping = false;
			transform.position = new Vector3 (transform.position.x, startY, 0);
			spriteRenderer.sprite = playerIdle;
		}
	}
}
