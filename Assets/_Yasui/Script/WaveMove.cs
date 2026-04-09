using UnityEngine;

public class WaveMove : MonoBehaviour
{
    [SerializeField] private float waveSpeed = 2f;
    [SerializeField] private float wavaScale = 2f;
    private Vector3 parentPosition;
    private float createdTime;
    private void Start()
    {
        createdTime = Time.time;
        parentPosition = transform.parent.position;
        transform.parent = null;
    }
    private void Update()
    {
        if(transform.position.y > -10)
        {
            transform.position = new Vector2(parentPosition.x + Mathf.Sin(waveSpeed * (createdTime - Time.time)) * wavaScale, parentPosition.y + createdTime - Time.time);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
