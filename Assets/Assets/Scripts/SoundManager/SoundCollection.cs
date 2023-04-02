using UnityEngine;

[CreateAssetMenu(menuName = "SoundManager/AddSounds",fileName ="SoundCollection")]
public class SoundCollection : ScriptableObject
{
    public AudioClip[] angry;
    public AudioClip[] happy;
    public AudioClip[] satisfied;
    public AudioClip[] notSatisfied;
    public AudioClip[] interaction;
    public AudioClip[] askingForPannerTikka,askingForSamosa,askingForTea,askingForPakori;



}
