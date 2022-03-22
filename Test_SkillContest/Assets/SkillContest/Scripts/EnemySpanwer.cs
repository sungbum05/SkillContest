using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    [SerializeField] private List<Transform> SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        AddPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddPoints()
    {
        foreach(GameObject PosObj in transform)
        {
            foreach(GameObject Point in transform)
            {
                SpawnPoint.Add(Point.gameObject.GetComponent<Transform>());
            }
        }
    }
}
