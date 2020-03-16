using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;

    PlayerController currentPlayerController;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.LogFormat("Collision: {0}", collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            var pc = currentPlayerController = collision.gameObject.GetComponent<PlayerController>();
            pc.enabled = false;
            Time.timeScale = 0;
            timeline.Play();
        }
    }


    public void EndTimeline()
    {
        GetComponent<Collider>().enabled = false;
        Destroy(this.gameObject, 1);
        Time.timeScale = 1;
        currentPlayerController.Start();
        currentPlayerController.enabled = true;
    }
}
