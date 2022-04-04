using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Test_EnemySpanwer : MonoBehaviour
{
    public GameObject Bacteria;
    public GameObject Germ;
    public GameObject Cancer;
    public GameObject Virus;

    public List<Transform> SpawmPoint;

    public List<Test_EnemyData> EnemyDatas;

    // Start is called before the first frame update
    void Start()
    {
        AddSpawnPoint();

        StartCoroutine(Test_GameManager.INSTANCE.SendPattonData());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddSpawnPoint()
    {
        foreach(Transform T in this.gameObject.transform)
        {
            foreach(Transform TC in T.gameObject.transform)
            {
                SpawmPoint.Add(TC);
            }
        }
    }

    public void ReadPattonData(string StringFile)
    {
        var PattonFile = new StringReader(StringFile);

        while(true)
        {
            string EnemyPatton = PattonFile.ReadLine();

            if (EnemyPatton == null)
            {
                break;
            }

            string[] EnemyType = EnemyPatton.Split(',');

            var EnemyData = new Test_EnemyData();

            EnemyData.SpawnDelay = int.Parse(EnemyType[0]);
            EnemyData.Kind = EnemyType[1];
            EnemyData.SpawnPos = int.Parse(EnemyType[2]);

            switch(EnemyType[3])
            {
                case "Right":
                    EnemyData.MoveDir = 1;
                    break;

                case "Left":
                    EnemyData.MoveDir = -1;
                    break;

                case "Top":
                    EnemyData.MoveDir = 4;
                    break;

                case "Bottom":
                    EnemyData.MoveDir = -4;
                    break;
            }

            EnemyData.MoveWaitTime = int.Parse(EnemyType[4]);

            EnemyDatas.Add(EnemyData);
        }
    }
}
