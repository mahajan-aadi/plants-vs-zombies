using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    AudioSource AudioSource;
    [SerializeField]Slider Volume_slider;
    [SerializeField] Slider Difficulty_slider;
    const float MIN_VOLUME = 0;
    const float MAX_VOLUME = 1;
    const float DEFAULT_VOLUME = 0.8f;
    const string VOLUME_KEY = "volume key";
    const float MIN_DIFFICULTY = 0;
    const float MAX_DIFFICULTY = 2;
    const float DEFAULT_DIFFICULTY = 0;
    const string DIFFICULTY_KEY = "Difficulty key";
    void set_volume(float volume) 
    {
        if(volume>=MIN_VOLUME && volume <= MAX_VOLUME) { PlayerPrefs.SetFloat(VOLUME_KEY, volume); }
    }
    void set_Difficulty(float Difficulty)
    {
        if (Difficulty >= MIN_DIFFICULTY && Difficulty <= MAX_DIFFICULTY) 
        { PlayerPrefs.SetFloat(DIFFICULTY_KEY, Difficulty); }
    }
    public static float _get_difficulty() { return PlayerPrefs.GetFloat(DIFFICULTY_KEY); }
    public static float _lower(float value) 
    {
        float lower = Options._get_difficulty() / 4 + 0.75f;
        value = value * lower;
        return value;
    }
    public static float _higher(float value)
    {
        float higher = Options._get_difficulty() * -1 / 4 + 1.25f;
        value = value * higher;
        return value;
    }
    float get_volume(){ return PlayerPrefs.GetFloat(VOLUME_KEY); }
    private void Start()
    {
        AudioSource = FindObjectOfType<Load_level>().GetComponent<AudioSource>();
        Volume_slider.value = get_volume();
        Difficulty_slider.value = _get_difficulty();
    }
    private void Update()
    {
        AudioSource.volume = Volume_slider.value;
    }
    public void _back()
    {
        set_volume(Volume_slider.value);
        set_Difficulty(Difficulty_slider.value);
        SceneManager.LoadScene(1);

    }
    public void _default_value()
    {
        Volume_slider.value = DEFAULT_VOLUME;
        Difficulty_slider.value = DEFAULT_DIFFICULTY;
    }


}
