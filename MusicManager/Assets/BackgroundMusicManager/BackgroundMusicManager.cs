using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{

    public MusicGroupCollection[] musics;
    public AudioSource a, b;

    public static BackgroundMusicManager instance;

    enum State { Stopped, Playing, Play,  Stopping  };
    State state = State.Stopped;

    /// <summary>
    /// the currently playing music source
    /// </summary>
    AudioSource currentAudioSource;

    /// <summary>
    /// the currently next music source
    /// </summary>
    AudioSource currentNextAudioSource;

    public float fadeTime = 4;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play(MusicGroup group)
    {
        var clip = GetRandomClipFromGroup(group);
        if (clip == null) return;

        StopAllCoroutines();
        StartCoroutine(AsynchPlay(clip));        
    }

    IEnumerator AsynchPlay(AudioClip clip)
    {
        switch (state)
        {
            case State.Stopped:

                // fade in
                currentAudioSource = a;
                currentAudioSource.volume = 0;
                currentAudioSource.clip = clip;
                currentAudioSource.Play();

                state = State.Playing;
                yield return AsyncFade(currentAudioSource, volumeTo:1);
                state = State.Play;

                break;


            case State.Play:

                // if the song is the same -> do nothing
                if (currentAudioSource.clip == clip) yield break;

                // else
                // fade out current
                state = State.Stopping;
                yield return AsyncFade(currentAudioSource, volumeTo: 0);
                
                // fade in new
                state = State.Playing;
                currentAudioSource.clip = clip;
                //currentAudioSource.Play();
                yield return AsyncFade(currentAudioSource, volumeTo: 1);
                state = State.Play;

                break;

            case State.Playing:
            case State.Stopping:

                // if the song is the same -> 
                if (currentAudioSource.clip != clip)
                {
                    // fade out current
                    state = State.Stopping;
                    yield return AsyncFade(currentAudioSource, volumeTo: 0);
                    state = State.Stopped;
                    currentAudioSource.clip = clip;
                    currentAudioSource.Play();
                }

                state = State.Playing;
                yield return AsyncFade(currentAudioSource, volumeTo: 1);
                state = State.Play;

                break;

            default:

#if UNITY_EDITOR
                Debug.LogErrorFormat("Error: state {0} not implemented", state);
#endif

                break;
        }

        yield break;
    }

    public bool useRealtime=false;
    public float currentTime => useRealtime ? Time.realtimeSinceStartup : Time.time;

    /// <summary>
    /// Fade an audiosource
    /// </summary>
    /// <param name="source"> Audio source target</param>
    /// <param name="volumeTo">Target volume to fade to</param>
    /// <returns></returns>
    IEnumerator AsyncFade(AudioSource source, float volumeTo )
    {
        float from = source.volume;
        float fadeTimeProportional = fadeTime * Mathf.Abs(volumeTo - from);

        float startTime = currentTime;
        float ratio = 0;
        while (ratio<1)
        {
            ratio = Mathf.Clamp01((currentTime - startTime) / fadeTimeProportional);
            source.volume = Mathf.Lerp(from, volumeTo, ratio);
            yield return 0;
        }
    }

    public AudioClip GetRandomClipFromGroup(MusicGroup group)
    {
        foreach (var musicCollection in musics)
        {
            if (musicCollection.group == group)
            {
                int random = Random.Range(0, musicCollection.clips.Length);
                return musicCollection.clips[random];
            }
        }

#if UNITY_EDITOR
        Debug.LogErrorFormat("Error: group music {0} not found", group.name);
#endif


        return null;
    }

}
