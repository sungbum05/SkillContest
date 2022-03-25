using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("利 加己")]
    [SerializeField]
    protected float MoveSpeed;


    public int hp = 0;
    public int ShieldCnt = 0;

    public int Hp 
    { 
        get { return hp; } 

        set 
        {
            if (ShieldCnt <= 0)
            {
                hp = value;

                if (hp <= 0)
                {
                    Ondie();
                }
            }

            else
            {
                ShieldCnt--;
            }
        } 
    }

    [Header("利 傍拜")]
    [SerializeField]
    protected Transform Target;

    [SerializeField]
    protected GameObject EnemyBullet;

    [SerializeField]
    protected float AttackDelay;

    [SerializeField]
    protected float AttackRange;

    [SerializeField]
    protected int AttckPower;

    [SerializeField]
    protected int BulletSpeed;

    public int ShotCnt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract IEnumerator Attack();

    protected abstract void EnemyPatton();

    protected abstract void EnemyMove();

    private void Ondie()
    {
        Destroy(this.gameObject);
    }

    protected void GetTarget()
    {
        Target = GameObject.Find("Player").transform;
    }
}
