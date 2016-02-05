using UnityEngine;
using System.Collections;

/*
	Used in the Classic Yackers mode. The Yackers are dragged into one of the four groups
	and "grouped" together by one of their properties
*/

public class groupChecker : MonoBehaviour 
{
	public int numProps;	//The number of properties the Yackers will have
	int[] foundProps;
	int propsFound = 0;	// from 0 to numProps, increments when a property is found
	public yGroup[] groups;
	static Yacker[,] allYackers = new Yacker[4,4];
	bool checking = false;	//Prevents players from checking the groups twice
	
	void Start()
	{
		foundProps = new int[numProps];
	}
	
	void OnGUI()
	{
		GUILayout.BeginVertical();
			GUILayout.Label("PRESS B TO CHECK THE GROUPS");
			GUILayout.Label("NORTH: " + groups[0].size().ToString());
			GUILayout.Label("SOUTH: " + groups[1].size().ToString());
			GUILayout.Label("EAST: " + groups[2].size().ToString());
			GUILayout.Label("WEST: " + groups[3].size().ToString());
			GUILayout.Label("Matches found: " + propsFound.ToString());
		GUILayout.EndVertical();
	}
	
	void Update()
	{
		if(Input.GetKeyDown("b") && !checking)
		{
			checking = true;
			check();
		}
	}
	
	public static void getYackers(Yacker[,] y)
	{
		allYackers = y;
	}
	
	void check()
	{
		int matchingProp = groups[0].isMatch(numProps);
		if(matchingProp < numProps)
		{	
			bool gMatch = true;	//The groups match
			for(int y = 1; y < groups.Length; y++)
			{	
				gMatch = gMatch && (groups[y].isMatch(numProps) == groups[y-1].isMatch(numProps));
			}
			if(gMatch)
			{
				foundProps[matchingProp]++;
				if(foundProps[matchingProp] == 1)
				{
					print("FOUND NEW MATCH");
					propsFound++;
				}
				else
				{
					print("MATCH ALREADY FOUND");
				}
			}
			else
			{
				print("There is a problem with the groups");
			}
		}
		//Return the Yackers to their original positions
		foreach(Yacker y in allYackers)
		{
			y.GetComponent<Draggable>().goHome();
		}
		checking = false;
	}
}
