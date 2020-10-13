using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text = null;

    private static int coins;

    public void ChangeNumOfCoins(int delta)
    {
        coins += delta;
        text.text = coins.ToString();
    }
}
