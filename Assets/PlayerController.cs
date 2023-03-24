using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed=15;
    private float _screenHalfWidth;

// Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x/2;
        _screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize+halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * _speed;
        transform.Translate(Vector2.right*velocity*Time.deltaTime);
        if (transform.position.x < -_screenHalfWidth)
        {
            transform.position = new Vector2(_screenHalfWidth, transform.position.y);
        }
        if (transform.position.x >_screenHalfWidth)
        {
            transform.position = new Vector2(-_screenHalfWidth, transform.position.y);
        }
    }
}
