using UnityEngine;
using System.Collections;

public class CallSelector : MonoBehaviour {

	public void select() {
		Selector.getInstance().Select();
	}
}
