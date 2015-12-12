using UnityEngine;

public class QuitOnEscape : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}
}
