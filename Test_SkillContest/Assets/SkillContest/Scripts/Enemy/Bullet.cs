using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int hp;

    [SerializeField]
    protected Transform PlayerTr;

    public int HP { 
        get
        {
            return hp;
        }

        set
        {
            hp = value;

            if(hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
