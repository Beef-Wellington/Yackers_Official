using UnityEngine;
using System.Collections;

/* 
	Selector for the game mode where the desired property changes randomly
	
*/
public class SwitchSelector : Selector {
	int currentCat = -1;	//The current category being looked for
	
	int timesSince;	//Amount of correct finds since the category changed
	int minTimes = 5;	int maxTimes = 8;	//Threshold of times before the category switches
	int limit = 0;		//Will be a number from min to max
	
	public ClickStart hint;		//Appears on the first switch
	public int numChanges = 0;	//How long until you display the hint
	
	void Start() {
		changeMind();
		setUp();
	}
	
	public override void Select() {
		if(numYackers > 2)	//Has to be greater than 2 to ensure the match!
		{
			if(matchingProps[currentCat])	//The chosen category was found
			{
				correctMatch();
			}
			else
			{
				Mascot.get().Play("Wrong");
			}
			StartCoroutine(deleteYackers());
		}
	}
	
	//What happens when the player submits Yackers of the correct category
	void correctMatch() {
		timesSince++;
		Mascot.get().Play("Correct");
		if(timesSince >= limit)
		{
			changeMind();
		}
	}
	
	//Method that handles the category switch
	void changeMind() {
		numChanges++;
		print(numChanges);
		if(numChanges == 2)	//It is 2 because the hint count is incremented once at start
		{
			//Displays a hint
			Instantiate(hint.gameObject, Camera.main.transform.position + new Vector3(0,0,20), Quaternion.identity);
		}
		int tempCat = currentCat;	//Have to make sure the new category is not the same
		while(tempCat == currentCat)
			currentCat = Random.Range(0, numProps);		//New category
		limit = Random.Range(minTimes, maxTimes+1);	//New limit
		timesSince = 0;
	}
}
