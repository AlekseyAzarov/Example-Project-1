using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class ChestScript : MonoBehaviour
{
    [SerializeField] private GameObject coin = null;
    private Wallet wallet;

    private void Start()
    {
        wallet = FindObjectOfType<Wallet>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            GetComponent<Animator>().SetBool("IsPlayerNear", true);
            coin.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            GetComponent<Animator>().enabled = true;
            coin.SetActive(true);
            wallet.ChangeNumOfCoins(1);
        }
    }
}
