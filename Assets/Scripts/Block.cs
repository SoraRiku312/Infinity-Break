
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    private Color _color;
    private Color _nextColor;
    private TextMeshPro _textMeshPro;
    private SpriteRenderer _spriteRenderer;
    private int _health = 5;



    private void Awake()
    {

        _textMeshPro = GetComponentInChildren<TextMeshPro>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -3.93) SceneManager.LoadScene("GameOverScene");
    }

    private void UpdateVisuals()
    {
        _textMeshPro.text = _health.ToString();

        int healthNum = _health % 50;
        if (healthNum <= 10)
        {
            _color = Color.magenta;
            _nextColor = Color.blue;
        }

        else if (healthNum <= 20)
        {
            _color = Color.blue;
            _nextColor = Color.green;
        }

        else if (healthNum <= 30)
        {
            _color = Color.green;
            _nextColor = Color.yellow;
        }
        else if (healthNum <= 40)
        {
            _color = Color.yellow;
            _nextColor = Color.red;
        }
        else if (healthNum <= 50)
        {
            _color = Color.red;
            _nextColor = Color.magenta;
        }
        
        _spriteRenderer.color = Color.Lerp(_nextColor, _color, (healthNum % 10) / 10f);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != 6) return;
        var ballLevel = other.gameObject.GetComponent<Ball>().Level;
        _health -= ballLevel;
        if (_health <= 0)
        {

            GetComponent<ParticleSystem>().Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
//            Destroy(gameObject);
            GameManager.Instance.score++;
            FindObjectOfType<AudioManager>().Play("pop1");

        }
        else
        {
            FindObjectOfType<AudioManager>().Play("bottle1");
        }


        UpdateVisuals();
    }

    public void SetHits(int hits)
    {
        _health = hits;
        UpdateVisuals();
    }
    
    //
}
