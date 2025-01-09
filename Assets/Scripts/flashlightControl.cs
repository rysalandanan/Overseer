using UnityEngine;

public class flashlightControl : MonoBehaviour
{
    [SerializeField] private float elevationSpeed;
    [SerializeField] private GameObject flashlight;
    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (flashlight != null) 
        {
            flashlight.transform.Rotate(Vector3.forward, -verticalInput * elevationSpeed * Time.deltaTime);
        }
    }
}
