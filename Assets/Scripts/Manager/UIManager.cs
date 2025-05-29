using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text wave_text;

    public Text gold_text;


    #region Singleton
    public static UIManager instance { get; private set; }

    private void Awake()
    {  
       instance = this;  
    }
    #endregion

    public void UpdateGoldUI(int gold)
    {
        gold_text.text = gold.ToString();
    }
    
    public void OnTowerBuildButtonClick()
    {
        Vector2 spawn = BuildPosition();
        TowerManager.instance.RandSpawnTower(spawn);
    }

    Vector2 BuildPosition()
    {
        return new Vector2(0, 0);
    }
}
