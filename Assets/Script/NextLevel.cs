using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public static NextLevel instance = null;
    int sceneIndex, levelPassed;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }
   
    public void Interaksi()
    {
        if (levelPassed < sceneIndex)
            PlayerPrefs.SetInt("LevelPassed", sceneIndex);
    }
}
