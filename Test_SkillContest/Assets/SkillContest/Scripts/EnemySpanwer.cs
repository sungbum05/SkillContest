using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    [Header("몹 종류")]
    [SerializeField] private GameObject Bacteria;
    [SerializeField] private GameObject Germ;
    [SerializeField] private GameObject Cancer;
    [SerializeField] private GameObject Virus;
    [SerializeField] private GameObject EventWall_1;

    [Header("스폰 데이터")]
    [SerializeField] private List<Transform> SpawnPoint;

    [SerializeField] private List<EnemyData> EnemyDatas;

    private void Awake()
    {
        AddPoints();
    }

    private void Start()
    {
        StartCoroutine(GameManager.Instance.SendEnemyData());
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

            EnemyData.SpawnDelay = int.Parse(EnemyLine[0]);
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

            EnemyData.WaitTime = int.Parse(EnemyLine[4]);

            EnemyDatas.Add(EnemyData);
        }

        StartCoroutine(EnemySpawn());
        EnemyDatas.Clear();
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

                case "Germ":
                    Enemy = Instantiate(Germ, spawnVec, Germ.transform.rotation);
                    break;

                case "Cancer":
                    Enemy = Instantiate(Cancer, spawnVec, Cancer.transform.rotation);
                    break;

                case "Virus":
                    Enemy = Instantiate(Virus, spawnVec, Virus.transform.rotation);
                    break;

                case "EventWall_1":
                    Enemy = Instantiate(EventWall_1, spawnVec, EventWall_1.transform.rotation);
                    break;

                default:
                    break;
            }

            if (EnemyDatas[i].MoveDir != 0)
            {
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
            if (Enemy.GetComponent<Enemy>().FreezeTime <= 0.0f)
            {
                Vector3 TargetPos = new Vector3(SpawnPoint[curPos + MoveDir].position.x, SpawnPoint[curPos + MoveDir].position.y, Enemy.transform.position.z);

                //yield return new WaitForSeconds(WaitTime);
                Enemy.transform.position = Vector3.MoveTowards(Enemy.gameObject.transform.position, TargetPos, 15 * Time.deltaTime);

                if (Enemy.transform.position.Equals(TargetPos))
                {
                    yield return new WaitForSeconds(WaitTime);

                    curPos += MoveDir;

                    MoveDir *= -1;

                    Debug.Log(MoveDir);
                }
            }
        }
    }
}
