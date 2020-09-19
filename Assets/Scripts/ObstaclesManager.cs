using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public float ObstacleSpeed = 0.25f;
    public float Width = 400f;
    public float Gap = 8f;

    public List<GameObject> ObstaclePrefabs;
    
    private List<GameObject> _obstacles;
    private GameObject _nextObstacle;
    void Start()
    {
        _obstacles = new List<GameObject>();
        _nextObstacle = _getRandomObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        _generateObstacles();
        _destroyObstacles();
    }

    private void _generateObstacles()
    {
        var lastObstacle = _obstacles.LastOrDefault();
        var lastObstacleController = lastObstacle ? lastObstacle.GetComponent<ObstacleController>() : null;
        var spawnPosition = transform.position;

        bool shouldGenerate = false;

        
        if (!lastObstacle)
        {
            shouldGenerate = true;
        }
        else
        {
            var lastObstaclePosition = lastObstacle.transform.localPosition.z;
            var threshold = lastObstacleController.Width / 2 + _nextObstacle.GetComponent<ObstacleController>().Width / 2 + Gap;

            if (lastObstaclePosition > threshold)
            {
                shouldGenerate = true;
            }
        }
        if (shouldGenerate)
        {
            var newObstacle = Instantiate(_nextObstacle, Vector3.zero, Quaternion.identity);
            newObstacle.transform.parent = transform;
            newObstacle.transform.localPosition = Vector3.zero;
            
            _obstacles.Add(newObstacle);

            _nextObstacle = _getRandomObstacle();
        }
    }

    private void _destroyObstacles()
    {
        var lastObstacle = _obstacles.FirstOrDefault();
        if (lastObstacle && lastObstacle.transform.localPosition.z > Width)
        {
            Destroy(lastObstacle);
            _obstacles.RemoveAt(0);
        }
    }

    private GameObject _getRandomObstacle() => ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Count)];
}
