using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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
        SceneManager.LoadScene("GameScene");
    }

    public void Customize()
    {
        SceneManager.LoadScene("CustomizeScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
