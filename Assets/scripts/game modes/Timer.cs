using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	static Timer instance;
	public int totalTime;	//In Seconds
	public int timeLeft;
	
	void Start()
	{
		instance = this;
		timeLeft = totalTime;
	}
	
	public static Timer getInstance() {
		return instance;
	}
	
	public void startTimer() {		
		StartCoroutine(countdown());
	}
	
	public IEnumerator countdown(){
		while(timeLeft > 0)
		{
				yield return new WaitForSeconds(1f);
				timeLeft--;
		}
		//Manager.getInstance().endGame();
	}
	
	void Update()
	{	
		if(timeLeft >= 0)
		{
			int minutes = timeLeft / 60;
			int seconds = timeLeft % 60;
			string displayTime;
			
			if(seconds < 10)
				displayTime = minutes.ToString() + ":" + "0" + seconds.ToString();
			else
				displayTime = minutes.ToString() + ":" + seconds.ToString();
			
			GetComponent<TextMesh>().text = displayTime;
		}
	}
}
