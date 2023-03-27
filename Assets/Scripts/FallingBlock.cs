using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


public class FallingBlock : MonoBehaviour
{
    [SerializeField]protected Vector2 _speedMinMax ;
    [SerializeField] protected float LowerLimit;
    protected float _speed;

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// if position.y less then LowerLimit hide object and return to ObjectPool
    /// </summary>
    protected void CheckLimit()
    {
        if (transform.position.y<LowerLimit)
        {
            gameObject.SetActive(false);
            PoolController.Instance.Return(gameObject);
        }
    }

    private void OnEnable()
    {
        OnEnableSetUp();
    }

    /// <summary>
    /// sets private variables 
    /// </summary>
    protected virtual void OnEnableSetUp()
    {
        SetLowerLimit();
        _speed = Mathf.Lerp(_speedMinMax.x, _speedMinMax.y, Difficulty.GetDificultyPercent());

    }

    // ABSTRACTION
    /// <summary>
    /// Set lowest position  according to object size and screen height
    /// </summary>
    protected void SetLowerLimit()
    {
        LowerLimit = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // ABSTRACTION
    /// <summary>
    /// Set method to override in children already include limitCheck  
    /// </summary>
    protected virtual void Move()
    {
        CheckLimit();
    }
    
}
