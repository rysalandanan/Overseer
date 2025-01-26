using UnityEngine;

public class ShowGuidelines : MonoBehaviour
{
    [SerializeField] private GameObject[] controlGuide;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            ShowGuide();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            HideGuide();
        }
    }

    private void ShowGuide()
    {
        if(controlGuide.Length > 0)
        {
            for(int i = 0; i < controlGuide.Length; i++)
            {
                controlGuide[i].SetActive(true);
                PauseGame();
            }
        }
    }
    private void HideGuide()
    {
        if(controlGuide.Length > 0)
        {
            for (int i = 0; i < controlGuide.Length; i++)
            {
                controlGuide[i].SetActive(false);
                UnpauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }
    private void UnpauseGame()
    {
        Time.timeScale = 1f;
    }
    

}
