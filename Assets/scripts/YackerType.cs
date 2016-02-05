using UnityEngine;
using System.Collections;

public class YackerType : MonoBehaviour 
{
	//Singleton
	public static YackerType values; void Awake() { values = this; }

	public Sprite[] bodies;		//The BASE of the Yacker
	public Sprite[] outlines;	//Each value corresponds to the matching bod array
	public Texture2D[] patterns;		//Patterns are put as the texture for the materials on the bodies
	public Color[] bColors, oColors;	//Body colors and Outline colors, respectively
	public Sprite[] parts1, parts2;		//Any extra objects, typically eyes and a mouth
	
	
}
