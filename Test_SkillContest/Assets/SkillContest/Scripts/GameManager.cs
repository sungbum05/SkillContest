using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int Stage = 1;

    [SerializeField] EnemySpanwer enemySpanwer;

    // Start is called before the first frame update
    void Start()
    {
        SendEnemyData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendEnemyData()
    {
        enemySpanwer.ReadEnemyData(
            Resources.Load<TextAsset>($"EnemyPatton_1").text);
    }
}
