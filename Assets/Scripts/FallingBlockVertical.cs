using UnityEngine;

// INHERITANCE
public class FallingBlockVertical : FallingBlock
{
    // POLYMORPHISM
    /// <summary>
    /// moves object down 
    /// </summary>
    protected override void Move()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        base.Move();
    }
}
