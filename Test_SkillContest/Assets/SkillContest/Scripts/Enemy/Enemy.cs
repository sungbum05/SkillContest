using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("利 加己")]
    [SerializeField]
    protected float MoveSpeed;


    public int hp = 0;

    public int Hp 
    { 
        get { return hp; } 

        set 
        {
            hp = value;

            if(hp <= 0)
            {
                Ondie();
            }
        } 
    }

    [Header("利 傍拜")]
    [SerializeField]
    protected float AttackDelay;

    [SerializeField]
    protected float AttackRange;

    [SerializeField]
    protected int AttckPower;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void Attack(GameObject Player);

    protected abstract void EnemyPatton();

    protected abstract void EnemyMove();

    private void Ondie()
    {
        Destroy(this.gameObject);
    }
}
