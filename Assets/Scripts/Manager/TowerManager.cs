using UnityEngine;
using System.Collections.Generic;

public class TowerManager : MonoBehaviour
{
    #region Singleton
    public static TowerManager instance { get; private set; }
    private void Awake()
    { 
       instance = this;
    }
    #endregion Singleton

    //Ÿ�� ���� Ǯ
    public List<TowerData> towerPool;

    public Transform towerParent;

    
    public void RandSpawnTower(Vector2 spawnPos)
    {
        TowerData towerData = GetTower();

        if (GameManager.instance.Cost(towerData.cost))
        {
            GameObject tower = Instantiate(towerData.prefab, spawnPos, Quaternion.identity);

            Debug.Log($"{towerData.tower_name}�� �����Ǿ����ϴ�!");
        }
        else
        {
            Debug.Log("�ܾ��� �����մϴ�!");
        }
    }
    private TowerData GetTower()
    {
        float total_weight = 0;
        //Ÿ�� Ǯ�� ��ϵ� Ÿ�� �����͸� ������� ���� ����ġ�� ����մϴ�.
        foreach (TowerData data in towerPool)
        {
            total_weight += data.weight;
        }

        float rand = Random.Range(0, total_weight); //0���� ���� ����ġ ������ ���� �� ����
        float current = 0; //���� ����ġ

        foreach(TowerData tower in towerPool)
        {
            current += tower.weight;
            //������ ����ġ�� ���� ������ ũ�ų� ���� ��Ȳ�� ���� �ش� Ÿ���� return�մϴ�.
            if(rand <= current)
            {
                return tower;
            }
        }
        //�� �۾����� ó���� �ȵ� ��Ȳ�̸� ������ �⺻ Ÿ���� �������� ����(���� ����)
        return towerPool[0];
    }

}
