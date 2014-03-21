using UnityEngine;
using System.Collections;

//Phoenix Rodden

public class CartStates : MonoBehaviour {

	Color[] colorStates = {Color.white, Color.green, Color.red};
	string[] inputs = {"NoneClose, WerewolfClose, VillagerClose"};
	int currentState;

	public GameManager manager;

	// Use this for initialization
	void Start () {
	

		currentState = 0;

	}

	// Update is called once per frame
	void Update () {
		manager = GameManager.Instance;

		makeTransition (getInput ());

		switch (currentState) {
		case 0:
			GetComponent<MeshRenderer>().material.SetColor("_Color", colorStates[currentState]);
			break;
		case 1:
			GetComponent<MeshRenderer>().material.SetColor("_Color", colorStates[currentState]);
			break;
		case 2:
			GetComponent<MeshRenderer>().material.SetColor("_Color", colorStates[currentState]);
			break;
		default:
			break;
				}
		
	}

	string getInput()
	{

		RaycastHit hit = new RaycastHit ();;

		string obj = "nothing";

		if (Physics.SphereCast (transform.position, 20.0f, transform.forward,out hit)) {
			obj = hit.collider.gameObject.name;
		}
		switch (obj) {
				case "Werewolf":
						return inputs [1];
						break;
				case "Villager":
						return inputs [2];
						break;
				default:
						return inputs [0];
						break;
				}


	}

	void makeTransition(string input)
	{
		switch (currentState) {
				case 0:
						
						if (input == inputs [1])
								currentState = 1;
						else if (input == inputs [2])
								currentState = 2;
						else
								currentState = 0;
								
						
						break;
				case 1:
						if (input == inputs [0])
								currentState = 0;
						else if (input == inputs [2])
								currentState = 2;
						else
								currentState = 1;
			
			
						break;
				case 2:
						if (input == inputs [1])
								currentState = 1;
						else if (input == inputs [0])
								currentState = 0;
						else
								currentState = 2;
			
			
						break;
				
				default:
						currentState = 0;
						break;
				}
	}
}
