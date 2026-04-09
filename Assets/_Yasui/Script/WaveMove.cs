using UnityEngine;

public class WaveMove : MonoBehaviour
{
    private float createdTime;
    private void Start()
    {
        createdTime = Time.time;
    }
    private void Update()
    {
        if(transform.position.y > -10)
        {
            transform.position = new Vector2(Mathf.Sin(createdTime - Time.time), createdTime - Time.time);
        }
    }
}
