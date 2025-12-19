using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay = 2f;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AllOrbsSpawned()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            StartCoroutine(LoadLevel2());
        }
        else
        {
            StartCoroutine(LoadWin());
        }
    }

    IEnumerator LoadLevel2()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level2");
    }

    IEnumerator LoadWin()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Win");
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverDelay());
    }

    IEnumerator LoadGameOverDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }
}