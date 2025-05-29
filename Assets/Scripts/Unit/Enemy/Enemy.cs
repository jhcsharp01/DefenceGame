using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int waypoint_idx;

    private void Update()
    {
        if (Path.waypoints == null || waypoint_idx >= Path.waypoints.Length)
            return;

        var target = Path.waypoints[waypoint_idx];

        var dir = (target.position - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;

        if(Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            waypoint_idx++;

            if(waypoint_idx >= Path.waypoints.Length)
            {
                GameManager.instance.life--;
                Debug.Log($"남은 라이프 : {GameManager.instance.life}");
                Destroy(gameObject);
            }
        }
    }
}
