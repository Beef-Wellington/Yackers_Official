using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class classicPreset : MonoBehaviour 
{
	//This is the predetermined set of 16 Yackers
	//It randomizes the locations
	
	public GameObject grid;
	string[] possibleYackers = new string[16];	//The sixteen presets in order
	Transform[,] locations = new Transform[4,4];
	string[,] yackers = new string[4,4];		//Yackers in grid order 
	static Yacker[,] yackerObjects = new Yacker[4,4];
	
	// Use this for initialization
	void Start () 
	{
		possibleYackers[0] = "111121";
		possibleYackers[1] = "131221";
		possibleYackers[2] = "122312";
		possibleYackers[3] = "113113";
		possibleYackers[4] = "224124";
		possibleYackers[5] = "214432";
		possibleYackers[6] = "231414";
		possibleYackers[7] = "243334";
		possibleYackers[8] = "332132";
		possibleYackers[9] = "342423";
		possibleYackers[10] = "343341";
		possibleYackers[11] = "321234";
		possibleYackers[12] = "434343";
		possibleYackers[13] = "412243";
		possibleYackers[14] = "423441";
		possibleYackers[15] = "444212";
		
		//Puts the Yackers in place
		int setYackers = 0;	
 		
		while(setYackers < 16)
		{
			int row = Random.Range(0,4);
			int col = Random.Range(0,4);
			if(yackers[row, col] == null)
			{
				yackers[row,col] = possibleYackers[setYackers];
				setYackers++;
			}
		}

		//Puts the yackers into the grid
		for(int x = 0; x < 4; x++)
		{
			for(int y = 0; y < 4; y++)
			{
				locations[x,y] = grid.transform.FindChild(x + " - " + y);
				string props = yackers[x,y];
				int val0 = (int)(props[0]) - 49; // Body
				int val1 = (int)(props[1]) - 49; // Body Color
				int val2 = (int)(props[2]) - 49; // Pattern
				int val3 = (int)(props[3]) - 49; // Outline Color
				int val4 = (int)(props[4]) - 49; // Part 1
				int val5 = (int)(props[5]) - 49; // Part 2

				yackerObjects[x,y] = Factory.get().createAt(x, y, val0, val1, val2, val3, val4, val5);
			}
		}
		
		groupChecker.getYackers(yackerObjects);
	}
}
