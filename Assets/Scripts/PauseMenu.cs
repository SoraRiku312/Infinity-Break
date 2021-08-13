
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        GameManager.Instance.isPaused = false;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;
    }
}
