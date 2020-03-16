using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PausaController : MonoBehaviour
{
    public GameObject pausePanel;

    public AudioMixerSnapshot pauseOn, pauseOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1;
                pauseOff.TransitionTo(3);
            }
            else
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                pauseOn.TransitionTo(3);
            }
        }
    }
}
