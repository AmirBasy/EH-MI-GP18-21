using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerOnStart : MonoBehaviour
{
    public MusicGroup group;

    // Start is called before the first frame update
    void OnEnable()
    {
        BackgroundMusicManager.instance.Play(group);
    }

    
}
