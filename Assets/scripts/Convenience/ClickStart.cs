using UnityEngine;
using System.Collections;
/*
	When an object with this script is clicked/tapped, the game will begin
*/
public class ClickStart : MonoBehaviour {
	public ClickStart next;			//If next is set, another ClickStart object will appear when this one is destroy

	void Start() {
        Debug.Log("clicker is online");
		Player.canTouch = false;	//If this object is in the scene, 
									//the Player, logically,  will not be allowed to touch while it is still up
	}
	
	public void proceedText() {
		print("YUP");
		if(next == null)	//End of the dialogue, start the game!
			Invoke("kill", .1f);		
		else				//There is more dialogue, turn the next object on!
		{
			next.gameObject.SetActive(true);
			Destroy(gameObject);
		}
	}
	
	void kill() { //This is invoked to prevent the player from selecting the object behind the ClickStart
		Player.canTouch = true;
        TimeBar.getInstance().startTimer();
		Destroy(gameObject);
	}
}
