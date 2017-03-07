using UnityEngine;
using System.Collections;

public class basicAI : MonoBehaviour {

	// for the player controller
	public Transform player;
	public Transform head;
	Animator anim;
	public LayerMask ground;
	//bool pursuing = false; if we wanted him to folow us aslong as he had seen us

	string state = "patrol";
	public GameObject[] waypoints; // the aray that will contain the waypoints
	int currentWP = 0; // what waypoint is currently being used
	public float rotateSpeed = 0.5f; // roation sxfffffpeed var
	public float speed = 1.5f; // movement speed var
	public float accuracyWP = 5.0f; // if we are within 5 of the waypoint, they have made it to the waypoint
	public float attackRad = 2f;
	public float chaseRad = 10.0f;
	public CapsuleCollider attackingCollider;


	public GameObject pauseScriptHolder;
	private PauseScript pauseScript;

	void Awake()
	{
		pauseScript = pauseScriptHolder.GetComponent<PauseScript> ();
	}

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();//gets the animator for the enemy
		attackingCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (pauseScript.isPaused == false) {
			//vecotr 3 named direction is the player postion - the transform position
			Vector3 direction = player.position - this.transform.position;

			direction.y = 0; // so when the player aproches the enemy they will not rotate backwards

			// vector 3  angle is the angle that the enemy can see (head.up only used if wanting the have vision that moves with head. otherwise use this.transform.forward)
			float angle = Vector3.Angle (direction, head.up);

			// for the waypoints
			if (state == "patrol" && waypoints.Length > 0) { // if the state of the ai is in partroll and we have more than 0 waypoints, execute the folowing code
				//anim.SetBool ("isIdle", false); // seting the idol off as we are going to start moving twards the next waypoint
				anim.SetBool ("isWalking", true);
				if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) { // test to see the ai position with the waypoints position, and within the accuracy WP, move it twoards the next WP
					currentWP++;// once the waypoint is reached ++ moves it to the next WP
					if (currentWP >= waypoints.Length) { // if the current waypoint is larger than or equal to the lenght of the aray set it back to zero and have the ai move twords waypoint 0 
						currentWP = 0;
					}
				}

				//rotate twords the waypoint
				direction = waypoints [currentWP].transform.position - transform.position; // what direction is the waypoint from the ai
				this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotateSpeed * Time.deltaTime);// turn the ai twords the waypoint
				this.transform.Translate (0, 0, Time.deltaTime * speed);// move twards the waypoint
			}


			// test for the distance between the player's position and the enemy. And if it is less than 10 units, then we will work out the direction from the player the player to the skeleton.
			if (Vector3.Distance (player.position, this.transform.position) < chaseRad && (angle < 30 || state == "pursuing")) { // angle < 30, if the enemy is within 10 units and 30 degrees or if the ai is set to pursuing
				state = "pursuing";
				// the transform rotation is =  a Quarternion.slerp (Spherically interpolates between a and b by t. The parameter t is clamped to the range [0, 1].)
				// will be used to rotate the enemy twords the player and the slerp is a more natural feeling rotation.
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotateSpeed * Time.deltaTime);

				//anim.SetBool ("isIdle", false);// because we want him to leave the idle when the player gets closer to the enemy
			
				if (direction.magnitude > attackRad) { // if the direction vector, has a magnitude (length) is greater than 5 it will move 0.05 in the z(forward)
					this.transform.Translate (0, 0, Time.deltaTime * speed);
					anim.SetBool ("isWalking", true);
					anim.SetBool ("isAttacking", false);
					attackingCollider.enabled = false;

				} else {
					anim.SetBool ("isAttacking", true);
					anim.SetBool ("isWalking", false);
					attackingCollider.enabled = true;
				}
			} else {
				//anim.SetBool("isIdle", true);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
				state = "patrol";
				attackingCollider.enabled = false;
				//pursuing = false;
			}
		}
	}
	// New Waypoints ();
	// var currentTransfor	m : Transform;

	//public GameObject prefab;


	//void Start()
	//{
		//for (int i = 0; i < 10; i++)
			//Instantiate(prefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
	//}


		// SAMPLE INSTANTIATION
	// var current : GameObject;
	// current = Instantiate (currentTransform, player.transform.position, player.transform.rotation)
}
