using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {
    
	void Update() { 
        if (Input.GetKeyDown(KeyCode.R)){ 
            Reset();
        }
	}

    void Reset()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
