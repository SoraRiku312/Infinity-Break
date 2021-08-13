
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
        DontDestroyOnLoad(gameObject);
    }

    public int score;
    public int ballCount;
    public bool isPaused;
    public int dust;
    public string currentBall;

}
