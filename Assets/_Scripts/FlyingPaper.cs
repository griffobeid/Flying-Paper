using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlyingPaper : MonoBehaviour
{
    // vars set in unity
    // todo should lives be public or private?
    public int lives;
    public Text scoreText;
    public GameObject planePrefab;
    public GameObject ClearCoin;
    public AudioClip coinSound;
    public float soundClipVol;
    public AudioClip failSound;
    public AudioClip throwSound;
    public AudioClip ventSound;
    public AudioClip explosionSound;
    public AudioClip winSound;
    private AudioSource source;
    public GameObject flyButton, nextButton, settingsButton;
    public GameObject canvas;

    public bool __________________;

    // private vars
    int score;
    //used to initialize audiosource
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        nextButton = GameObject.FindGameObjectWithTag("NextLevelButton");
        nextButton.SetActive(false);
    }
    // this gets called when the plane hits a wall

    //CURRENTLY NOT USING THIS METHOD
    /*
    public void PlaneDestroyed()
    {
        source.PlayOneShot(explosionSound, soundClipVol);
        source.PlayOneShot(failSound, soundClipVol);//play fail sound effect

    }
    */

    // destroy the coin and increment the score
    public void CoinPickup(Collider coin)
    {
        source.PlayOneShot(coinSound, soundClipVol);//play coin sound effect
        coin.gameObject.SetActive(false);
        Instantiate(ClearCoin);
        ClearCoin.transform.position = coin.transform.position;
        ClearCoin.transform.rotation = coin.transform.rotation;
        this.score++;
        scoreText.text = "Score: " + score.ToString();
        ClearCoin.SetActive(true);
        Destroy(coin);
    }

    // called once the finish line is triggered
    public void FinishLine()
    {
        source.PlayOneShot(winSound, soundClipVol);//play win sound
        // todo: set the final score here
        Debug.Log("You win!");

        nextButton.SetActive(true);
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
}
