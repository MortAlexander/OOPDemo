using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField]private Vector2 _speedMinMax ;
    private float _speed;
    private float LowerLimit;
    void Start()
    {
        _speed = Mathf.Lerp(_speedMinMax.x, _speedMinMax.y,Difficulty.GetDificultyPercent());
        LowerLimit = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*_speed*Time.deltaTime);
        if (transform.position.y<LowerLimit)
        {
            gameObject.SetActive(false);
            PoolController.Instance.Return(gameObject);
        }
    }
}
