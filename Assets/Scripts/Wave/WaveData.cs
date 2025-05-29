using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave/Wave")]
public class WaveData : ScriptableObject
{
    public int count; //���� ��
    public float spawn_interval; //���� ����
    public GameObject prefab;   //������ �� ������Ʈ
}
