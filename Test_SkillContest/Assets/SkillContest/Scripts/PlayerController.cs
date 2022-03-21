using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 움직임")]
    [SerializeField]
    private Transform[] Left_wheels;
    [SerializeField]
    private Transform[] Right_wheels;

    [SerializeField]
    private float MinX, MaxX;
    [SerializeField]
    private float MinZ, MaxZ;

    public float MoveSpeed = 10;

    [Header("플레이어 공격")]
    [SerializeField]
    private GameObject PlayerBullet;
    [SerializeField]
    private float BulletSpeed = 200;


    [Header("플레이어 컴포넌트")]
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LeftWheelRotate());
        StartCoroutine(RightWheelRotate());
        StartCoroutine(PlayerRotate());
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        PlayerAttack();
    }

    void PlayerMove()
    {
        float CurMinZ = this.gameObject.transform.position.z - 30.0f;

        Vector3 MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (MoveDir.z == 0)
        {
            this.gameObject.transform.Translate(new Vector3(MoveDir.x, 0, 1 * MoveSpeed / 2.5f) * Time.deltaTime);
        }


        #region 플레이어 메인 움직임
        if (this.gameObject.transform.position.z >= MinZ || MoveDir.z >= 0)
        {
            this.gameObject.transform.Translate(MoveDir * MoveSpeed * Time.deltaTime);

            this.gameObject.transform.position = new Vector3(Mathf.Clamp(this.gameObject.transform.position.x, MinX, MaxX)
                , 1
                , Mathf.Clamp(this.gameObject.transform.position.z, MinZ, MaxZ));
        }
        #endregion

        if (MoveDir.z >= 0 && CurMinZ >= 0)
        {
            MinZ = CurMinZ;
        }
    }

    void PlayerAttack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(PlayerBullet, this.gameObject.transform.position , Quaternion.identity);
            Bullet.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * BulletSpeed, ForceMode.Impulse);
        }
    }

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
}
