using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {
	//bool selectable = true;	//Used in the case of pausing or another scenario where the Player cannot select things 
	bool selected = false;	//True when a player selects the Yacker
	float sizeScale = .2f;	//How much bigger the Yacker gets when selected
	Yacker yacker;
	
	void Start() {
		yacker = GetComponent<Yacker>();
	}
	
	void OnMouseDown()
	{
		if(!selected && Player.canTouch)	//You CANNOT deselect a Yacker
		{
			Select();
			Selector.getInstance().addYacker(yacker);		//Starts the comparison process
		}
	}

	public void Select() {
		selected = true;
		//yacker.changeSize (150);
		//transform.localScale *= (1f + sizeScale);
	}
	public void Deselect()	//Used by the Selector to unTouch a Yacker after a mistake has been made
	{
		selected = false;
		yacker.changeSize (100);
		//transform.localScale /= (1f + sizeScale);
	}
}
