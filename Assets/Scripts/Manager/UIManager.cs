using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text wave_text;

    public Text gold_text;

    public Text time_text;

    #region Singleton
    public static UIManager instance { get; private set; }

    private void Awake()
    {  
       instance = this;  
    }
    #endregion

    public void TimeClearUI()
    {
        time_text.text = "";
    }

    public void UpdateWaveUI(int wave)
    {
        wave_text.text = $"{wave} WAVE";
    }

    public void UpdateTimeUI(float time)
    {
        time_text.text = $"다음 웨이브까지 남은 시간 : {time:F1}초";
    }

    public void UpdateGoldUI(int gold)
    {
        gold_text.text = gold.ToString();
    }
    
    public void OnTowerBuildButtonClick()
    {
        Vector2 spawn = BuildPosition();
        TowerManager.instance.RandSpawnTower(spawn);
    }

    public void OnWaveButtonEnter()
    {
        WaveManager.instance.WaveStart();
    }
    Vector2 BuildPosition()
    {
        return new Vector2(0, 0);
    }
}
