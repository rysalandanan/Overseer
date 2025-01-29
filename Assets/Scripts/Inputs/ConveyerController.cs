using UnityEngine;

public class ConveyerController : MonoBehaviour
{
    [SerializeField] private SurfaceEffector2D surfaceEffector;
    [SerializeField] private GameObject redAlarm;
    [SerializeField] private GameObject blueAlarm;
    [SerializeField] private PrefabSpawner prefabSpawner;

    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StopConveyer();

        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartConveyer();
        }
    }
    private void StopConveyer()
    {
        surfaceEffector.speed = 0f;
        blueAlarm.SetActive(false);

        redAlarm.SetActive(true);
        StopProduction();
    }

    private void StartConveyer()
    {
        surfaceEffector.speed = 1f;
        redAlarm.SetActive(false);

        blueAlarm.SetActive(true);
        StartProduction();
    }
    
    private void StopProduction()
    {
        prefabSpawner.PauseProduction();
    }
    private void StartProduction()
    {
        prefabSpawner.ResumeProduction();
    }
}
