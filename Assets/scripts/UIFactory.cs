using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//The Factory is called when a Yacker of the preset type needs to be spawned on the grid
//It also fills the grid with Yackers
public class UIFactory : MonoBehaviour 
{
	public static UIFactory instance;
	YackerType type;	//Reference to the YackerType Singleton for simplicity
	public GameObject yacker;
	
	public bool fillGrid;
	Transform[,] locations;
	
	void Start () 
	{
		instance = this;
		type = YackerType.values;
		if(fillGrid)
		{
			//Create Yackers at all six locations
			for(int x = 0; x < UIGrid.get().rows; x++)
			{
				for(int y = 0; y < UIGrid.get().cols; y++)
				{
					createAt(x,y);
					Debug.Log(x + ", " + y);
				}
			}
		}
	}
	
	public static UIFactory get() { return instance; }
	
	//Makes a random Yacker at the given location
	public void createAt(int x, int y)
	{
		GameObject goYacker = Instantiate(yacker) as GameObject;
		Yacker yack = goYacker.GetComponent<Yacker>();
		
		int val0 = Random.Range (0,4); // Body
		int val1 = Random.Range (0,4); // Body Color
		int val2 = Random.Range (0,4); // Pattern
		int val3 = Random.Range (0,4); // Outline Color
		int val4 = Random.Range (0,4); // Part 1
		int val5 = Random.Range (0,4); // Part 2
		
		yack.setLoc(x, y);
		yack.setSprites(type.bodies[val0], type.bColors[val1], type.patterns[val2], type.outlines[val0],  type.oColors[val3], type.parts1[val4], type.parts2[val5]);
		yack.setProps(val0, val1, val2, val3, val4, val5);
		
		//Parents the Yacker to the grid
		goYacker.transform.SetParent(UIGrid.get().gameObject.transform);
		UIGrid.get().setYacker(x, y, yack);
	}
	
	//Makes a Yacker at a given location and sets its values
	public Yacker createAt(int x, int y, int val0, int val1, int val2, int val3, int val4, int val5)
	{
		GameObject goYacker = (GameObject)Instantiate(yacker, Grid.get().getPosition(x,y).position, yacker.transform.rotation);
		Yacker yack = goYacker.GetComponent<Yacker>();
		
		yack.setLoc(x, y);
		yack.setSprites(type.bodies[val0], type.bColors[val1], type.patterns[val2], type.outlines[val0],  type.oColors[val3], type.parts1[val4], type.parts2[val5]);
		yack.setProps(val0, val1, val2, val3, val4, val5);
		
		//Parents the Yacker to the grid
		goYacker.transform.parent = UIGrid.get().getPosition(x,y);
		Grid.get().setYacker(x, y, yack);
		return yack;
	}
}
