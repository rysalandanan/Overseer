using UnityEngine;

public class FlashlightController : MonoBehaviour
{

    [SerializeField] private float elevationSpeed;

    [SerializeField] private GameObject flashLight;
    private bool isOn = false;

    private void Start()
    {
        TurnOffFlashlight();
    }
    private void Update()
    {
        OnOffFlashLight();
        FlashlightElevation();
    }
    private void OnOffFlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn)
            {
                TurnOffFlashlight();
            }
            else
            {
                TurnOnFlashlight();
            }
        }
    }
    private void FlashlightElevation()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (flashLight != null)
        {
            flashLight.transform.Rotate(Vector3.forward, -verticalInput * elevationSpeed * Time.deltaTime);
        }
    }
    private void TurnOnFlashlight()
    {
        flashLight.SetActive(true);
        isOn = true;
    }
    private void TurnOffFlashlight()
    {
        flashLight.SetActive(false);
        isOn = false;
    }
}
