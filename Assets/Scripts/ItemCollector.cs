using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coinCount = 0;
    [SerializeField] Text coinsText;

    [SerializeField] AudioSource coinSound;
    // on collision enter won't work because isTrigger is enabled
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCount++;
            coinsText.text="Coins: "+coinCount;
            coinSound.Play();
        }
    }
}
