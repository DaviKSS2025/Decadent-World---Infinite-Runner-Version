using UnityEngine;

[CreateAssetMenu(fileName = "TargetScene", menuName = "Scriptable Objects/TargetScene")]
public class TargetScene : ScriptableObject
{
    [SerializeField] private string _sceneName;

    public string SceneName
    {
        get => _sceneName;
    }
}
