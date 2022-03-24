using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : Enemy
{
    public int ShotCnt;

    public GameObject BulletZip;

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
    }

    protected override void EnemyMove()
    {
        this.gameObject.transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
    }

    protected override IEnumerator Attack()
    {
        int Angle = 360;

        yield return null;

        base.GetTarget();

        while (true)
        {
            AttackRange = Vector3.Distance(this.gameObject.transform.position, Target.position);

            if (AttackRange <= 600)
            {
                yield return new WaitForSeconds(AttackDelay);

                for (int i = 1; i <= ShotCnt; i++)
                {


                    GameObject Bullet = Instantiate(EnemyBullet, this.gameObject.transform.position, EnemyBullet.transform.rotation);

                    Bullet.GetComponent<EnemyATBullet>().BulletPower = AttckPower;
                    Bullet.GetComponent<EnemyATBullet>().ballvelocity = BulletSpeed;
                    Bullet.transform.parent = BulletZip.transform;

                    Bullet.transform.rotation = Quaternion.Euler(0, 0, Angle);

                    Angle -= 360 / ShotCnt;

                    StartCoroutine(Movebullet(Bullet));
                }

                Angle = 360;
            }

            if (Bullets.Count > 0)
                BulletZip.transform.Rotate(0, 0, 90 * Time.deltaTime);
        }
    }

    protected override void EnemyPatton()
    {

    }

    IEnumerator Movebullet(GameObject Bullet)
    {
        Vector3 GotoBulletPos = Bullet.transform.position + (Bullet.transform.up * 20);

        while (true)
        {
            yield return null;

            if (GotoBulletPos == Bullet.gameObject.transform.position)
                break;
                

            Bullet.gameObject.transform.position = Vector3.MoveTowards(Bullet.transform.position, GotoBulletPos, 30 * Time.deltaTime);

            //Debug.Log(GotoBulletPos);
            Debug.Log(Bullet.transform.position);
        }

        Bullets.Add(Bullet);
        StopCoroutine(Movebullet(Bullet));
    }
}
