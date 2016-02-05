using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {
	float zPos;					//keeps the Object the correct distance from the camera when dragged
	bool returning = false;		//lets the Object lerp back to its original position
	Vector3 startingPoint;		//Where the Object starts so it can return there if need be
	Vector3 currentLoc;			//Where the Object is when they start returning
	float startTime, fracJourney, distance;	//Lerping variables
		
	void Start () {
			zPos = transform.position.z;
			startingPoint = transform.position;
	}
	
	void Update()
	{
		if(returning)
		{
			fracJourney = (Time.time- startTime) * 10f / distance;
			transform.position = Vector3.Lerp(currentLoc, startingPoint, fracJourney);
			if(fracJourney >= 1)
			{
				returning = false;
			}
		}
	}
	
	void OnMouseDrag()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = zPos;
		transform.position = mousePos;
	}
	
	public void goHome()
	{
		if(transform.position != startingPoint)
		{
			returning = true;
			currentLoc = transform.position;
			startTime = Time.time;
			distance = Vector3.Distance(currentLoc, startingPoint);
		}
	}
}
