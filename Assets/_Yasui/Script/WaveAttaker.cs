using UnityEngine;

public class WaveAttaker : MonoBehaviour
{
    [SerializeField] private bool isShoot = true;
    [SerializeField] private GameObject wave;
    [SerializeField] private float shootIntervalTime = 0.2f;
    private float time;


    private void Start()
    {
        if(wave == null)
        {
            Debug.LogError("wave‚ªƒZƒbƒg‚³‚ê‚Ä‚¢‚È‚¢");
        }
    }
    private void Update()
    {
        if (wave != null)
        {
            if (isShoot)
            {
                if (time > shootIntervalTime)
                {
                     GameObject obj = Instantiate(wave, transform.position, Quaternion.identity);
                    obj.transform.SetParent(transform);
                    time = 0;
                }
                time += Time.deltaTime;
            }
        }
    }
}
