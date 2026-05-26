using UnityEngine;

public class StopTemporarilyAttacker : MonoBehaviour
{
    private bool stopTemporarily = true;
    [SerializeField] private GameObject stopBullet;
    private void Update()
    {
        if (stopTemporarily)
        {
            if (transform.childCount < 10)
            {
                Instantiate(stopBullet, transform.position, Quaternion.identity, transform);
            }
            else
            {
                stopTemporarily = false;
            }
        }else if(transform.childCount == 0)
        {
            stopTemporarily = true;
        }
    }
}
