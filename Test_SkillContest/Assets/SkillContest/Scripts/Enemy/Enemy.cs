using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("利 加己")]
    public float MoveSpeed;

    public int hp = 0;
    public int ShieldCnt = 0;

    [SerializeField]
    float BackupSpeed;

    public float FreezeTime;

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
    public int AttckPower;

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

    protected virtual void EnemyMove()
    {
        if (GameManager.Instance.BossSpawm == false)
            this.gameObject.transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);

        else
            this.gameObject.transform.Translate(0, 0, -(MoveSpeed + 30) * Time.deltaTime);
    }

    private void Ondie()
    {
        Destroy(this.gameObject);
    }

    protected void GetTarget()
    {
        Target = GameObject.Find("Player").transform;
    }

    protected void DownFreeze()
    {
        if (FreezeTime > 0)
        {
            if(FreezeTime >= 3.0f)
            {
                MoveSpeed = 0;
            }

            FreezeTime -= Time.deltaTime;
        }

        else
        {
            MoveSpeed = BackupSpeed;
            FreezeTime = 0;
        }
    }
}
