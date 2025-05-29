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

    public Tilemap boundary; //배경(배치 범위)
    public Tilemap buildable;

    public GameObject preview; //배치될 위치 확인 기능


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            InPlace(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    //영역 내에서 작업되도록
    bool tileMapBounds(Vector3Int cellPos)
    {
        var bounds = boundary.cellBounds;
        return bounds.Contains(cellPos);
    }

    bool isOccupied(Vector3 world_pos)
    {
        //지정한 월드 좌표에 위치한 Collider에 대한 체크 가능
        return Physics2D.OverlapPoint(world_pos, LayerMask.GetMask("Tower"));
    }

    public void InPlace(Vector3 world_pos)
    {
        //생성 가능 지역 위치 전환
         Vector3Int cellPos = buildable.WorldToCell(world_pos);
        Vector3 pos = buildable.GetCellCenterWorld(cellPos);

        if(!tileMapBounds(cellPos) || buildable.HasTile(cellPos) || isOccupied(pos))
        {
            Debug.Log("설치 불가");
            return;
        }


        TowerManager.instance.RandSpawnTower(pos);

        buildable.SetTile(cellPos, null);

        


    }
}
