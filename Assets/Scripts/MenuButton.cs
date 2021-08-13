
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameManager.Instance.isPaused = true;
        PauseMenuPanel.SetActive(true);
    }
}
