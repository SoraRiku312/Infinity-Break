
using UnityEngine;

public class Bumper : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    private Vector3 _mousePosition;
    private float _yPosition;
    private Camera _camera;
    private float _width;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _yPosition = _rigidbody2D.position.y;

        _width = GetComponent<Collider2D>().bounds.size.x;
        Debug.Log(_width);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void FixedUpdate()
    {
         
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (_mousePosition.y > -3.0) return;
        if (_mousePosition.x > 3.15) return;
        if (_mousePosition.x < -3.15) return;
        _rigidbody2D.MovePosition(new Vector2(_mousePosition.x, _yPosition ));
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != 6) return;
        Debug.Log(other.gameObject.GetComponent<Rigidbody2D>().velocity);
        var dist = other.GetContact(0).point.x - GetComponent<SpriteRenderer>().bounds.center.x;
        var angle = ((dist / (_width / 2f)) * 90) + 90;
        Debug.Log(angle * Mathf.Deg2Rad);
        var newVelocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad - Mathf.PI), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized *
                              other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        Debug.Log(newVelocity);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
        other.gameObject.GetComponent<Ball>().LevelUp();
    }
}
