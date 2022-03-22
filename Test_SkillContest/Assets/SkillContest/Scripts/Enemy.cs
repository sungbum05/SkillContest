using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("�� �Ӽ�")]
    [SerializeField]
    protected float MoveSpeed;

    [SerializeField] protected int Hp 
    { 
        get { return Hp; } 

        set { } 
    }

    [Header("�� ����")]
    [SerializeField]
    protected float AttackDelay;

    [SerializeField]
    protected float AttackRange;

    [SerializeField]
    protected float AttckPower;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void Attack();

    protected abstract void EnemyPatton();
}
