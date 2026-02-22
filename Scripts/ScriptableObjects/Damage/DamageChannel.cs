using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageChannel", menuName = "Scriptable Objects/DamageChannel")]
public class DamageChannel : ScriptableObject
{
    public Action PlayerDamaged;

    public void RaisePlayerDamaged()
    {
        PlayerDamaged?.Invoke();
    }
}
