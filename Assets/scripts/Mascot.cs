using UnityEngine;
using System.Collections;

public class Mascot : MonoBehaviour {
	public static Mascot instance;
	
	public Animator anim;

	void Start () {
		instance = this;
		anim = GetComponent<Animator>();
	}
	
	public static Mascot get() { return instance; }

	public void Play(string s) {
		anim.Play(s);
	}
}
