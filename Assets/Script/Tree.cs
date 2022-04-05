using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    int cutNumberLeft = 5;
    bool isAxeInside = false;
    public AudioClip[] clips;
    public AudioSource source;
    public Animator animator;
    public int frameNumberDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frameNumberDelay > 0) frameNumberDelay--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (frameNumberDelay != 0) return;

        if (other.gameObject.tag == "Axe")
        {
            if (isAxeInside) return;

            isAxeInside = true;

            frameNumberDelay = 30;
            Cut();
            playRandomClip();
        }

    }
    void playRandomClip()
    {
        var randomClip = clips[Random.Range(0, clips.Length)];
        source.clip = randomClip;
        source.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        isAxeInside = false;
    }
    private IEnumerator destroyTree()
    {
        Player.Instance.GainAPoint();

        animator.SetTrigger("Destroyed");

        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    public void Cut()
    {
        StartCoroutine(Player.Instance.Vibrate());
        cutNumberLeft--;
        if (cutNumberLeft == 0)
        {
            StartCoroutine(destroyTree());
        }
    }
}
