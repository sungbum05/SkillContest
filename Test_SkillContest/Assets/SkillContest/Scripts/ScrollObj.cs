using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObj : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scroll();
    }

    void scroll()
    {
        this.gameObject.transform.Translate(new Vector3(0, 0, playerController.MoveSpeed * (Input.GetKey(KeyCode.LeftShift) ? 1 : 0.4f) * Time.deltaTime));
    }
}
