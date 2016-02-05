using UnityEngine;
using System.Collections;

public class createGrid : MonoBehaviour 
{
	Vector3 startingPoint;
	public int rows, columns;
	public GameObject space;	//Box of the sprite's size
	Vector3 spaceSize; 	//How large each sprite would be
	Transform[,] grid;
	Vector3 size;

	// Use this for initialization
	void Start () 
	{
		startingPoint = this.transform.position;
		grid = new Transform[rows,columns];
		size = space.GetComponent<Renderer>().bounds.size;
		makeGrid();
		sendGrid();
	}
	
	void makeGrid()
	{
		float width = size.x;
		float height = size.y;
		for(int r = 0; r < rows; r++)
		{
			for(int c = 0; c < columns; c++)
			{
				Vector3 location = startingPoint + new Vector3(width*r, height*c, 0);
				GameObject newSpace = Instantiate(space, location, Quaternion.identity) as GameObject;
				newSpace.transform.parent = this.transform;
				grid[r,c] = newSpace.transform;
			}
		}
	}
	
	void sendGrid()
	{
		//GameObject.FindGameObjectWithTag("Creator").GetComponent<produceYacker>().fillGrid(grid, rows, columns);
	}
}
