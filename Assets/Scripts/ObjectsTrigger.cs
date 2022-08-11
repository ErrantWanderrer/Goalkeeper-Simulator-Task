using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsTrigger : MonoBehaviour
{
    public Image ProgressBar;
    public Text CoinText;
    public GameObject Player;
    public AudioSource CoinsSound;
    public AudioSource BombSound;
    public GameObject Explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.tag = "NULL";
            ProgressBar.GetComponent<Image>().fillAmount += 0.01f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.tag = "NULL";
            CoinsSound.Play();
            Player.GetComponent<PlayerController>().coinsEarn += 1;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            CoinText.text = Player.GetComponent<PlayerController>().coinsEarn.ToString();
        }
        else if (other.gameObject.tag == "Bomb")
        {
            other.gameObject.tag = "NULL";
            BombSound.Play();
            ProgressBar.GetComponent<Image>().fillAmount -= 0.2f;
            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        }
    }
}
