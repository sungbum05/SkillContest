using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : Enemy
{
    [SerializeField] GameObject Shield;

    // Start is called before the first frame update
    void Start()
    {
        Hp = 30;
        ShieldCnt = 1;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        EnemyPatton();
    }

    protected override void Attack(GameObject Player)
    {
        
    }

    protected override void EnemyMove()
    {
        this.gameObject.transform.Translate(0,0,-MoveSpeed * Time.deltaTime);
    }

    protected override void EnemyPatton()
    {
        Shield.transform.Rotate(0, 90 * Time.deltaTime, 0);


        if (ShieldCnt > 0)
        {
            Shield.SetActive(true);
        }

        else
        {
            Shield.SetActive(false);
        }
    }
}
