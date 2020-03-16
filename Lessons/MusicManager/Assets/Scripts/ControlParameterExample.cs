using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class ControlParameterExample : MonoBehaviour
{
    public AudioMixer mixer;
    public string parameter;

   
    // Update is called once per frame
    public void SetParameter(Slider slider)
    {
        mixer.SetFloat(parameter, slider.value);
    }
}
