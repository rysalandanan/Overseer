using System.Collections;
using UnityEngine;

public class ConsoleManager : MonoBehaviour
{
    [SerializeField] private GameObject consolePanel;
    [SerializeField] private Animator consoleAnimator;
    [SerializeField] private GameObject idleBalls;
    private bool isOpen = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isOpen)
            { 
                PlayEnterConsoleAnimation();
            }
            else
            {
                CloseConsole();
            }
        }
    }
    private void PlayEnterConsoleAnimation()
    {
        if (consoleAnimator != null)
        {
            consoleAnimator.SetBool("isUsingConsole", true);
            StartCoroutine(OpenConsole());
        }
    }
    private IEnumerator OpenConsole()
    {
        isOpen = true;
        yield return new WaitForSeconds(1);
        if(idleBalls != null && consolePanel != null)
        {
            DeactivateIdleBalls();
            consolePanel.SetActive(true);
        }
    }
    private void CloseConsole()
    {
        isOpen = false;
        if(idleBalls != null && consolePanel != null)
        {
            ActivateIdleBalls();
            consolePanel.SetActive(false);
            PlayExitConsoleAnimation();
        }
    }
    private void PlayExitConsoleAnimation()
    {
        if (consoleAnimator != null)
        {
            consoleAnimator.SetBool("isUsingConsole", false);
        }
    }
    private void ActivateIdleBalls()
    {
        idleBalls.SetActive(true);
    }
    private void DeactivateIdleBalls()
    {
        idleBalls.SetActive(false);
    }
}
