
using TMPro;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTMP;

    [SerializeField] private TextMeshProUGUI ballTMP;

    [SerializeField] private TextMeshProUGUI dustTMP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTMP.text = GameManager.Instance.score.ToString();
        ballTMP.text = GameManager.Instance.ballCount.ToString();
        dustTMP.text = GameManager.Instance.dust.ToString();
    }
}
