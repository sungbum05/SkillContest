using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ScrollObj : MonoBehaviour
{
    GameObject Player;

    float ZPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Test_PlayerControllet>().gameObject;
        ZPos = this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Scrolling();
    }

    void Scrolling()
    {
        this.gameObject.transform.position = Player.gameObject.transform.position + new Vector3(0, 0, ZPos);
    }
}
