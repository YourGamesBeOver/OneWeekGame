using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public KeyCode Key;
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(Key))
	    {
	        var scene = SceneManager.GetActiveScene();
	        //SceneManager.UnloadScene(scene.buildIndex);
	        SceneManager.LoadScene(scene.buildIndex);
	    }
	}
}
