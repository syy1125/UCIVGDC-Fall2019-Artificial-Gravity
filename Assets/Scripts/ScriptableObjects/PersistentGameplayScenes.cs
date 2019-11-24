using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Scriptable Objects/Persistent Gameplay Scenes", fileName = "Persistent Gameplay Scenes")]
public class PersistentGameplayScenes : ScriptableObject
{
	[FormerlySerializedAs("PersistentScenes")] public string[] SceneNames;
}