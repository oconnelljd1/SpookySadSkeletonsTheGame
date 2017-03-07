Fwausing UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	// How you make a class in C#
	[System.Serializable]
	public class MoveSettings
	{
		public float forwardVel = 6;
		public float rotateVel = 110;
		public float jumpVel = 10;
		public float distToGrounded = 0.2f;
		public LayerMask ground;
	}

	[System.Serializable]
	public class PhysSettings
	{
		public float downAccel = 0.75f;
	}


	[System.Serializable]
	public class InputSettings
	{
		// not needed but can be nice (input delay of 0.1 seconds)
		public float inputDelay = 0.1f;
		public string FORWARD_AXIS = "Vertical";
		public string TURN_AXIS = "Horizontal";
		public string JUMP_AXIS = "Jump";
		public string CROUCH_BUTTON = "Crouch";
		public string CRAWL_BUTTON = "Crawl";

	}
	// so the classes can be seen and modifed from the inspector
	public MoveSettings moveSetting = new MoveSettings();
	public PhysSettings physSetting = new PhysSettings();
	public InputSettings inputSetting = new InputSettings();
	Vector3 velocity = Vector3.zero;
	// holds the next roation that we try to turn to.
	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput, jumpInput, crouchInput, crawlInput;
	Animator playerAnim;
	public GameObject playerObj;
	public CapsuleCollider standingCollider;
	public CapsuleCollider crouchingCollider;
	public CapsuleCollider crawlingCollider;

	public Quaternion TargetRotation
	{
		get {return targetRotation;}
	}


	bool Grounded()
	{
		return Physics.Raycast (transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
	}

	public GameObject pauseScriptHolder;
	private PauseScript pauseScript;

	void Awake()
	{
		pauseScript = pauseScriptHolder.GetComponent<PauseScript> ();
	}


	// where the initalition
	void Start()
	{
		targetRotation = transform.rotation;
		//playerAnim = playerObj.GetComponent<Animator>();
		playerAnim = gameObject.GetComponent<Animator>();
		playerAnim.SetBool ("isStanding", true);
		playerAnim.SetBool ("isCrouching", false);
		playerAnim.SetBool ("isCrawling", false);
		playerAnim.SetBool ("isWalking", false);

		if (GetComponent<Rigidbody>())
			rBody = GetComponent<Rigidbody> ();
		else
			Debug.LogError("The Character Needs A rigidbody.");
		forwardInput = turnInput = jumpInput = 0;
	}

	// when get input
	void GetInput()
	{
		// to view the what we are looking at look in "Edit" in unity, and  click "Project settings" and then click "input". the list of the axis are there.
		forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS); // interpolated
		turnInput = Input.GetAxis (inputSetting.TURN_AXIS); // interpolated
		jumpInput = Input.GetAxisRaw (inputSetting.JUMP_AXIS); // non-interpolated
		crouchInput = Input.GetAxisRaw (inputSetting.CROUCH_BUTTON);
		crawlInput = Input.GetAxisRaw (inputSetting.CRAWL_BUTTON);

	}
	//on the update
	void Update()
	{
		if (pauseScript.isPaused == false) 
		{
			GetInput ();
			Turn ();
		}
	}
	// for physics
	void FixedUpdate()
	{
		if (pauseScript.isPaused == false) {
			Walk ();
			Jump ();
			Crouch ();
			Crawl ();

			rBody.velocity = transform.TransformDirection (velocity);
			//rBody.velocity = velocity;
		
		} 
	}

	void Walk()
	{
		if (Mathf.Abs (forwardInput) > inputSetting.inputDelay) 
		{// math.abs returns the absulute value of a float
			//move
			velocity.z = moveSetting.forwardVel * forwardInput;
			playerAnim.SetBool ("isWalking", true);

		} 
		else 
		{
			// if the player's input is less than the inpit delay than the player will not move
			//zero velocity
			velocity.z = 0;
			playerAnim.SetBool ("isWalking", false);
		}
	}

	void Turn()
	{
		if (Mathf.Abs (turnInput) > inputSetting.inputDelay)
			// what angle and roation do we want to move at
			targetRotation *= Quaternion.AngleAxis(moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);// we multiply because the rotaion may be pos or neg.
		transform.rotation = targetRotation;
	}
	void Jump()
	{
		if (jumpInput > 0 && Grounded ()) {
			//jump
			velocity.y = moveSetting.jumpVel;
		} 

		else if (jumpInput == 0 && Grounded ()) {
			// zero out our velocity.y
			velocity.y = 0;
		}

		else
		{
			//decrease velocity.y
			velocity.y -= physSetting.downAccel;
		}
	}
	void Crouch()
	{
		if (crouchInput > 0 && Grounded ())
		{
			playerAnim.SetBool ("isStanding", false);
			playerAnim.SetBool ("isCrouching", true);
			playerAnim.SetBool ("isCrawling", false);
			Debug.Log ("crouching " + crouchInput);
			crouchingCollider.enabled = true;
			standingCollider.enabled = false;
			crawlingCollider.enabled = false;
		} 
		else if (crouchInput < 0 && Grounded ()) 
		{
			Debug.Log ("crouching " + crouchInput);
			playerAnim.SetBool ("isStanding", true);
			playerAnim.SetBool ("isCrouching", false);
			playerAnim.SetBool ("isCrawling", false);
			Debug.Log (crouchInput);
			crouchingCollider.enabled = false;
			standingCollider.enabled = true;
			crawlingCollider.enabled = false;
		}
	}

	void Crawl()
	{
		if (crawlInput > 0 && Grounded ())
		{
			playerAnim.SetBool ("isStanding", false);
			playerAnim.SetBool ("isCrouching", false);
			playerAnim.SetBool ("isCrawling", true);
			Debug.Log (crawlInput);
			crouchingCollider.enabled = false;
			standingCollider.enabled = false;
			crawlingCollider.enabled = true;
			//moveSetting.forwardVel = moveSetting.forwardVel / 2;
		} 
		else if (crawlInput < 0 && Grounded ()) 
		{
			Debug.Log ("crawling " + crawlInput);
			playerAnim.SetBool ("isStanding", false);
			playerAnim.SetBool ("isCrouching", true);
			playerAnim.SetBool ("isCrawling", false);
			Debug.Log ("crawling " + crawlInput);
			crouchingCollider.enabled = true;
			standingCollider.enabled = false;
			crawlingCollider.enabled = false;
		}
	}
}
