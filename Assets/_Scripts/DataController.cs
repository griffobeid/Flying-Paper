using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public GameObject pauseMenu;
    GameObject pause, levels, mainCanvas;
    Text soundButtonText;

    void Start()
    {
        // allows this object to persist
        DontDestroyOnLoad(gameObject);

        InitiateSound();
        Time.timeScale = 1;
    }

    //used for sound
    void InitiateSound()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            // by default the sound is on
            PlayerPrefs.SetInt("Sound", 1);
        }
    }

    //for muting sound
    public void ToggleSound()
    {
        if (GameObject.FindGameObjectWithTag("SoundButton") != null)
        {
            soundButtonText = GameObject.FindGameObjectWithTag("SoundButton").transform.GetChild(0).GetComponent<Text>();
        }
        AudioSource source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        // toggle the audio source attached to the Main Camera
        // change the text on the sound toggle button to on/off
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 1);
            source.mute = false;
            if (soundButtonText != null)
            {
                soundButtonText.text = "Sound: On";
            }
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            source.mute = true;
            if (soundButtonText != null)
            {
                soundButtonText.text = "Sound: Off";
            }
        }
    }

    //called to load main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //called to load pause menu with selectable options
    public void LoadPauseMenu()
    {
        pause = Instantiate(pauseMenu) as GameObject;
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        mainCanvas.SetActive(false);

        // bind methods to pause menu buttons
        Transform pauseCanvas = pause.transform.GetChild(1).transform;
        pauseCanvas.GetChild(1).GetComponent<Button>().onClick.AddListener(HidePauseMenu);
        pauseCanvas.GetChild(2).GetComponent<Button>().onClick.AddListener(Reset);
        pauseCanvas.GetChild(3).GetComponent<Button>().onClick.AddListener(LoadLevelsMenu);
        pauseCanvas.GetChild(4).GetComponent<Button>().onClick.AddListener(ToggleSound);
        pauseCanvas.GetChild(5).GetComponent<Button>().onClick.AddListener(LoadMainMenu);

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            pauseCanvas.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Sound: Off";
        }
        else
        {
            pauseCanvas.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Sound: On";
        }
        Time.timeScale = 0;
    }

    //sets pause menu to inactive
    public void HidePauseMenu()
    {
        if (pause != null)
        {
            Destroy(pause);
            mainCanvas.SetActive(true);
            Time.timeScale = 1;
        }
    }

    //loads the level select scene
    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //re-loads the current scene
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //used for keeping track of level scores
    public void SubmitNewPlayerScore(int newScore, string level)
    {
        if (newScore > GetHighestPlayerScore(level))
        {
            SavePlayerProgress(level, newScore);
        }
    }

    //used to get the highest score;
    public int GetHighestPlayerScore(string level)
    {
        return PlayerPrefs.GetInt(level);
    }

    //loads first scene of game
    public void StartGame() {
        SceneManager.LoadScene("_Level_0_Final");
    }

    //saves score to playerprefs
    void SavePlayerProgress(string level, int score)
    {
        PlayerPrefs.SetInt(level, score);
    }
}
