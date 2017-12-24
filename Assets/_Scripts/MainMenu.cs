using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    Text soundButtonText;
    AudioSource source;


	// Use this for initialization
	void Start () {
        soundButtonText = GameObject.FindGameObjectWithTag("SoundButton").transform.GetChild(0).GetComponent<Text>();
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        SoundCheck();
	}
	
    void SoundCheck() {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            source.mute = true;
            soundButtonText.text = "Sound: Off";
        }
        else
        {
            source.mute = false;
            soundButtonText.text = "Sound: On";
        }
    }

    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
