using UnityEngine;

public class WaveAttaker : MonoBehaviour
{
    [SerializeField] private bool isShoot = true;
    [SerializeField] private GameObject wave;
    private float time;

    private void Update()
    {
        if (wave != null)
        {
            if (isShoot)
            {
                if (time > 0.5)
                {
                    Instantiate(wave, transform.position, Quaternion.identity);
                    time = 0;
                }
                time += Time.deltaTime;
            }
        }
    }
}
