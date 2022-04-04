using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Test_Enemy : MonoBehaviour
{
    [Header("적 상태")]
    [SerializeField]
    protected private int hp;

    public int HP
    {
        get
        {
            return hp;
        }

        set
        {
            if (Shield <= 0)
            {
                hp = value;

                if (hp <= 0)
                {
                    OnDie();

                }
            }

            else
            {
                Shield--;
            }
        }
    }

    [SerializeField]
    protected int Shield;

    [SerializeField]
    protected int MoveSpeed;

    [Header("적 공격")]
    [SerializeField]
    protected GameObject Target;

    [SerializeField]
    protected int AttackPower;

    [SerializeField]
    protected int AttackDelay;

    [SerializeField]
    protected int AttackRange;

    [SerializeField]
    protected int Bullet;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        this.gameObject.transform.Translate(0, 0, -MoveSpeed);
    }

    protected abstract IEnumerator Attack();

    protected abstract IEnumerator AttackPatton();

    protected virtual void OnDie()
    {
        Destroy(this.gameObject);
    }
}
