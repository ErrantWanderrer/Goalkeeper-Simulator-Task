using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public Image ProgressBar;
    public AudioSource GoalSound;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.tag = "NULL";
            ProgressBar.GetComponent<Image>().fillAmount -= 0.05f;
            GoalSound.Play();
        }
    }
}
