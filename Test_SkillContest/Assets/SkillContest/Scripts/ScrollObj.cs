using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObj : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private float PosZ;

    // Start is called before the first frame update
    void Start()
    {
        PosZ = this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        scroll();
    }

    void scroll()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 
            playerController.gameObject.transform.position.z + PosZ);
    }
}
