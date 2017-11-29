using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public GameObject pauseMenu, levelsMenu;
    GameObject pause, levels, mainCanvas;

    void Start()
    {
        // allows this object to persist
        DontDestroyOnLoad(gameObject);

        InitiateSound();
        Time.timeScale = 1;
    }

    void InitiateSound()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            // by default the sound is on
            PlayerPrefs.SetInt("Sound", 1);
        }
    }


    public void ToggleSound()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            Transform pauseCanvas = pause.transform.GetChild(1).transform;
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                PlayerPrefs.SetInt("Sound", 1);
                pauseCanvas.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Sound: On";
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FlyingPaper>().SoundCheck();
            }
            else
            {
                PlayerPrefs.SetInt("Sound", 0);
                pauseCanvas.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = "Sound: Off";
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FlyingPaper>().SoundCheck();
            }
        }
        else
        {
            AudioSource source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
            Text soundButtonText = GameObject.FindGameObjectWithTag("SoundButton").transform.GetChild(0).GetComponent<Text>();
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                PlayerPrefs.SetInt("Sound", 1);
                source.mute = false;
                soundButtonText.text = "Sound: On";
            }
            else
            {
                PlayerPrefs.SetInt("Sound", 0);
                source.mute = true;
                soundButtonText.text = "Sound: Off";
            }
        }
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

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

    public void HidePauseMenu()
    {
        if (pause != null)
        {
            Destroy(pause);
            mainCanvas.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void LoadLevelsMenu()
    {

    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SubmitNewPlayerScore(int newScore, string level)
    {
        if (newScore > GetHighestPlayerScore(level))
        {
            SavePlayerProgress(level, newScore);
        }
    }

    public int GetHighestPlayerScore(string level)
    {
        return PlayerPrefs.GetInt(level);
    }

    public void StartGame() {
        SceneManager.LoadScene("0");
    }

    void SavePlayerProgress(string level, int score)
    {
        PlayerPrefs.SetInt(level, score);
    }
}
