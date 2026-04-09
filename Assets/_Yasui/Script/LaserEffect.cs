using UnityEngine;

public class LaserEffect : MonoBehaviour
{
    private Vector3 direct;
    private Vector3 velocity = Vector3.zero; //SmoothDamp‚Ì‘æ3ˆø”iŒ»İ‚Ì‘¬“xj
    private void Start()
    {
        direct = transform.parent.parent.GetComponent<LaserPathEffect>().endPosition;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, direct) > 1f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, direct, ref velocity, 0.02f);
        }

    }
}
