using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class yGroup : MonoBehaviour 
{
	public int max;	//Total number of Yackers allowed inside
	List<Yacker> contents = new List<Yacker>();
	public bool full = false;	//True when the max is reached

	void OnTriggerEnter2D(Collider2D other)
	{
		if(!full && other.tag == "Yacker")
		{
			Yacker y = other.GetComponent<Yacker>();
			
			if(!(contents.Contains(y)))
			{
				contents.Add(y);
				if(size() >= max)
				{
					full = true;
				}
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Yacker")
		{
			Yacker y = other.GetComponent<Yacker>();
			if(contents.Contains(y))
			{
				contents.Remove(y);
				full = false;
			}
		}
	}
	
	public int size()
	{
		return contents.Count;
	}
	
	//Returns the prop number if the Yackers do match. if not, it returns props;
	public int isMatch(int props)	//Props = number of properties the Yackers possess
	{
		if(full)
		{
			int x = 0;	//The number of the properties Ex: body = 0
			bool doMatch = false;
			while(x < props && !doMatch)
			{
				doMatch = true;
				for(int y = 1; y < max; y++)	//Goes through all of the collected Yackers
				{	//Since full = true, contents[max - 1] != null
					doMatch = doMatch && (contents[y].properties[x] == contents[y-1].properties[x]);	//compares the Yacker to the one before it
				}
				if(!doMatch)
				{
					x++;
				}
				//If the loop does not find a match, doMatch = false and will recheck
			}
			return x;
		}
		else
		{
			return props;
		}
	}
	
	public void sendHome()
	{
		foreach(Yacker y in contents)
		{
			y.GetComponent<Draggable>().goHome();
		}
		contents.Clear();
		full = false;
	}
}
