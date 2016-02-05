using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Make a match for each category
public class YahtzeeSelector : Selector {
	List<int> remainingProps = new List<int>();
	public Image[] circles;
	
	void Start() {
		//Takes all of the different properties and put them into the list
		for(int x = 0; x < numProps; x++)
		{
			remainingProps.Add(x);
		}
		setUp();
	}
	
	public override void Select() {
		if(numYackers > 1)
		{
			if(newMatchMade())
			{
				Mascot.get().anim.Play("Correct");
				print("YUP");
				if(remainingProps.Count <= 0)
					print("YOU WIN");
			}
			else
			{
				Mascot.get().anim.Play("Wrong");
			}
			StartCoroutine(deleteYackers());
		}
	}
	
	//The match just made was the first time this category was made
	bool newMatchMade() {
		int prop = -1;	//The property that was matched
		int m = 0;
		bool newMatch = true;	//Assumes the match will be new
		while(m < numProps && newMatch)
		{
			if(matchingProps[m] == true) 	//This property matched among all of the selected Yackers
			{
				//The property has not been set yet and is not a new property
				if(prop < 0 && remainingProps.Contains(m))	
				{
					prop = m;
				}
				else	
				{
					//There is more than one matching property
					//OR the property has already been matched
					newMatch = false;
					print("WHOMP");
				}
			}
			m++;
		}
		
		//WORKS
		if(newMatch)	//Remove it after in case two props match
		{
			remainingProps.Remove(prop);
			circles[remainingProps.Count].color = Color.red;
		}	
		return newMatch;
	}
}
