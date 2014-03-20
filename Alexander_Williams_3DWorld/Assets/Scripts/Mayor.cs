using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]

public class Mayor : MonoBehaviour {
	
	

	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.eulerAngles = new Vector3(0.0f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
	}
}
