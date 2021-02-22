using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayParticale : MonoBehaviour
{
    public ParticleSystem Effect;

    public void StartEffect()
    {
        StartCoroutine(playEffectAfterTime());

    }
    IEnumerator playEffectAfterTime()
    {
        yield return new WaitForSeconds(0);
        Effect.Play();

    }
}