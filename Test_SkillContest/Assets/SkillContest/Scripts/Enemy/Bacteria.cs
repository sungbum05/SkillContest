using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Hp = 20;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    protected override void Attack(GameObject Player)
    {
        
    }

    protected override void EnemyMove()
    {
        this.gameObject.transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
    }

    protected override void EnemyPatton()
    {
        
    }
}
