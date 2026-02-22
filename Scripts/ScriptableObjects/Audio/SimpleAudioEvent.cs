using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioEvent", menuName = "Audio/Simple Audio Event")] 
public class SimpleAudioEvent : ScriptableObject 
{ 
    public AudioClip[] clips; 
    public Vector2 pitchRange = new Vector2(0.8f, 1.2f); 
    [Range(0, 1)] public float volume = 1f; 
    public void Play(AudioSource source) 
    { 
        if (clips.Length == 0) return;
        //Random pitch for game feel
        source.pitch = UnityEngine.Random.Range(pitchRange.x, pitchRange.y); 
        source.PlayOneShot(clips[UnityEngine.Random.Range(0, clips.Length)], volume); 
    } 
}