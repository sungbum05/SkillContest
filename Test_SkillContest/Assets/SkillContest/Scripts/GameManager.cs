using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region ÀÎ½ºÅÏ½º »ý¼º
    private static GameManager instance;

    public static GameManager Instance { 
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }

            return instance;
        } 
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public int Stage = 1;
    public int Pain = 0;

    [Header("¾À °´Ã¼")]
    public EnemySpanwer enemySpanwer;
    public PlayerController Player;

    [Header("UI °´Ã¼")]
    public Slider HpSlider;
    public Slider PainSlider;
    public Text HpText;
    public Text PainText;

    // Start is called before the first frame update
    void Start()
    {
        BasicSetting();

        SendEnemyData();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState();
    }

    void SendEnemyData()
    {
        enemySpanwer.ReadEnemyData(
            Resources.Load<TextAsset>($"EnemyPatton_6").text);
    }
    
    void BasicSetting()
    {
        switch(Stage)
        {
            case 1:
                Pain = 10;
                break;

            case 2:
                Pain = 30;
                break;
        }

        enemySpanwer = FindObjectOfType(typeof(EnemySpanwer)) as EnemySpanwer;
        Player = FindObjectOfType(typeof(PlayerController)) as PlayerController;

        HpSlider = GameObject.Find("HpSlider").gameObject.GetComponent<Slider>();
        PainSlider = GameObject.Find("PainSlider").gameObject.GetComponent<Slider>();
        HpText = GameObject.Find("HpTxt").gameObject.GetComponent<Text>();
        PainText = GameObject.Find("PainTxt").gameObject.GetComponent<Text>();

        HpSlider.value = Player.HP;
        PainSlider.value = Pain;
    }

    void CurrentState()
    {
        HpText.text = $"HP : {Player.HP}";
        PainText.text = $"PAIN : {Pain}";

        HpSlider.value = GotoValue(HpSlider.value, Player.HP);
        PainSlider.value = GotoValue(PainSlider.value, Pain);
    }

    float GotoValue(float Value, float TargetValue)
    {
        if(Value > TargetValue)
        {
            Value -= 20 * Time.deltaTime;
        }

        else if(Value < TargetValue)
        {
            Value += 20 * Time.deltaTime;
        }

        return Value;
    }
}
