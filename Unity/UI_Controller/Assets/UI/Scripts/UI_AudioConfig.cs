using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AudioConfig : MonoBehaviour
{
    [Header("Компонент Slider для регулировки громкости звука")]
    public Slider AudioValumeSlider;

    private void OnEnable()
    {
        AudioValumeSlider.value = UI_Controller.Singleton.audioSource.volume * 100;
    }

    public void SliderValueChange()
    {
        UI_Controller.Singleton.audioSource.volume = AudioValumeSlider.value * 0.01f;
    }
}
