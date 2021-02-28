using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_level : MonoBehaviour
{
    private int current_index;
    [SerializeField] GameObject win_canvas, lose_canvas;
    void Start()
    {
        win_canvas.SetActive(false);
        lose_canvas.SetActive(false);
        current_index = SceneManager.GetActiveScene().buildIndex;
        if (current_index == 0) { StartCoroutine(waiting()); }
        GetComponent<AudioSource>().Play();

    }
    public void _quit() { Application.Quit(); }
    private void Awake()
    {
        Load_level[] amount = FindObjectsOfType<Load_level>();
        if (amount.Length > 1){ Destroy(this.gameObject); }
        else { DontDestroyOnLoad(this.gameObject); }
    }
    IEnumerator waiting()
    {
        yield return (new WaitForSecondsRealtime(1f));
        Time.timeScale = 1;
        win_canvas.SetActive(false);
        _load_next();
    }
    public void _load_next() 
    {
        current_index=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_index + 1);
    }
    public void _options() { SceneManager.LoadScene("Options"); }

    IEnumerator restart_level()
    {
        Time.timeScale=1;
        lose_canvas.SetActive(false);
        current_index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("lost");
        yield return (new WaitForSeconds(5f));
        SceneManager.LoadScene(current_index);
    }
    public void _restart() { StartCoroutine(restart_level()); }
    public void _lose() 
    {
        Time.timeScale=0; 
        lose_canvas.SetActive(true);
        FindObjectOfType<level_handler>()._level_lost();
    }
    public void _win() 
    {
        Time.timeScale = 0;
        win_canvas.SetActive(true);
        StartCoroutine(waiting());
    }
    public void _main_menu()
    { 
        Time.timeScale = 1;
        lose_canvas.SetActive(false);
        SceneManager.LoadScene("Start");
    }

}
