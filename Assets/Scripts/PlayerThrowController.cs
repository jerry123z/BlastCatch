using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowController : MonoBehaviour
{
    private GameObject _ball;

    private GameObject _ballAnchor;

    public float ThrowVelocity = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        _ballAnchor = GetComponentInChildren<BallAnchor>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_ball)
        {
            _ball.transform.position = _ballAnchor.transform.position;
            
            bool down = Input.GetKeyDown(KeyCode.Space);
            if(down)
            {
                _throw();
            }
        }
        
    }

    private void _throw()
    {
        if (_ball)
        {
            var forward = transform.forward.normalized;
            var rigidBody = _ball.GetComponent<Rigidbody>();
            var newVelocity = forward * ThrowVelocity;
            newVelocity.y = ThrowVelocity * 0.5f;
            
            rigidBody.velocity = newVelocity;

            _ball = null;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _ball = other.gameObject;
        }
    }
}
