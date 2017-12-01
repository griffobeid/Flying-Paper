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
    public GameObject canvas;

    // private vars
    string currentLevel;
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
        nextButton.gameObject.SetActive(false);

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
        lives = lives - 1;
        livesText.text = "Lives: " + lives.ToString();
        source.PlayOneShot(explosionSound, soundClipVol);
        source.PlayOneShot(failSound, soundClipVol);//play fail sound effect
        Destroy(GameObject.FindGameObjectWithTag("PlaneHolder"));
        SoftReset();
    }

    // destroy the coin and increment the score
    public void CoinPickup(Collider col)
    {
        GameObject coin = col.gameObject;
        GameObject clearCoin = Instantiate(ClearCoin) as GameObject;

        clearCoin.transform.position = coin.transform.position;
        clearCoin.transform.rotation = coin.transform.rotation;

        source.PlayOneShot(coinSound, soundClipVol);

        this.score++;
        scoreText.text = "Score: " + score.ToString();
        Destroy(coin);
    }

    // teleport to the receiver
    public void Teleport(Collider col) {
        GameObject sender = col.gameObject;
        GameObject receiver = sender.transform.parent.GetChild(1).gameObject;
        GameObject plane = GameObject.FindGameObjectWithTag("PlaneHolder");


        plane.transform.position = receiver.transform.position;
        plane.transform.position = new Vector3(receiver.transform.position.x + 10, receiver.transform.position.y, receiver.transform.position.z);
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
            GameObject holder = Instantiate(planePrefab) as GameObject;
            Transform plane = holder.transform.GetChild(0);
            holder.transform.position = holderStartPosition;
            holder.transform.rotation = holderStartRotation;
            plane.position = planeStartPosition;
            plane.rotation = planeStartRotation;
        }
        else
        {
            Reset();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
}
