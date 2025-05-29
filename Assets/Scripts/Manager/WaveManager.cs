using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    #region
    public static WaveManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    #endregion


    public List<WaveData> waves;

    public Transform spawnPoint;

    public float waveTime;

    public int waveIdx;

    public bool isSpawn = false;

    public void WaveStart()
    {
        if (isSpawn || waveIdx >= waves.Count)
        {
            Debug.Log("웨이브 진행 중입니다.");
            return;
        }
        
        StartCoroutine(SpawnWave(waves[waveIdx]));
        waveIdx++;
    
    }

    //생성,, 일정 시간 맞춰서
    //웨이브 데이터 받아서 그 수랑 딜레이만큼 생성
    public IEnumerator SpawnWave(WaveData wave)
    {
        isSpawn = true;
        UIManager.instance.UpdateWaveUI(waveIdx+1);

        for (int i = 0; i < wave.count; i++)
        {
            Instantiate(wave.prefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(wave.spawn_interval);
        }

        isSpawn = false;
        float timer = waveTime;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            UIManager.instance.UpdateTimeUI(timer);
            yield return null;
        }


        //yield return new WaitForSeconds(waveTime);
        UIManager.instance.TimeClearUI();
        WaveStart();
    }

  
}
