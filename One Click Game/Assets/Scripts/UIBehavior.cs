using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIBehavior : MonoBehaviour
{
    public GameObject titleP, gameP, deathP, player;

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        titleP.SetActive(false);
        gameP.SetActive(true);
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
