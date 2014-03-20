using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

	public Vector3[,] grid;
	private GameObject[,] gameObjectGrid;
	public Object marker;

	public Vector3[] samplePath;

	// Use this for initialization
	void Start () {
		grid = new Vector3[10,10];
		gameObjectGrid = new GameObject[10,10];

		for(int i = 0; i < 10; i ++)
		{
			for(int j = 0; j < 10; j++)
			{
				grid[i,j] = new Vector3(50 + (50 * i), 0, 50 + (50*j));

				Instantiate(marker, grid[i,j], Quaternion.identity);
			}

		}

		samplePath = new Vector3[] {grid[ 4,4], grid[5,5], grid [7,5], grid[ 8, 2]};


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
