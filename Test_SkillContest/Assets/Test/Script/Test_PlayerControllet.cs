using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerControllet : MonoBehaviour
{
    [SerializeField]
    int PlayerHp = 100;

    [SerializeField]
    int MoveSpeed = 20;

    [SerializeField]
    int MinX, MinY;
    [SerializeField]
    int MaxX, MaxY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 MoveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetKey(KeyCode.LeftShift) ? 1 : 0.4f);

        this.gameObject.transform.position += MoveDir * MoveSpeed * Time.deltaTime;

        this.gameObject.transform.position = new Vector3(Mathf.Clamp(this.gameObject.transform.position.x, MinX, MaxX),
            Mathf.Clamp(this.gameObject.transform.position.y, MinY, MaxY), Mathf.Clamp(this.gameObject.transform.position.z, 0, 5000));
    }
}
