using System;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IObserver
{
    [SerializeField] Text score;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;
    IObservable observable;
    public void AddObservable(IObservable observable)
    {
        this.observable = observable;
        observable.OnChanged += OnChanged;
    }

    private void OnChanged(object oldValue, object value)
    {
        score.text= value.ToString();
    }

    public void Dispose()
    {
        observable.OnChanged -= OnChanged;
    }

    public void Win()
    {
        Time.timeScale=0;
        winMenu.SetActive(true);
    }
    public void Lose()
    {
        Time.timeScale = 0;
        loseMenu.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
