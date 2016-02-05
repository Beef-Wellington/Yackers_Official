using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {
	public void load(string s) {
		Application.LoadLevel(s);
	}
}
