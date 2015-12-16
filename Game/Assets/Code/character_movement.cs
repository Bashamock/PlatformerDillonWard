using UnityEngine;

public class character_movement : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;


	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	public Transform wallCheckLeft;
	public Transform wallCheckRight;

	public float wallCheckRadiusLeft;
	public float wallCheckRadiusRight;

	public LayerMask whatIsWall;

	private bool wallSliding;
	private bool doubleJump;

	

	void Start () {

	}// start

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		wallSliding = Physics2D.OverlapCircle (wallCheckLeft.position, wallCheckRadiusLeft, whatIsWall); //check wall left hand
		wallSliding = Physics2D.OverlapCircle (wallCheckRight.position, wallCheckRadiusRight, whatIsWall); //check wall right hand

	}//Fixed Update




	void Update () {

		if (grounded) {
			doubleJump = false;
		}

		if(Input.GetKeyDown(KeyCode.Space)&& grounded){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}// if jump


		if (wallSliding) {
			doubleJump = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, -1);
		}

		if(Input.GetKeyDown(KeyCode.Space)&& wallSliding){
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}// if jump


		if (Input.GetKeyDown (KeyCode.Space) && !doubleJump && !grounded) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			doubleJump = true;
		}//if  double jump


		if(Input.GetKey(KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}// if press D
		
		if(Input.GetKey(KeyCode.A)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}// if press A

	}// update

} //main