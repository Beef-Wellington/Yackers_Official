using UnityEngine;
using System.Collections;

//Time bar that counts down
//Time CAN be added to it
public class TimeBar : MonoBehaviour {
	static TimeBar instance;
	public float totalTime;	//In Seconds
	float timeLeft;
	float origScale;
	
	void Start()
	{
		instance = this;
		timeLeft = totalTime;
		origScale = transform.localScale.y;
		startTimer();
	}
	
	public static TimeBar getInstance() {
		return instance;
	}
	
	public void startTimer() {		
		StartCoroutine(countdown());
	}
	
	//After the time is done the game ends!
	public IEnumerator countdown(){
		while(timeLeft > 0)
		{
				yield return new WaitForSeconds(1f);
				timeLeft--;
		}
		Selector.getInstance().endGame();
	}
	
	void Update()
	{	
		if(timeLeft >= 0)
		{
			Vector3 newSize = transform.localScale;
			newSize.y = origScale * (timeLeft/totalTime);
			transform.localScale =  newSize;
		}
	}
}
