using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPlay : MonoBehaviour {
    AudioSource source;
    void Start() {
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("Sound") == 0) {
            source.mute = true;
        } else {
            source.mute = false;
        }
    }

	public void PlayGame()
    {
        //Debug.Log("Button Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
