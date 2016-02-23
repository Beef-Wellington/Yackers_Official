using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///Selectors are the main managers for the game
///They handle points, Yacker selection, and the rules

public class Selector : MonoBehaviour 
{
	static Selector instance;
	
	public int numProps = 6;		//Number of properties
	public bool[] matchingProps;	//Which properties are matching
	public int[] selectedProps;		//The exact properties shared among the Yackers selected
	
	public List<Yacker> yackersSelected = new List<Yacker>();
	protected int numYackers = 0;
    protected int numMatches = 0;
	int points = 0;
	
	public static Selector getInstance() {
		return instance;
	}
	
	void Start() {
		setUp();
	}
	
	public virtual void setUp() {
		instance = this;
		matchingProps = new bool[numProps];	
		selectedProps = new int[numProps];	
		numYackers = 0;
		points = 0;
	}
	
	///Adds a Yacker to the list of Yackers found
	public virtual void addYacker(Yacker y) {
		if (Player.canTouch)
		if (numYackers == 0) {	//First Yacker
			for (int x = 0; x < numProps; x++) {
				matchingProps [x] = true;
				selectedProps [x] = y.properties [x];
                TraitIndicator.get().children[x+1].color = Color.white;
            }
            numMatches = matchingProps.Length;
			yackersSelected.Add (y);
			y.GetComponent<Selectable> ().Select ();
			numYackers++;
			totalPoints ();
		} else {
			//Increase the amount of points the player will earn
			totalPoints ();
			// Sets the properties of the selector to equal the number of matching properties
			for (int x = 0; x < numProps; x++) {
				if (matchingProps [x] && selectedProps [x] != y.properties [x]) {   //Was matching prior to this new Yacker
					matchingProps [x] = false;
					selectedProps [x] = -1;
                    TraitIndicator.get().children[numMatches].color = Color.grey;
                    numMatches--;
                }
			}
				
			if (noMatches ()) { //If NONE of the properties match
				//KILL THE SELECTED AND START AGAIN
				StartCoroutine (deleteYackers ());
				y.GetComponent<Selectable> ().Deselect ();
			} else {																	//Adds it
				yackersSelected.Add (y);
				y.GetComponent<Selectable> ().Select ();
				numYackers++;
			}
		}
	}

	///Checks to see if any of the values in the matchingProperty array is false
	///An element of the array will be false if the last yacker selected did not match in that property
	public virtual bool noMatches() {
		for(int x = 0; x < matchingProps.Length; x++)
		{
			if(matchingProps[x])													//There was a match
			{
				return false;
			}
		}
		return true;
	}
	
	///As in total up the points
	public virtual void totalPoints() {
		int multiplier = 0;															//How many categories match
		for(int x = 0; x < numProps; x++)
		{
			if(selectedProps[x] >= 0)
			{
				multiplier++;
			}
		}
		
		points = (multiplier * 2) * numYackers;										//Score is 2 point per matching category per Yacker
		//points *= 100;	
	}
	
	///Methods for simply adding to the point total
	public virtual void givePoints() {
		Player.addPoints(points);
	}
	public virtual void givePoints(int p) {
		Player.addPoints(p);
	}
	
	///Called by the UI button
	public virtual void Select() {
		//Debug.Log (numYackers);
        if (numYackers > 1)
			StartCoroutine(deleteYackers());
	}
	
	///Deletes the Yackers selected in order
	public virtual IEnumerator deleteYackers() {
		Player.canTouch = false;                                                    //Can't touch during the deletion process!
        while(numMatches > 0){
            TraitIndicator.get().children[numMatches].color = Color.grey;
            numMatches--;
        }
        int pointAmount = points/numYackers;
		while(numYackers > 0) 														//Destroys the previously selected Yackers and resets numYackers
		{
			givePoints(pointAmount * 100);//Score is in multiples of 100			//Adds points
			numYackers--;
	
			//Get the old location
		//	int x = yackersSelected[numYackers].x;
		//	int y =yackersSelected[numYackers].y;

		//	Destroy(yackersSelected[numYackers].gameObject);						//Remove that Yacker
			hideImg(yackersSelected[numYackers].body);								//hide the Yacker without disabling it
			hideImg(yackersSelected[numYackers].outline);
			hideImg(yackersSelected[numYackers].part1);
			hideImg(yackersSelected[numYackers].part2);
			yackersSelected[numYackers].body.rectTransform.sizeDelta = Vector2.zero;
            yield return new WaitForSeconds(.15f);					

		//	Factory.get().createAt(x, y); 											//Put a yacker at that location
			Factory.get().shuffle(yackersSelected[numYackers].gameObject); 			//re-shuffle the traits of this yacker
			yackersSelected[numYackers] = null;										//remove this yacker from selected list
			//yield return new WaitForSeconds(.05f);
		}
		yackersSelected.Clear();
		points = 0;
		Player.canTouch = true;														//Go do stuff again
	}

	private void hideImg(Image i){
		i.sprite = null;
		i.color = Color.clear;
	}
	
}
