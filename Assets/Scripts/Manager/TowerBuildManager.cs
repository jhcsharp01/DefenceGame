using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerBuildManager : MonoBehaviour
{
    #region
    public static TowerBuildManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Tilemap boundary; //���(��ġ ����)
    public Tilemap buildable;

    public GameObject preview; //��ġ�� ��ġ Ȯ�� ���


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            InPlace(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    //���� ������ �۾��ǵ���
    bool tileMapBounds(Vector3Int cellPos)
    {
        var bounds = boundary.cellBounds;
        return bounds.Contains(cellPos);
    }

    bool isOccupied(Vector3 world_pos)
    {
        //������ ���� ��ǥ�� ��ġ�� Collider�� ���� üũ ����
        return Physics2D.OverlapPoint(world_pos, LayerMask.GetMask("Tower"));
    }

    public void InPlace(Vector3 world_pos)
    {
        //���� ���� ���� ��ġ ��ȯ
         Vector3Int cellPos = buildable.WorldToCell(world_pos);
        Vector3 pos = buildable.GetCellCenterWorld(cellPos);

        if(!tileMapBounds(cellPos) || buildable.HasTile(cellPos) || isOccupied(pos))
        {
            Debug.Log("��ġ �Ұ�");
            return;
        }


        TowerManager.instance.RandSpawnTower(pos);

        buildable.SetTile(cellPos, null);

        


    }
}
