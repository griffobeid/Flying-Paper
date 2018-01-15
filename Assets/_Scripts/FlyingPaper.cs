using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FlyingPaper : MonoBehaviour
{
    // vars set in unity
    public Text scoreText, livesText, hiscoreText;
    public GameObject planePrefab;
    public GameObject ClearCoin;
    public GameObject canvas;
    public AudioClip coinSound;
    
    //for audio
    public AudioClip failSound;
    public AudioClip throwSound;
    public AudioClip ventSound;
    public AudioClip explosionSound;
    public AudioClip winSound;
    public AudioClip switchSound;
    public AudioClip teleportSound;
    public float soundClipVol;

    //sliders
    public Slider rotSlider, speedSlider;

    //used for teleporter location
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

    //instantiate
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
            returnToLevel = SceneManager.GetActiveScene().buildIndex;
        }
        flyButton = GameObject.FindGameObjectWithTag("GameController").GetComponent<Button>();

        lives = 5;
        currentLevel = SceneManager.GetActiveScene().name;
        hiscoreText.text = "Highscore: " + dataController.GetHighestPlayerScore(currentLevel).ToString();
    }


    // this gets called when the plane hits the floor
    // if lives are greater than 0 then the level soft resets
    // if there are no more lives hard reset the level.
    public void DestroyPlaneAndReset()
    {
        lives = lives - 1;  //lives bookkeeping
        livesText.text = "Lives: " + lives.ToString();  //lives bookkeeping
        source.PlayOneShot(failSound, soundClipVol);    //play fail sound effect
        SoftReset();    //reinstantiate
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
    public void GateAndKey(Collider col)
    {
        GameObject key = col.gameObject;
        GameObject gate=GameObject.Find("gate");
        //GameObject clearKey = Instantiate(ClearKey) as GameObject;
        //clearkey.transform.position = key.transform.position;
        Destroy(key);
        Destroy(gate);
    }
    // called once the finish line is triggered
    public void FinishLine()
    {
        source.PlayOneShot(winSound, soundClipVol);//play win sound
        dataController.SubmitNewPlayerScore(score, currentLevel);
        hiscoreText.text = "Highscore: " + dataController.GetHighestPlayerScore(currentLevel).ToString();
        nextButton.gameObject.SetActive(true);
    }

    //resets plane position with trail if there are still lives remaining.
    void SoftReset()
    {
        if (lives > 0)
        {
            //reactivate fly button
            flyButton.gameObject.SetActive(true);

			//reactivate sliders
			rotSlider.gameObject.SetActive(true);
			speedSlider.gameObject.SetActive (true);

            //disable old trail and enable new one
            GameObject holder = GameObject.FindGameObjectWithTag("PlaneHolder");
            GameObject trail = holder.transform.GetChild(0).transform.GetChild(0).gameObject;
            Vector3 trailPos = GameObject.FindGameObjectWithTag("TrailRenderPosition").transform.position;
            Transform plane = holder.transform.GetChild(0);
            trail.transform.parent = null;  //this will keep the trail from following the plane as it's position is reset.

            //reposition plane
            holder.transform.position = holderStartPosition;
            holder.transform.rotation = holderStartRotation;
            plane.position = planeStartPosition;
            plane.rotation = planeStartRotation;

            //reinstantiate
            plane.GetComponent<PaperPlaneV2>().Init();
			GameObject newTrail = Instantiate(trail, trailPos, new Quaternion(0,0,0,0), plane) as GameObject; 
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //reloads current scene
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //loads main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //exits game when called
    public void Quit()
    {
        Application.Quit();
    }

    //calls next scene in build order
    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().name=="GameOver")
        {
            SceneManager.LoadScene(returnToLevel);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //sets plane position when reinstantiated
    public void SetStartPosition(Vector3 holderStart, Vector3 planeStart)
    {
        holderStartPosition = holderStart;
        planeStartPosition = planeStart;
    }

    //sets plane rotation when reinstantiated
    public void SetStartRotation(Quaternion holderStart, Quaternion planeStart)
    {
        holderStartRotation = holderStart;
        planeStartRotation = planeStart;
    }

    //check sound
    public void SoundCheck() {
        if(PlayerPrefs.GetInt("Sound") == 0) {
            source.mute = true;
        } else {
            source.mute = false;
        }
    }

    //plays vent sound
    public void playVentSound()
    {
        source.PlayOneShot(switchSound);
    }

    //plays teleport sound
    public void PlayTeleportSound()
    {
        source.PlayOneShot(teleportSound);
    }

    //plays throw sound
    public void PlayThrowSound()
    {
        source.PlayOneShot(throwSound);
    }
}
