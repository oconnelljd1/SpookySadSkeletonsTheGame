﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;

	[System.Serializable]
	public class PositionSettings
	{
		public Vector3 targetPosOffset = new Vector3(0, 2f, 0);
		public float lookSmooth = 100f;
		public float distanceFromTarget = -8;
		public float zoomSmooth = 100;
		public float maxZoom = -6;
		public float minZoom = -9;
		public bool smoothFollow = true;
		public float smooth = 0.05f;
	
		[HideInInspector]
		public float newDistance = -6; // set by zoom input
		[HideInInspector]
		public float adjustmentDistance = -6;

	}
		
	[System.Serializable]
	public class OrbitSettings
	{
		public float xRotation = -20;
		public float yRotation = -180;
		public float maxXRotation = 25;
		public float minXRotation = -85;
		// determines how smooth the x and y rotations will be
		public float vOrbitSmooth = 150;
		public float hOrbitSmooth = 150;
	}

	[System.Serializable]
	public class InputSettings
	{
		public string MOUSE_ORBIT = "MouseOrbit";
		public string MOUSE_ORBIT_VERTICAL = "MouseOrbitVertical";
		public string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
		public string ORBIT_HORIZONTAL = "OrbitHorizontal";
		public string ORBIT_VERTICAL = "OrbitVertical";
		public string ZOOM = "Mouse ScrollWheel";
	}

	[System.Serializable]
	public class DebugSettings
	{
		public bool drawDesiredCollisionLines = true;
		public bool drawAdjustedCollisionLines = true;
	}


	public PositionSettings position = new PositionSettings();
	public OrbitSettings orbit = new OrbitSettings ();
	public InputSettings input = new InputSettings ();
	public DebugSettings debug = new DebugSettings ();
	public CollisionHandler collision = new CollisionHandler ();

	Vector3 targetPos = Vector3.zero;
	Vector3 destination = Vector3.zero;
	Vector3 adjustedDestination = Vector3.zero;
	Vector3 camVel = Vector3.zero;
	CharacterController charController;
	float vOrbitInput, hOrbitInput, zoomInput, hOrbitSnapInput,  mouseOrbitInput, vMouseOrbitInput;
	Vector3 previousMousePos = Vector3.zero;
	Vector3 currentMousePos = Vector3.zero;


	void Start()
	{
		SetCamerTarget (target);

		vOrbitInput = hOrbitInput = zoomInput = hOrbitInput = mouseOrbitInput = vMouseOrbitInput = 0;

		MoveToTarget ();

		collision.Initalize (Camera.main);
		collision.UpdateCameraClipPoints (transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
		collision.UpdateCameraClipPoints (destination, transform.rotation, ref collision.desiredCameraClipPoints);
		transform.position = destination;
	}

	public void SetCamerTarget(Transform t)
	{
		target = t;

		if (target != null)
		{
			if (target.GetComponent<CharacterController> ()) {
				charController = target.GetComponent<CharacterController> ();
			} else
				Debug.LogError ("The Camera's Target needs a character controller.");
		}
		else
			Debug.LogError("Your Camera Needs A target.");
	}

	void GetInput()
	{
		vOrbitInput = Input.GetAxis (input.ORBIT_VERTICAL);
		hOrbitInput = Input.GetAxis (input.ORBIT_HORIZONTAL);
		hOrbitSnapInput = Input.GetAxisRaw (input.ORBIT_HORIZONTAL_SNAP);
		zoomInput = Input.GetAxisRaw (input.ZOOM);
	}

	void Update()
	{
		GetInput ();
		OrbitTarget ();
		ZoomInOnTarget ();
	}


	// occurs after the update is called
	void FixedUpdate()
	{
		// moving
		MoveToTarget();
		// rotating
		LookAtTarget();
		//player input orbit
		OrbitTarget();
		//MouseOrbitTarget();

		collision.UpdateCameraClipPoints (transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
		collision.UpdateCameraClipPoints (destination, transform.rotation, ref collision.desiredCameraClipPoints);

		// draw debug lines
		for (int i = 0; i < 5; i++)
		{
			if (debug.drawDesiredCollisionLines)
			{
				Debug.DrawLine(targetPos, collision.desiredCameraClipPoints[i],Color.white);
			}
			if (debug.drawAdjustedCollisionLines)
			{
				Debug.DrawLine(targetPos, collision.adjustedCameraClipPoints[i],Color.green);
			}
		}
		collision.CheckColliding (targetPos);//using raycasts here
		position.adjustmentDistance = collision.GetAdjustedDistanceWithRayFrom(targetPos);
	}

	void MoveToTarget()
	{
		targetPos = target.position + position.targetPosOffset;
		destination = Quaternion.Euler (orbit.xRotation, orbit.yRotation + target.eulerAngles.y, 0) * -Vector3.forward * position.distanceFromTarget;
		destination += target.position;

		if (collision.colliding) {
			adjustedDestination = Quaternion.Euler (orbit.xRotation, orbit.yRotation + target.eulerAngles.y, 0) * Vector3.forward * position.adjustmentDistance;
			adjustedDestination += targetPos;

			if (position.smoothFollow) {
				//use smooth damp function
				transform.position = Vector3.SmoothDamp(transform.position, adjustedDestination, ref camVel, position.smooth);
			}
			else
			{
				transform.position = adjustedDestination;
			}
		}
		else
		{
			if (position.smoothFollow) {
				//use smooth damp function
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVel, position.smooth);
			}
			else
			{
				transform.position = destination;
			}
		}
	}

	void LookAtTarget()
	{
		Quaternion targetRoation = Quaternion.LookRotation (targetPos - transform.position);
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRoation, position.lookSmooth * Time.deltaTime);
	}

	void OrbitTarget()
	{
		if (hOrbitSnapInput > 0) 
		{
			orbit.yRotation = -180;
		}

		orbit.xRotation += vOrbitInput * orbit.vOrbitSmooth * Time.deltaTime;
		orbit.yRotation += hOrbitInput * orbit.hOrbitSmooth * Time.deltaTime;

		if (orbit.xRotation > orbit.maxXRotation)
		{
			orbit.xRotation = orbit.maxXRotation;
		}
		if (orbit.xRotation < orbit.minXRotation)
		{
			orbit.xRotation = orbit.minXRotation;
		}

	}

	void ZoomInOnTarget()
	{
		position.distanceFromTarget += zoomInput * position.zoomSmooth * Time.deltaTime;

		if (position.distanceFromTarget > position.maxZoom) 
		{
			position.distanceFromTarget = position.maxZoom;
		}
		if (position.distanceFromTarget < position.minZoom) 
		{
			position.distanceFromTarget = position.minZoom;
		}
	}

	[System.Serializable]
	public class CollisionHandler
	{
		public LayerMask collisonLayer;

		[HideInInspector]
		public bool colliding = false;
		[HideInInspector]
		public Vector3[] adjustedCameraClipPoints;//Surounds the camera's current postion
		[HideInInspector]
		public Vector3[] desiredCameraClipPoints;//clip points that surround the camera's expected positions if not colliding with anything

		Camera camera;

		public void Initalize(Camera cam)
		{
			camera = cam;
			adjustedCameraClipPoints = new Vector3[5];//the 4 clip points and where the camera is.
			desiredCameraClipPoints = new Vector3[5];
		}

		public void UpdateCameraClipPoints(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] intoArray)
		{
			if (!camera)
				return;
			// clear the contents sof into array
			intoArray = new Vector3[5];

			float z = camera.nearClipPlane;
			float x = Mathf.Tan (camera.fieldOfView / 3.41f) * z; // size of the collision space
			float y = x /camera.aspect;

			// find the clip points for each part the the array

			// top left
			intoArray[0] = (atRotation * new Vector3(-x,y,z)) + cameraPosition; // we added and rotated the point relative to the camera
			// top rigt
			intoArray[1] = (atRotation * new Vector3(x,y,z)) + cameraPosition; // we added and rotated the point relative to the camera
			// bottom left
			intoArray[2] = (atRotation * new Vector3(-x,-y,z)) + cameraPosition; // we added and rotated the point relative to the camera
			// bottom right
			intoArray[3] = (atRotation * new Vector3(x,-y,z)) + cameraPosition; // we added and rotated the point relative to the camera
			// camera's postion
			intoArray[4] = cameraPosition - camera.transform.forward;
		}

		bool CollisionDetectedAtClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
		{
			for (int i = 0; i < clipPoints.Length; i++)
			{
				Ray ray = new Ray(fromPosition, clipPoints[i] - fromPosition);
				float distance = Vector3.Distance(clipPoints[i], fromPosition);
				if(Physics.Raycast(ray, distance, collisonLayer))
				{
					return true;
				}
			}
			return false;
		}


		public float GetAdjustedDistanceWithRayFrom(Vector3 from)
		{
			float distance = -1;
			for (int i = 0; i < desiredCameraClipPoints.Length; i++) 
			{
				Ray ray = new Ray(from, desiredCameraClipPoints[i] - from);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) 
				{
					if (distance == -1)
						distance = hit.distance;
					else 
					{
						if (hit.distance < distance)
							distance = hit.distance;
					}
				}
			}
			if (distance == -1)
				return 0;
			else
				return distance;
		}
		public void CheckColliding(Vector3 targetPosition)
		{
			if (CollisionDetectedAtClipPoints (desiredCameraClipPoints, targetPosition)) {
				colliding = true;
			} 
			else 
			{
				colliding = false;	
			}
		}
	}
}
