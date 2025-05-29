using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave/Wave")]
public class WaveData : ScriptableObject
{
    public int count; //마리 수
    public float spawn_interval; //생성 간격
    public GameObject prefab;   //생성할 적 오브젝트
}
