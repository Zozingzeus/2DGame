using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool grounded;
	public GameObject groundCheck;
	public float groundRadius = 1f;
	public LayerMask whatIsGround;
	public bool doubleJump;
	public float jumpForce = 150f;
	public AudioClip leftFootSound;
	public AudioClip rightFootSound;

	private Rigidbody2D rigidbody2D;
	private Animator animator;
	private PlayerController controller;
	
	void Start(){
		rigidbody2D = GetComponent<Rigidbody2D>();
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	
	void PlayLeftFootSound(){
		if (leftFootSound)
			AudioSource.PlayClipAtPoint (leftFootSound, transform.position);
	}
	
	void PlayRightFootSound(){
		if (rightFootSound)
			AudioSource.PlayClipAtPoint (rightFootSound, transform.position);
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		var forceX = 0f;
		var forceY = 0f;
		
		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);

		grounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround);
		Debug.DrawLine(groundCheck.transform.position, new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y- 1f));

		if(grounded && controller.jumping) {
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}


		if (controller.moving.x != 0) {
			if (absVelX < maxVelocity.x) {
				
				forceX = speed * controller.moving.x;
				
				transform.localScale = new Vector3 (forceX > 0 ? -1 : 1, 1, 1);
			}
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger ("AnimState", 0);
		}

		rigidbody2D.AddForce (new Vector2 (forceX, forceY));
	}
}
