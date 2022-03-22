using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    [SerializeField] private GameObject Cancer;

    [SerializeField] private List<Transform> SpawnPoint;

    [SerializeField] private List<EnemyData> EnemyDatas;

    private void Awake()
    {
        AddPoints();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void AddPoints()
    {
        foreach (Transform PosObj in transform)
        {
            foreach (Transform Point in PosObj.transform)
            {
                SpawnPoint.Add(Point);
            }
        }
    }

    public void ReadEnemyData(string textFileText)
    {
        var StringFile = new StringReader(textFileText);

        while (true)
        {
            string EnemyPattons = StringFile.ReadLine();

            if (EnemyPattons == null)
                break;

            string[] EnemyLine = EnemyPattons.Split(',');

            var EnemyData = new EnemyData();

            EnemyData.SpawnDelay = float.Parse(EnemyLine[0]);
            EnemyData.SpawnType = EnemyLine[1].ToString();
            EnemyData.SpawnPos = int.Parse(EnemyLine[2]);

            EnemyDatas.Add(EnemyData);
        }

        EnemySpawn();
    }


    void EnemySpawn()
    {
        Debug.Log(SpawnPoint[EnemyDatas[5].SpawnPos]);

        for (int i = 0; i < EnemyDatas.Count; i++)
        {
            Debug.Log("1차");
            Debug.Log(i);

            Vector3 spawnVec = SpawnPoint[EnemyDatas[i].SpawnPos].position;
            Debug.Log(SpawnPoint[EnemyDatas[i].SpawnPos]);

            switch (EnemyDatas[i].SpawnType)
            {
                case "Cancer":

                    Debug.Log("2차");
                    Instantiate(Cancer, spawnVec, Cancer.transform.rotation);
                    break;

                default:
                    Debug.Log("오류");
                    break;
            }
        }
    }
}
