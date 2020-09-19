using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private ObstaclesManager _obstaclesManager;

    public float Width = 5;

    void Start()
    {
        _obstaclesManager = GetComponentInParent<ObstaclesManager>();
    }

    void Update()
    {
        var position = transform.position;

        transform.position = position + new Vector3(0, 0, _obstaclesManager.ObstacleSpeed);
    }
}
