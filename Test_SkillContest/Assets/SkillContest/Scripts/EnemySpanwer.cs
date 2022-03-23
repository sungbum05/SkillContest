using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    [Header("몹 종류")]
    [SerializeField] private GameObject Bacteria;
    [SerializeField] private GameObject Cancer;
    [SerializeField] private GameObject EventWall_1;

    [Header("스폰 데이터")]
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

            switch (EnemyLine[3].ToString())
            {
                case "Top":
                    EnemyData.MoveDir = -4;
                    break;

                case "Bottom":
                    EnemyData.MoveDir = 4;
                    break;

                case "Left":
                    EnemyData.MoveDir = -1;
                    break;

                case "Right":
                    EnemyData.MoveDir = 1;
                    break;

                default:
                    EnemyData.MoveDir = 0;
                    break;
            }

            EnemyData.WaitTime = float.Parse(EnemyLine[4]);

            EnemyDatas.Add(EnemyData);
        }

        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        GameObject Enemy = null;

        for (int i = 0; i < EnemyDatas.Count; i++)
        {
            Vector3 spawnVec = SpawnPoint[EnemyDatas[i].SpawnPos].position;

            if (EnemyDatas[i].SpawnDelay != 0)
                yield return new WaitForSeconds(EnemyDatas[i].SpawnDelay);

            switch (EnemyDatas[i].SpawnType)
            {
                case "Bacteria":
                    Enemy = Instantiate(Bacteria, spawnVec, Bacteria.transform.rotation);
                    break;

                case "Cancer":
                    Enemy = Instantiate(Cancer, spawnVec, Cancer.transform.rotation);
                    break;

                case "EventWall_1":
                    Enemy = Instantiate(EventWall_1, spawnVec, EventWall_1.transform.rotation);
                    break;

                default:
                    break;
            }

            if (EnemyDatas[i].MoveDir != 0)
            {
                Debug.Log(EnemyDatas[i].MoveDir);
                StartCoroutine(Move(Enemy, EnemyDatas[i].SpawnPos, EnemyDatas[i].MoveDir, EnemyDatas[i].WaitTime));
            }
        }

        StopCoroutine(EnemySpawn());
    }

    public IEnumerator Move(GameObject Enemy, int curPos, int MoveDir, float WaitTime)
    {
        //Vector3 TargetPos = new Vector3(SpawnPoint[curPos + MoveDir].position.x, SpawnPoint[curPos + MoveDir].position.y, Enemy.transform.position.z);
        yield return new WaitForSeconds(WaitTime);

        while (true)
        {
            yield return null;
            Vector3 TargetPos = new Vector3(SpawnPoint[curPos + MoveDir].position.x, SpawnPoint[curPos + MoveDir].position.y, Enemy.transform.position.z);

            Enemy.transform.position = Vector3.MoveTowards(Enemy.gameObject.transform.position, TargetPos, 40 * Time.deltaTime);
        }
    }
}
