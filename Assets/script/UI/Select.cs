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
        SceneManager.LoadScene("Scratch");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
