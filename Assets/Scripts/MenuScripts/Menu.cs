using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.LoadGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void Customize()
    {
        SceneManager.LoadScene("CustomizeScene");
    }

    public void Quit()
    {
        GameManager.Instance.SaveGame();
        Application.Quit();
    }
}
