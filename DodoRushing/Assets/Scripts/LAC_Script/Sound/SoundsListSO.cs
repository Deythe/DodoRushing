using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundListSO", menuName = "SoundTool/SoundListSO", order = 0)]
public class SoundsListSO : ScriptableObject
{
    public SoundInfo[] sounds;

    public SoundInfo FindSound(string soundName)
    {
        foreach (SoundInfo s in sounds)
        {
            if (s.clipName == soundName) return s;
        }
        
        Debug.Log("No sound named " + soundName + ".");
        return null;
    }
}

[System.Serializable]
public class SoundInfo
{
    public string clipName;
    public AudioClip clip;
    public AudioMixerGroup audioMixerGroup;
    public bool loop;
    [Range(0,1)]
    public float clipVolume = 1;
    public float minPitch = -0.1f, maxPitch = 0.1f;

}


