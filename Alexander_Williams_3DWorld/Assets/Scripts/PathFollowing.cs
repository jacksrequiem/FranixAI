using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Steering))]

public class PathFollowing : MonoBehaviour {

	public GameObject marker;

	private CharacterController characterController;
	private Steering steering;
	private GameManager gameManager;


	private int targetNode;



	//movement variables
	private float gravity = 200.0f;
	private Vector3 moveDirection;
	
	//steering variable
	private Vector3 steeringForce;

	// Use this for initialization
	void Start () {

		characterController = gameObject.GetComponent<CharacterController> ();
		steering = gameObject.GetComponent<Steering> ();

		targetNode = 0;




	
	}
	
	// Update is called once per frame
	void Update () {
		gameManager = GameManager.Instance;
		CalcSteeringForce ();
		ClampSteering ();
		
		moveDirection = transform.forward * steering.Speed;
		// movedirection equals velocity
		//add acceleration
		moveDirection += steeringForce * Time.deltaTime;
		//update speed
		steering.Speed = moveDirection.magnitude;
		
		//area of fix
		if (steering.Speed != moveDirection.magnitude) {
			moveDirection = moveDirection.normalized * steering.Speed;
		}
		
		//orient transform
		if (moveDirection != Vector3.zero)
			transform.forward = moveDirection;
		
		// Apply gravity
		moveDirection.y -= gravity;
		
		// the CharacterController moves us subject to physical constraints
		characterController.Move (moveDirection * Time.deltaTime);

	
	}




	private void CalcSteeringForce ()
	{
		steeringForce = Vector3.zero;
	
		int maxPath = 4;
		float tarDist = Vector3.Distance(this.transform.position, gameManager.samplePath[targetNode]);
		print (targetNode);
		print(tarDist);
		if (tarDist < 30) {
			if(targetNode < maxPath - 1 && gameManager.samplePath.Count < maxPath) {
				print("Adding new path node");
				gameManager.samplePath.Add(gameManager.grid[(int)Random.Range(0, 9), (int)Random.Range(0, 9)]);
				targetNode++;
			} else if(targetNode < maxPath - 1) {
				targetNode++;
			} else {
				print("Starting from the beginning");
				targetNode = 0;
			}
		}


		steeringForce = 5 * steering.Pursuit(gameManager.samplePath[targetNode]);



	}
	
	private void ClampSteering ()
	{
		if (steeringForce.magnitude > steering.maxForce) {
			steeringForce.Normalize ();
			steeringForce *= steering.maxForce;
		}
	}



}
