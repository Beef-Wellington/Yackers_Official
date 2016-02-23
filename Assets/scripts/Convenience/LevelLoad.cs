using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour {

    static LevelLoad instance;

    void start() {
        instance = this;
    }

    public static LevelLoad getInstance() {
        return instance;
    }

    public void load(string s) {
        Debug.Log(s);
        SceneManager.LoadScene(s);
	}
}
