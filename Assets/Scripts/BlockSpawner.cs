using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;


public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private NewBall _newBallPrefab;
    [SerializeField] private Dust _dustPrefab;

    [SerializeField] private int _playWidth = 8;
    private float _camWidth;
    private float _camHeight;

    private float _distanceBetweenBlocks = .7f;
    [SerializeField] private float _speed = -0.1f;
    private float _timer;
    private int _rowsSpawned;
    private float _scoreTimer;

    private int _blockCount;
    
    
    
    private List<Block> _blocks = new List<Block>();
    private List<NewBall> _newBalls = new List<NewBall>();
    private List<Dust> _dusts = new List<Dust>();

    private void Awake()
    {
        _camWidth = Camera.main.pixelWidth;
        _camHeight = Camera.main.pixelHeight;
        if (_camHeight != 1920f || _camHeight != 2160f)
        {
            _distanceBetweenBlocks = 0.688f;
            _playWidth = 7;
        }
    }

    private void OnEnable()
    {
        for (var i = 0; i < 1; i++)
        {
            SpawnRowOfBlocks();
        }

    }

    private void Start()
    {
        //       _distanceBetweenBlocks = .7f * (_camWidth / 1080f);

     
    }

    private void FixedUpdate()
    {
        foreach (var block in _blocks)
        {
            if (block != null)
            {
                block.transform.position += new Vector3(0, -0.0055f, 0);

            }

        }
        
        
        foreach (var newBall in _newBalls)
        {
            if (newBall != null)
            {
                newBall.transform.position += new Vector3(0, -0.0055f, 0);

            }
        }
        
        foreach (var dust in _dusts)
        {
            if (dust != null)
            {
                dust.transform.position += new Vector3(0, -0.0055f, 0);

            }
        }

        
    }

    private void Update()
    {
        _scoreTimer += Time.deltaTime;
        GameManager.Instance.score = (int)Math.Floor(_scoreTimer);

        _timer += Time.deltaTime;
        if (_timer >= 2.5)
        {
            _timer = 0;
            SpawnRowOfBlocks();
        }
    }


    public void SpawnRowOfBlocks()
    {

        List<int> emptySpaces = new List<int>();
        
        _blockCount = 0;
        
        //chance to spawn blocks per playwidth
        for (var i = 0; i < _playWidth; i++)
        {
            if (Random.Range(0, 100) > 33)
            {
                emptySpaces.Add(i);
                continue;
            }
            _blockCount++;
            var health = 0;
            var block = Instantiate(_blockPrefab, GetPosition(i), Quaternion.identity);
            Debug.Log(block.transform.localScale);
 //           block.transform.localScale = new Vector3(.6f, .6f, .6f) / (_camWidth / 1080f);
            health = GameManager.Instance.score == 0 ? 1 : GameManager.Instance.score/ 4;
            if (health == 0) health = 1;
//            var health = Random.Range(1, 3) + _rowsSpawned;
            //TODO make one block per row double hp
            
            block.SetHits(health);
            _blocks.Add(block);
        }
        //run function again if no blocks spawned
        if (_blockCount == 0) SpawnRowOfBlocks();

        _rowsSpawned++;

        if (emptySpaces.Count == 0) return;
        int newBallSpot = emptySpaces[Random.Range(0, emptySpaces.Count - 1)];
        var newBall = Instantiate(_newBallPrefab, GetPosition(newBallSpot), Quaternion.identity);
        _newBalls.Add(newBall);
        emptySpaces.Remove(newBallSpot);
        
        if (emptySpaces.Count == 0) return;
        int dustSpot = emptySpaces[Random.Range(0, emptySpaces.Count - 1)];
        var dust = Instantiate(_dustPrefab, GetPosition(dustSpot), Quaternion.identity);
        emptySpaces.Remove(dustSpot);
        _dusts.Add(dust);




    }

    private Vector3 GetPosition(int i)
    {
        var position = transform.position;
        position += Vector3.right * (i * _distanceBetweenBlocks);
        return position;
    }
}
