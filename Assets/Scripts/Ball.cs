using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public int Level;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _moveSpeed;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.color = Color.white;
        Level = 1;
    }

    private void Update()
    {
        _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _moveSpeed;
    }

    public void LevelUp()
    {
        if (Level >= 5) return;
        Level++;
        switch (Level)
        {
            case 2:
                _spriteRenderer.color = Color.green;
                break;
            case 3:
                _spriteRenderer.color = Color.blue;
                break;
            case 4:
                _spriteRenderer.color = Color.magenta;
                break;
            case 5:
                _spriteRenderer.color = Color.yellow;
                break;
            
        }
    }
}
