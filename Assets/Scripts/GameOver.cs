
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI scoreTMP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTMP.SetText(GameManager.Instance.score.ToString());
    }

    public void PlayAgain()
    {
        GameManager.Instance.score = 0;
        GameManager.Instance.ballCount = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
