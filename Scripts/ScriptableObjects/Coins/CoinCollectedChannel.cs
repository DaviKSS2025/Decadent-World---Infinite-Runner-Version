using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinCollectedChannel", menuName = "Scriptable Objects/CoinCollectedChannel")]
public class CoinCollectedChannel : ScriptableObject
{
    public Action CoinCollected;

    public void RaiseCoinCollected()
    {
        CoinCollected?.Invoke();
    }
}
