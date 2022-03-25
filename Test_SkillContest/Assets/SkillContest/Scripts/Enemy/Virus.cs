using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    [SerializeField]
    int MaxShotCnt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    protected override IEnumerator Attack()
    {
        GetTarget();

        yield return null;
        
        while(true)
        {
            yield return new WaitForSeconds(AttackDelay);

            for (int i = 1; i <= ShotCnt; i++)
            {
                GameObject Bullet = Instantiate(EnemyBullet, this.gameObject.transform.position, EnemyBullet.transform.rotation);
                Bullet.GetComponent<EnemyBullet>().BulletPower = AttckPower;
            }

            ShotCnt += 2;
        }
    }

    protected override void EnemyMove()
    {
        this.gameObject.transform.Translate(0, 0, -MoveSpeed);
    }

    protected override void EnemyPatton()
    {
        
    }
}
