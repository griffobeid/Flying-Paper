using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPlay : MonoBehaviour
{

    AudioSource source;

    void Start()
    {
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        SoundCheck();
    }

    void SoundCheck()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            source.mute = true;
        }
        else
        {
            source.mute = false;

        }
    }

    //All of the following methods are used with UI buttons
    //to load certain scenes.
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("_Level_1_Final");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("_Level_2_Final");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("_Level_3_Final");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("_Level_4_Final");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("_Level_5_Final");
    }

    public void LoadLevel6()
    {
        SceneManager.LoadScene("_Level_6_Final");
    }

    public void LoadLevel7()
    {
        SceneManager.LoadScene("_Level_7_Final");
    }

    public void LoadLevel8()
    {
        SceneManager.LoadScene("_Level_8_Final");
    }

    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
