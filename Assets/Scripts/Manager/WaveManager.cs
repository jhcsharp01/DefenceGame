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
            Debug.Log("���̺� ���� ���Դϴ�.");
            return;
        }
        
        StartCoroutine(SpawnWave(waves[waveIdx]));
        waveIdx++;
    
    }

    //����,, ���� �ð� ���缭
    //���̺� ������ �޾Ƽ� �� ���� �����̸�ŭ ����
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
