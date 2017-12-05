using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlyingPaper : MonoBehaviour
{
    // vars set in unity
    public Text scoreText, livesText, hiscoreText;
    public GameObject planePrefab;
    public GameObject ClearCoin;
    public AudioClip coinSound;
    public float soundClipVol;
    public AudioClip failSound;
    public AudioClip throwSound;
    public AudioClip ventSound;
    public AudioClip explosionSound;
    public AudioClip winSound;
    public AudioClip switchSound;
    public AudioClip teleportSound;
    public GameObject canvas;
    public Slider rotSlider, speedSlider;
    private static float rSliderVal, sSliderVal;
    public float teleXOffset = 0, teleYOffset = 0;


    // private vars
    string currentLevel;
    int returnToLevel;
    int score;
    int lives;
    AudioSource source;
    Button flyButton, nextButton;
    DataController dataController;
    Vector3 holderStartPosition, planeStartPosition;
    Quaternion holderStartRotation, planeStartRotation;

    void Start()
    {
        dataController = FindObjectOfType<DataController>();

        source = gameObject.GetComponent<AudioSource>();
        SoundCheck();
        
        nextButton = GameObject.FindGameObjectWithTag("NextLevelButton").GetComponent<Button>();
        nextButton.onClick.AddListener(NextLevel);
        if (SceneManager.GetActiveScene().name != "GameOver")
        {
            nextButton.gameObject.SetActive(false);
            returnToLevel = Application.loadedLevel;
        }
        flyButton = GameObject.FindGameObjectWithTag("GameController").GetComponent<Button>();

        lives = 5;
        currentLevel = SceneManager.GetActiveScene().name;
        hiscoreText.text = "Highscore: " + dataController.GetHighestPlayerScore(currentLevel).ToString();
    }

    //get slider values to update
    void Update()
    {
        rSliderVal = rotSlider.value;
        sSliderVal = speedSlider.value ;
    }

    // this gets called when the plane hits the floor
    // if lives are greater than 0 then the level soft resets
    // if there are no more lives hard reset the level.
    public void DestroyPlaneAndReset()
    {
        lives = lives - 1;
        livesText.text = "Lives: " + lives.ToString();
        //source.PlayOneShot(explosionSound, soundClipVol);
        source.PlayOneShot(failSound, soundClipVol);//play fail sound effect
        //Destroy(GameObject.FindGameObjectWithTag("PlaneHolder"));
        SoftReset();
    }

    // destroy the coin and increment the score
    public void CoinPickup(Collider col)
    {
        GameObject coin = col.gameObject;
        GameObject clearCoin = Instantiate(ClearCoin) as GameObject;

        clearCoin.transform.position = coin.transform.position;
        clearCoin.transform.localEulerAngles = new Vector3(90, coin.transform.localEulerAngles.y, coin.transform.localEulerAngles.z);

        source.PlayOneShot(coinSound, soundClipVol);

        this.score++;
        scoreText.text = "Score: " + score.ToString();
        Destroy(coin);
    }
    // called once the finish line is triggered
    public void FinishLine()
    {
        source.PlayOneShot(winSound, soundClipVol);//play win sound
        dataController.SubmitNewPlayerScore(score, currentLevel);
        hiscoreText.text = "Highscore: " + dataController.GetHighestPlayerScore(currentLevel).ToString();
        // todo: set the final score here
        nextButton.gameObject.SetActive(true);
    }

    void SoftReset()
    {
        if (lives > 0)
        {
            flyButton.gameObject.SetActive(true);
            //GameObject holder = Instantiate(planePrefab) as GameObject;
            GameObject holder = GameObject.FindGameObjectWithTag("PlaneHolder");
            GameObject trail = GameObject.FindGameObjectWithTag("Trail");
            Transform plane = holder.transform.GetChild(0);

            trail.SetActive(false);
            //Destroy(trail);
            holder.transform.position = holderStartPosition;
            holder.transform.rotation = holderStartRotation;
            plane.position = planeStartPosition;
            plane.rotation = planeStartRotation;
            plane.GetComponent<PaperPlaneV2>().Init();
            trail.SetActive(true);
            //GameObject newTrail = Instantiate(trail) as GameObject;
            //newTrail.transform.parent = plane;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().name=="GameOver")
        {
            if (returnToLevel != null)
            {
                Application.LoadLevel(returnToLevel);
            }
            else
            {
                SceneManager.LoadScene("1");
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SetStartPosition(Vector3 holderStart, Vector3 planeStart)
    {
        holderStartPosition = holderStart;
        planeStartPosition = planeStart;
    }

    public void SetStartRotation(Quaternion holderStart, Quaternion planeStart)
    {
        holderStartRotation = holderStart;
        planeStartRotation = planeStart;
    }

    public void SoundCheck() {
        if(PlayerPrefs.GetInt("Sound") == 0) {
            source.mute = true;
        } else {
            source.mute = false;
        }
    }

    public void playVentSound()
    {
        source.PlayOneShot(switchSound);
    }

    public void PlayTeleportSound()
    {
        source.PlayOneShot(teleportSound);
    }

    public void PlayThrowSound()
    {
        source.PlayOneShot(throwSound);
    }
}
