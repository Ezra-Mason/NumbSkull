using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private float _waitTime;

    public void LoadNextScene()
    {
        StartCoroutine(WaitToLoadNext());
    }

    public void ClickSound()
    {
        AudioManager.instance.Play("Thwump");
    }

    IEnumerator WaitToLoadNext()
    {
        yield return new WaitForSeconds(_waitTime);
        SceneManager.LoadScene(1);
    }


    public void LoadFirstScene()
    {
        StartCoroutine(WaitToLoadFirst());
    }

    IEnumerator WaitToLoadFirst()
    {
        yield return new WaitForSeconds(_waitTime);
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
