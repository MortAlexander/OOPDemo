using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class FallingBlockAngle : FallingBlock
{
    [SerializeField] private float _maxCoef;
    private Vector2 currentMinMax;
    private float currentCoef;
   
    // POLYMORPHISM
    /// <summary>
    /// moves object down and horizontal 
    /// </summary>
    protected override void Move()
    {
        transform.Translate( new Vector3( (_speed*currentCoef * Time.deltaTime), -(_speed * Time.deltaTime),0f));
        base.Move();
    }

    /// <summary>
    /// set private horizontal coefficient to move from sides to center  
    /// </summary>
    protected override void OnEnableSetUp()
    {
        currentMinMax=new Vector2(-_maxCoef,_maxCoef);
        base.OnEnableSetUp();
        if (transform.position.x>0)
        {
            currentMinMax = new Vector2(-_maxCoef,0);
        }
        else if (transform.position.x<0)
        {
            currentMinMax = new Vector2(0,_maxCoef);
        }

        currentCoef = Random.Range(currentMinMax.x, currentMinMax.y);
    }
}
