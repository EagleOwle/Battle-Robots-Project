using UnityEngine;

[System.Serializable]
public class UIElementConfig
{
    public Font font = null;
    public Sprite windowSprite = null;
    public Sprite panelSprite = null;
    public Sprite buttonSprite = null;
    public Sprite toggleBackgroundSprite = null;
    public Sprite togglePointSprite = null;
    public Color colorNormal = Color.white;
    public Color colorHighlighted = Color.white;
    public Color colorPressed = Color.white;
    public Color colorDisabled = Color.white;
    public Color colorAlarm = Color.white;
    public Color colorText = Color.white;

    public AudioClip clickSound = null;
    public AudioClip enterSound = null;
    public AudioClip sliderSound = null;

}
