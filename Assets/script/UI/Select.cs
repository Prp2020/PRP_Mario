using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Select : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame1()
    {
        SceneManager.LoadScene("Game1_Main");
    }

    public void PlayGame1_PlayMode()
    {
        SceneManager.LoadScene("Game1_PlayMode");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
