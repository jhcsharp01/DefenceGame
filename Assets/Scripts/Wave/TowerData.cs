using UnityEngine;

[CreateAssetMenu(menuName = "Tower/TowerData")]
public class TowerData : ScriptableObject
{
    public Sprite icon;         //�̹���
    public string tower_name;   //Ÿ�� �̸�
    public float damage;        //������
    public float range;         //���� ����
    public float attack_speed;  //���� �ӵ�(�ֱ�)
    public int cost;            //���� ���
    public GameObject prefab;   //������ Ÿ�� ������Ʈ
    public float weight = 1.0f; // ����ġ(Ư�� ������ �� ��������)
}
