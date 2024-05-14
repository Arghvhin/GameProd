using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    public Animator JumpScareanim;
    public GameObject player;
    public float jumpscareTime;
    public string sceneName;
    public AudioClip scareSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = scareSound;
            audioSource.loop = true;
            audioSource.volume = 0.4f;
            audioSource.Play();
            player.SetActive(false);
            JumpScareanim.SetTrigger("jumpscare");
            StartCoroutine(jumpscare());
        }
    }
    IEnumerator jumpscare()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneName);
    }
}
