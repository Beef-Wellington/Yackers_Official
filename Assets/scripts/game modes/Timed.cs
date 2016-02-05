using UnityEngine;
using System.Collections;

public class Timed : MonoBehaviour 
{
	public GameObject[] timerBits;
	int timeLeft = 61;
	public bool gameOver = false;
	// Use this for initialization
	void Start () 
	{
		timerBits = new GameObject[16];
		for(int i = 1; i <= 15; i++)
		{
			string childName = (i*4).ToString();
			timerBits[i] = GameObject.Find(childName);
		}
		InvokeRepeating("loseTime", 1f, 1f);
	}
	
	void loseTime()
	{
		if(!gameOver)
		{
			timeLeft--;
			if(timeLeft % 4 == 0 && timeLeft <= 60)
			{
				print(timeLeft.ToString());
				timerBits[(timeLeft/4)].SetActive(false);
			}
			if(timeLeft <= 0)
			{
				gameOver = true;
			}
		}
	}
	
	void addTime(int t)
	{
		if(!gameOver)
		{
			for(int x = 0; x < t; x++)
			{
				timeLeft++;
				if(timeLeft%4 == 0)
				{
					timerBits[timeLeft].SetActive(true);
				}
			}
		}
	}
}
