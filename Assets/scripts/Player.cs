using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* This script is the "Player"
 * It acts as a static holder of all of the different properties and states
 * that handle what the Player can and cannot do
 */ 
public class Player : MonoBehaviour 
{
	public Text scoreDisplay;
	public static int score;
	public static bool canTouch = true;	//Used to prevent the player from touching things during pauses
	void Start () 
	{
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		scoreDisplay.text = score.ToString();
	}
	
	public static void addPoints(int p)
	{
		score += p;
	}
	public static void endGame() {
		//Selector.getInstance().destroyAll();
	}
}
