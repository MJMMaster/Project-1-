using UnityEngine;
using System.Collections;
public class PlayerDeath : Death
{
    public SoundManager soundManager; // drag your SoundManager here in the Inspector
    public override void Die()

    {
        StartCoroutine(PlayDeathSoundDelayed());
    }

private IEnumerator PlayDeathSoundDelayed()
    {
        yield return new WaitForSeconds(1f);
        soundManager.PlayDeathSound();
        yield return new WaitForSeconds(1.1f);
        GameManager.Instance.PlayerDied();
        yield return new WaitForSeconds(1.1f); // adjust to your sound length
        Destroy(gameObject);

    }
}

   

