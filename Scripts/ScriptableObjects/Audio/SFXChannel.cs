using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/AudioChannel")]
public class SFXChannel : ScriptableObject
{
    public event Action<SimpleAudioEvent> OnSFXRequested;

    public void RaiseEvent(SimpleAudioEvent sfxEvent)
    {
        OnSFXRequested?.Invoke(sfxEvent);
    }
}
