using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FlyingPaper : MonoBehaviour {
    // vars set in unity
    // todo should lives be public or private?
    public int lives;
    public Text scoreText;
	public GameObject planePrefab;
    public GameObject flyButton;
    public GameObject canvas;
    public bool __________________;

    int score;
    Paperplane ppScript;
    UnityAction fly;

    void Start() {
        fly = new UnityAction(ppScript.BeginFlight);
        
    }

	// this gets called when the plane hits a wall
	public void PlaneDestroyed() {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
		lives--;

		if(lives == 0) {
			// todo: display fail screen
			// for now I am just reloading the current scene
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		} else {
			GameObject plane = Instantiate(planePrefab) as GameObject;
            GameObject newButton = Instantiate(flyButton) as GameObject;
            newButton.transform.SetParent(canvas.transform, false);
            newButton.GetComponent<Button>().onClick.AddListener(plane.GetComponent<Paperplane>().BeginFlight);
		}



	}

    // destroy the coin and increment the score
    public void CoinPickup(Collider coin) {
        coin.gameObject.SetActive(false);
        this.score++;
        scoreText.text = "Score: " + score.ToString();
    }

    // called once the finish line is triggered
    public void FinishLine() {
        // todo: set the final score here and then load the next scene
        Debug.Log("You win!");
    }
}
