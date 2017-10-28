using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlyingPaper : MonoBehaviour {
    // vars set in unity
    // todo should lives be public or private?
    public int lives;
    public Text scoreText;
	public GameObject planePrefab;
    public bool __________________;

    private int score;

    void Start() {
        scoreText.text = "Score: 0";
    }

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
			GameObject plane = Instantiate(planePrefab) as GameObject;
		}
	}

    // destroy the coin and increment the score
    public void CoinPickup(Collider coin) {
        coin.gameObject.SetActive(false);
        this.score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
