using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    [Header("보스 개인 속성")]
    [SerializeField]
    GameObject[] Enemys;

    [SerializeField]
    Slider BossHpBar;

    [SerializeField]
    Text BossHpTxt;

    [SerializeField]
    bool EnemySpawn = false;

    [Header("외부 속성")]
    [SerializeField]
    GameObject Player;

    private void Start()
    {
        BossBasicSetting();
        StartCoroutine(BossPatton1());
    }

    // Update is called once per frame
    void Update()
    {
        GetTarget();
        Spawn();
    }

    protected override IEnumerator Attack()
    {
        yield return null;
    }

    protected override void EnemyMove()
    {

    }

    protected override void EnemyPatton()
    {

    }

    #region 보스 1 ~ 2 패턴
    IEnumerator BossPatton1() // 무지성 발사
    {
        yield return null;
        ShotCnt = 20;

        for (int i = 0; i < ShotCnt; i++)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(Random.Range(-20.0f, 21.0f), Random.Range(-20.0f, 21.0f), 0);

            GameObject Bullet = Instantiate(EnemyBullet, this.transform.position, Quaternion.identity);
            Bullet.GetComponent<EnemyBullet>().BulletPower = AttckPower;
            Bullet.GetComponent<Rigidbody>().AddForce(-(this.gameObject.transform.forward) * BulletSpeed, ForceMode.Impulse);

            yield return new WaitForSeconds(AttackDelay);
        }
    }

    IEnumerator BossPatton2()
    {
        yield return null;
    }

    IEnumerator BossPatton3()
    {
        yield return null;
    }

    IEnumerator BossPatton4()
    {
        yield return null;
    }

    IEnumerator BossPatton5()
    {
        yield return null;
    }

    IEnumerator BossPatton6()
    {
        yield return null;
    }

    #endregion

    void Spawn()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (GameManager.Instance.BossSpawm == true && this.gameObject.transform.position.z >= 5350)
        {
            BossHpBar.gameObject.SetActive(true);
            BossHpTxt.gameObject.SetActive(true);

            this.gameObject.transform.Translate(0, 0, -70 * Time.deltaTime);
        }

        if (EnemySpawn == false)
        {
            foreach (GameObject obj in Enemys)
            {
                Destroy(obj);
            }
        }
    }

    void BossBasicSetting()
    {
        this.gameObject.transform.position = new Vector3(0, 0, 6000);
        Hp = 500 * GameManager.Instance.Stage;

        BossHpTxt.text = this.gameObject.name;
        BossHpBar.maxValue = Hp;
        BossHpBar.value = BossHpBar.maxValue;

        BossHpBar.gameObject.SetActive(false);
        BossHpTxt.gameObject.SetActive(false);

        Player = FindObjectOfType<PlayerController>().gameObject;
    }

}
