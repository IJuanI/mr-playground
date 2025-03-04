using UnityEngine;

public class PlaySoundByAnim : MonoBehaviour
{
    [SerializeField]AudioSource source;

    public void PlayInAnim()
    {
        source.Play();
    }
}
