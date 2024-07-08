using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class UIImageSwitch : MonoBehaviour
{
    public float Volume;
    public Slider VolumeSlider;
    public Sprite VolumeIcon;
    public Sprite MuteIcon;

    public void VolChange()
    {
        Volume = VolumeSlider.value;

        if (Volume <= 0)
        {
            GetComponent<Image>().sprite = MuteIcon;
        }

        else if (Volume > 0)
        {
            GetComponent<Image>().sprite = VolumeIcon;
        }
    }
}
