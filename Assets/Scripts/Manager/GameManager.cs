using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance { get; private set; }

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    public int wave_count = 0; //���̺� ī��Ʈ
    public int gold = 100; //���� ���
    public int life = 20; //���
    public void Earn(int amount)
    {
        gold += amount;
        //UI �Ŵ����� ���� ȭ���� ��� �ؽ�Ʈ�� ���� ó��
        UIManager.instance.UpdateGoldUI(gold);
    }
    
    public bool Cost(int amount)
    {
        //������ �ڽ�Ʈ�� ���ٸ�, false
        if (gold < amount)
            return false;
        //�Ϲ����� ����� �ڽ�Ʈ�� �����ϰ� true
        gold -= amount;
        UIManager.instance.UpdateGoldUI(gold);
        return true;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        //�ٽ� ������ �� �ִ� ����� ������ְų�, ���� ���
    }

}
