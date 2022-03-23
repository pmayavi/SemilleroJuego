using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : EnemyFollow
{
    public int changeDirection;

    public override void Start(){}

    public override void Direction()
    {
        if(Random.Range(0,changeDirection) == 0){     
            var choices = new[]  { Vector2.up, Vector2.left, Vector2.right, Vector2.down };
            direction = choices[Random.Range(0,4)];
            direction += choices[Random.Range(0,4)];
        }
    }

    public override void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
