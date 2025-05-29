using UnityEngine;

//경로 등록
public class Path : MonoBehaviour
{
    public static Transform[] waypoints;

    private void Awake()
    {
        int count = transform.childCount;

        waypoints = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
