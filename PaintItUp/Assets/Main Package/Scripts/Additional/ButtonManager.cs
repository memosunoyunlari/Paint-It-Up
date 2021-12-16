using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject paintAmountUI;
    [SerializeField] GameObject firstPanel;
    [SerializeField] GameObject Boy;
    MovementManager moveManager;

    private void Awake()
    {
        moveManager = Boy.GetComponent<MovementManager>();
    }
    public void StartTheGame()
    {
        paintAmountUI.SetActive(true);
        moveManager.enabled = true;
        firstPanel.SetActive(false);
    }

    public void PlayAgain()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
