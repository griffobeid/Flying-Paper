using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingPaper : MonoBehaviour {
    //vars set in unity
    public int lives; 
	public GameObject planePrefab;
    public bool __________________;

    public int score;

	// this gets called when the plane hits a wall
	public void PlaneDestroyed() {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
		lives--;

		if(lives == 0){
			// todo: display fail screen
			// for now I am just reloading the current scene
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		} else {
			// todo: reinstantiate paper plane
			GameObject plane = Instantiate(planePrefab) as GameObject;
		}

	}
}
