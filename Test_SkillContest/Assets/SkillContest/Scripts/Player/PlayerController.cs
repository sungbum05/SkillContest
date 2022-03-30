using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 상태")]
    [SerializeField]
    private int hp;
    bool ShieldChk = false;

    public int HP
    {

        get
        {
            return hp;
        }

        set
        {
            if (ShieldChk == false)
            {
                hp = value;

                if (hp <= 0)
                {
                    OnDie();
                }
            }
        }
    }

    [Header("플레이어 움직임")]
    [SerializeField]
    private Transform[] Left_wheels;
    [SerializeField]
    private Transform[] Right_wheels;

    [SerializeField]
    private float MinX, MaxX;
    [SerializeField]
    private float MinY, MaxY;

    public float MoveSpeed;

    [Header("플레이어 공격")]
    [SerializeField]
    private GameObject PlayerBullet;
    [SerializeField]
    private int BulletPower = 10;
    [SerializeField]
    private float BulletSpeed = 200;

    [Header("플레이어 아이템")]
    public GameObject Shield;
    public float ShieldTime;
    public float ShieldScale;

    public int WeaponCnt = 0;
    public GameObject Jet;
    public GameObject MoveZip;
    public List<GameObject> UpGradeWeapon;
    public List<GameObject> MovePoints;

    public GameObject Boom;
    public float BoomTime;
    public float BoomScale;


    [Header("플레이어 컴포넌트")]
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        HP = 100;

        StartCoroutine(LeftWheelRotate());
        StartCoroutine(RightWheelRotate());
        StartCoroutine(PlayerRotate());

        AddSubWeaPon();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        PlayerAttack();
        OnShield();
        OnBoom();
    }

    #region 플레이어 기본 조작
    void PlayerMove()
    {
        #region 플레이어 메인 움직임
        if (GameManager.Instance.BossSpawm == false)
        {
            Vector3 MoveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxisRaw("Vertical"), Input.GetKey(KeyCode.LeftShift) ? 1 : 0.4f);

            this.gameObject.transform.position += new Vector3(MoveDir.x, MoveDir.y, MoveDir.z) * MoveSpeed * Time.deltaTime;
        }

        else 
        {
            Vector3 MoveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

            this.gameObject.transform.position += new Vector3(MoveDir.x, MoveDir.y, MoveDir.z) * MoveSpeed * Time.deltaTime;
            GameManager.Instance.BossSpawm = true;
        }

        this.gameObject.transform.position = new Vector3(Mathf.Clamp(this.gameObject.transform.position.x, MinX, MaxX)
            , Mathf.Clamp(this.gameObject.transform.position.y, MinY, MaxY)
            , this.gameObject.transform.position.z);

        #endregion
    }

    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(PlayerBullet, this.gameObject.transform.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * BulletSpeed, ForceMode.Impulse);
            Bullet.GetComponent<PlayerBullet>().PlayerBulletPower = BulletPower;
            Bullet.GetComponent<PlayerBullet>().Target = this.gameObject;
        }
    }
    #endregion

    #region 플레이어 회전
    IEnumerator PlayerRotate()
    {
        while (true)
        {
            yield return null;

            switch (Input.GetAxisRaw("Horizontal"))
            {
                case -1:
                    if (this.gameObject.transform.localRotation.z < 0.15f)
                    {
                        this.gameObject.transform.Rotate(0, 0, 0.2f);
                    }
                    break;

                case 1:
                    if (this.gameObject.transform.localRotation.z > -0.15f)
                    {
                        this.gameObject.transform.Rotate(0, 0, -0.2f);
                    }
                    break;

                default:
                    if (this.gameObject.transform.localRotation.z >= 0.15f || this.gameObject.transform.localRotation.z > 0.0f)
                    {
                        this.gameObject.transform.Rotate(0, 0, -0.1f);
                    }

                    else if (this.gameObject.transform.localRotation.z <= -0.15f || this.gameObject.transform.localRotation.z < 0.0f)
                    {
                        this.gameObject.transform.Rotate(0, 0, 0.1f);
                    }
                    break;
            }
        }
    }

    IEnumerator LeftWheelRotate()
    {
        while (true)
        {
            yield return null;

            switch (Input.GetAxisRaw("Horizontal"))
            {
                case -1:

                    foreach (Transform Rotate in Left_wheels)
                    {
                        if (Rotate.eulerAngles.z < 300f)
                        {
                            Rotate.Rotate(0, 0, 1);
                        }
                    }
                    break;

                case 1: // -120

                    foreach (Transform Rotate in Left_wheels)
                    {
                        if (Rotate.eulerAngles.z > 240)
                        {
                            Rotate.Rotate(0, 0, -1);
                        }
                    }

                    break;

                default: // -90

                    foreach (Transform Rotate in Left_wheels)
                    {
                        if (Rotate.eulerAngles.z <= 240 || Rotate.eulerAngles.z <= 270)
                        {
                            Rotate.Rotate(0, 0, 0.5f);
                        }

                        else if (Rotate.eulerAngles.z >= 300 || Rotate.eulerAngles.z >= 270)
                        {
                            Rotate.Rotate(0, 0, -0.5f);
                        }
                    }

                    break;
            }
        }
    }

    IEnumerator RightWheelRotate()
    {
        while (true)
        {
            yield return null;

            switch (Input.GetAxisRaw("Horizontal"))
            {
                case -1:

                    foreach (Transform Rotate in Right_wheels)
                    {
                        if (Rotate.eulerAngles.z < 120)
                        {
                            Rotate.Rotate(0, 0, 1);
                        }
                    }
                    break;

                case 1: // -120

                    foreach (Transform Rotate in Right_wheels)
                    {
                        if (Rotate.eulerAngles.z > 60)
                        {
                            Rotate.Rotate(0, 0, -1);
                        }
                    }

                    break;

                default: // -90

                    foreach (Transform Rotate in Right_wheels)
                    {
                        if (Rotate.eulerAngles.z <= 60 || Rotate.eulerAngles.z <= 90)
                        {
                            Rotate.Rotate(0, 0, 0.5f);
                        }

                        else if (Rotate.eulerAngles.z >= 120 || Rotate.eulerAngles.z >= 90)
                        {
                            Rotate.Rotate(0, 0, -0.5f);
                        }
                    }

                    break;
            }
        }
    }
    #endregion

    #region 무기 업그레이드 회전 함수
    void AddSubWeaPon()
    {
        int Idx = 0;

        foreach (Transform T in Jet.transform)
        {
            UpGradeWeapon.Add(T.gameObject);
        }

        foreach (Transform T in MoveZip.transform)
        {
            MovePoints.Add(T.gameObject);
        }

        foreach (GameObject Obj in UpGradeWeapon)
        {
            StartCoroutine(RotateSubWeapon(Obj.gameObject, Idx));
            Idx++;
        }
    }

    IEnumerator RotateSubWeapon(GameObject SubWeapon, int Idx)
    {
        Idx += 1;

        if (Idx >= UpGradeWeapon.Count)
        {
            Idx = 0;
        }

        Vector3 TargetPos;

        while (true)
        {
            yield return null;
            if (WeaponCnt > 0)
            {
                TargetPos = MovePoints[Idx].transform.position;
                SubWeapon.transform.position = Vector3.MoveTowards(SubWeapon.transform.position, TargetPos, 2 * Time.deltaTime);

                if (TargetPos.Equals(SubWeapon.transform.position))
                {
                    Idx += 1;

                    if (Idx >= UpGradeWeapon.Count)
                    {
                        Idx = 0;
                    }
                }
            }
        }
    }
    #endregion

    #region 무적 함수
    void OnShield()
    {
        if (ShieldTime > 0.0f)
        {
            ShieldChk = true;
            ShieldTime -= Time.deltaTime;

            Shield.gameObject.SetActive(true);

            Shield.gameObject.transform.Rotate(0, 90 * Time.deltaTime, 0);

            if (ShieldTime >= 2.5f && Shield.transform.localScale.x <= 7.0f)
            {
                Shield.transform.localScale += new Vector3(ShieldScale * Time.deltaTime, ShieldScale * Time.deltaTime, ShieldScale * Time.deltaTime);
            }

            else if (ShieldTime <= 0.5f && Shield.transform.localScale.x >= 0.0f)
            {
                Shield.transform.localScale -= new Vector3(ShieldScale * Time.deltaTime, ShieldScale * Time.deltaTime, ShieldScale * Time.deltaTime);
            }
        }

        else
        {
            ShieldTime = 0.0f;
            ShieldChk = false;
            Shield.transform.localScale = new Vector3(0, 0, 0);

            Shield.gameObject.SetActive(false);
        }
    }

    #endregion

    #region 폭발 함수
    void OnBoom()
    {
        if (BoomTime > 0.0f)
        {
            BoomTime -= Time.deltaTime;

            Boom.gameObject.SetActive(true);

            if (BoomTime >= 2.0f && Boom.transform.localScale.x <= 35.0f)
            {
                Boom.transform.localScale += new Vector3(BoomScale * Time.deltaTime, BoomScale * Time.deltaTime, BoomScale * Time.deltaTime);
            }

            else if (BoomTime <= 1.0f && Boom.transform.localScale.x >= 0.0f)
            {
                Debug.Log("asdasd");

                Boom.transform.localScale -= new Vector3(BoomScale * Time.deltaTime, BoomScale * Time.deltaTime, BoomScale * Time.deltaTime);
            }
        }

        else
        {
            BoomTime = 0.0f;
            Boom.transform.localScale = new Vector3(0, 0, 0);

            Boom.gameObject.SetActive(false);
        }
    }

    #endregion

    void OnDie()
    {
        MoveSpeed = 0;

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
