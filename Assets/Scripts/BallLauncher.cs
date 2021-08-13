using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Vector3 _worldPosition;
    private Vector3 _startDragPosition;
    private Vector3 _endDragPosition;
    private Camera _camera;
    private LaunchPreview _launchPreview;
    private int _ballsReady;
    private float _timeBetweenBalls = 0.1f;
    private bool _canLaunch = true;
    private BlockSpawner _blockSpawner;
    private Ball _ballPrefab;
    [SerializeField] private Ball _defaultBall;
    [SerializeField] private Ball _soccerBall;
    [SerializeField] private Ball _tennisBall;
    [SerializeField] private Ball _bowlingBall;

    private SpriteRenderer _spriteRenderer;
    
    private List<Ball> _balls = new List<Ball>();
    private List<Ball> _newBalls = new List<Ball>();
    private bool _isDragging;

    private void Awake()
    {
        CheckBallType();
        GameManager.Instance.isPaused = false;
        _blockSpawner = FindObjectOfType<BlockSpawner>();
        _launchPreview = GetComponent<LaunchPreview>();
        CreateBall();
    }

    private void Start()
    {
        _camera = Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance.ballCount == 0)
        {
            _spriteRenderer.color = Color.clear;
            return;
        }

        if (GameManager.Instance.ballCount > 0)
        {
            _spriteRenderer.color = Color.green;
        }
        _worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (GameManager.Instance.isPaused)
        {
            _isDragging = false;
            return;
        }
        if (!_canLaunch) return;
        
        if (Input.GetMouseButtonDown(0) && _worldPosition.y > -3f)
        {
            _isDragging = true;
            StartDrag();
        }
        else if (Input.GetMouseButton(0))
        {
            if (!_isDragging) return;
            ContinueDrag();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!_isDragging) return;
            EndDrag();
        }
        
    }

    private void CheckBallType()
    {
        _ballPrefab = GameManager.Instance.currentBall switch
        {
            "Soccer Ball" => _soccerBall,
            "Tennis Ball" => _tennisBall,
            "Bowling Ball" => _bowlingBall,
            _ => _defaultBall
        };
    }
    
    private void FixedUpdate()
    {
        if(!_isDragging) transform.position = new Vector2(_worldPosition.x, transform.position.y);
    }

    private void CreateBall()
    {
        var ball = Instantiate(_ballPrefab);
        ball.gameObject.SetActive(false);
//        _newBalls.Add(ball);
        GameManager.Instance.ballCount = 1;
    }
    private void StartDrag()
    {
        _startDragPosition = _worldPosition;
        _launchPreview.SetStartPoint(transform.position);
    }

    private void ContinueDrag()
    {
        _endDragPosition = _worldPosition;
        Vector3 direction = _endDragPosition - _startDragPosition;
        _launchPreview.SetEndPoint(transform.position - direction);
    }

    private void EndDrag()
    {
        StartCoroutine(LaunchBalls());
    }

    private IEnumerator LaunchBalls()
    {
        _canLaunch = false;
        _launchPreview.SetEndPoint(Vector3.zero);
        _launchPreview.SetStartPoint(Vector3.zero);
        Vector3 direction = _endDragPosition - _startDragPosition;
        direction.Normalize();
        _ballsReady = GameManager.Instance.ballCount;

        for (var i = 0; i < _ballsReady; i++)
        {
            var ball = Instantiate(_ballPrefab);
            ball.gameObject.SetActive(false);
            _newBalls.Add(ball);
        }

        
        foreach (var ball in _newBalls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            Debug.Log(-direction);
            ball.GetComponent<Rigidbody2D>().velocity = -direction;
            _balls.Add(ball);
            GameManager.Instance.ballCount--;
            yield return new WaitForSeconds(_timeBetweenBalls);
        }

        _newBalls.Clear();
        _ballsReady = 0;
        _canLaunch = true;
        _isDragging = false;
    }

    public void ReturnBall()
    {
//        _ballsReady++;
//         if (_ballsReady == _balls.Count)
//         {
//             CreateBall();
//             _canLaunch = true;
// //            _launchPreview.gameObject.SetActive(true);
//         }
    }
}
//ideas - currency to change themes
//no powersup in classic, only normal ballz
//powerups that will be stored on the right and can be used whenever
//powerup ideas - shotgun, sniper-no bounce but pierces, bounceroom, precise line
//currency can be picked up rarely or watch ads/pay
//different block shapes in different modes, keep squares in classic
////  bugdone - can make a move while balls are still moving
//turbo speed for when there are a lot of balls - increase movespeed and ballbetween speed
//guarantee at least one block per row
//lifetime stats
//make linerenderer disappear after enddrag
//clamp linerenderer to certain distance

//2.0
//make balls upgrade when bounced up, do double damage, 3x, etc. change color rarities like borderlands
//bug make bumper not destroy blocks ez fix
//still clamp linerenderer
//colors change every 5 hp of blocks, rotate through rainbow set number
//
// soot sprite ball