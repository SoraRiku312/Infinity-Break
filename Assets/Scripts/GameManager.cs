
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame();
    }
    
    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        if (data == null)
            return;
        dust = data.stardust;
    }

    public int score;
    public int ballCount;
    public bool isPaused;
    public int dust;
    public string currentBall;

}
