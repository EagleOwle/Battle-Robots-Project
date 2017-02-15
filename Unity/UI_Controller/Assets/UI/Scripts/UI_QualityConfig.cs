using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QualityConfig : MonoBehaviour
{
    public Slider slider;

    public GameObject waitPanel;

    private void OnEnable()
    {
        slider.value = QualitySettings.GetQualityLevel();
        waitPanel.SetActive(false);
    }

    public void SliderValueChange()
    {
        waitPanel.SetActive(true);
        StartCoroutine("Wait");
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        QualitySettings.SetQualityLevel((int)slider.value);
        waitPanel.SetActive(false);
    }
}
