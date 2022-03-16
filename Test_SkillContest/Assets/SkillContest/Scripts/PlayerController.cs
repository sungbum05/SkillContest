using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform[] Left_wheels;
    [SerializeField]
    private Transform[] Right_wheels;

    public Rigidbody rigidbody;
    public float MoveSpeed= 10;

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
    }
    
    void PlayerMove()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        this.gameObject.transform.position += new Vector3(X * MoveSpeed * Time.deltaTime, 0, Z * MoveSpeed * Time.deltaTime);
    }

    IEnumerator PlayerRotate()
    {
        while(true)
        {
            yield return null;

            switch(Input.GetAxisRaw("Horizontal"))
            {
                case -1:
                    if(this.gameObject.transform.localRotation.z < 0.15f)
                    {
                        this.gameObject.transform.Rotate(0, 0, 0.2f);
                    }
                    break;

                case 1:
                    if(this.gameObject.transform.localRotation.z > -0.15f)
                    {
                        this.gameObject.transform.Rotate(0, 0, -0.2f);
                    }
                    break;

                default:
                    if(this.gameObject.transform.localRotation.z >= 0.15f || this.gameObject.transform.localRotation.z > 0.0f)
                    {
                        this.gameObject.transform.Rotate(0, 0, -0.1f);
                    }

                    else if(this.gameObject.transform.localRotation.z <= -0.15f || this.gameObject.transform.localRotation.z < 0.0f)
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

                        else if(Rotate.eulerAngles.z >= 300 || Rotate.eulerAngles.z >= 270)
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
