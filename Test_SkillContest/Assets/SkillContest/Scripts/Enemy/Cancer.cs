using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : Enemy
{
    public GameObject BulletZip;
    public GameObject DesBulletZip;

    [SerializeField]
    List<GameObject> Bullets;

    // Start is called before the first frame update
    void Start()
    {
        Hp = 30;
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        DownFreeze();
    }

    protected override void EnemyMove()
    {
        base.EnemyMove();

        if (Bullets.Count >= ShotCnt)
        {
            BulletZip.transform.Rotate(0, 0, 130 * Time.deltaTime);
        }
    }

    protected override IEnumerator Attack()
    {
        int Angle = 360;

        yield return null;

        base.GetTarget();

        while (true)
        {
            yield return null;
            AttackRange = Vector3.Distance(this.gameObject.transform.position, Target.position);

            Debug.Log(Bullets.Count);

            if (AttackRange <= 700 && Bullets.Count <= 0 && FreezeTime <= 0)
            {
                yield return new WaitForSeconds(Random.Range(AttackDelay - 1.0f, AttackDelay + 2.0f));

                for (int i = 1; i <= ShotCnt; i++)
                {


                    GameObject Bullet = Instantiate(EnemyBullet, this.gameObject.transform.position, EnemyBullet.transform.rotation);

                    Bullet.GetComponent<EnemyATBullet>().BulletPower = AttckPower;
                    Bullet.GetComponent<EnemyATBullet>().ballvelocity = BulletSpeed;

                    Bullet.transform.parent = BulletZip.transform;

                    Bullet.transform.rotation = Quaternion.Euler(0, 0, Angle);

                    Angle -= 360 / ShotCnt;

                    StartCoroutine(Movebullet(Bullet));

                    yield return new WaitForSeconds(AttackDelay / ShotCnt);
                }

                Angle = 360;
                StartCoroutine(StartAttck());
            }
        }
    }

    protected override void EnemyPatton()
    {

    }

    IEnumerator StartAttck()
    {
        yield return new WaitForSeconds(AttackDelay * 2);

        foreach(GameObject Bullet in Bullets)
        {
            Bullet.transform.parent = GameObject.Find("DesBulletZip").transform;

            Bullet.GetComponent<EnemyATBullet>().Fire = true;
            Bullet.GetComponent<EnemyATBullet>().ThisDestroy();

            yield return new WaitForSeconds(AttackDelay/ShotCnt);

            //Bullet.transform.paren
        }

        Bullets.Clear();
        BulletZip.transform.rotation = Quaternion.Euler(0, 0, 0);
        StopCoroutine(StartAttck());
    }

    IEnumerator Movebullet(GameObject Bullet)
    {
        Vector3 GotoBulletPos = Bullet.transform.up * 25;

        while (true)
        {
            yield return null;

            if (Mathf.Approximately(Bullet.transform.position.y, this.transform.position.y + GotoBulletPos.y))
            {
                Bullets.Add(Bullet);
                break;
            }      

            Bullet.gameObject.transform.position = Vector3.MoveTowards(Bullet.transform.position, this.transform.position + GotoBulletPos, 30 * Time.deltaTime);

            //Debug.Log(GotoBulletPos);
        }

        StopCoroutine(Movebullet(Bullet));
    }
}
