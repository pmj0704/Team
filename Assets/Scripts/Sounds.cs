using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private void Update()
    {
        AudioListener.volume = slider.value;
    }
}
