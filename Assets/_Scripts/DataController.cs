using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{

    void Start()
    {
        // allows this object to persist
        DontDestroyOnLoad(gameObject);

        //todo: load main menu here

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


    void SavePlayerProgress(string level, int score)
    {
        PlayerPrefs.SetInt(level, score);
    }
}
