using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string comparetag = "";
    public new ParticleSystem particleSystem;
    public float timeToHide = .25f;
    public GameObject graphicItem;

    //[Header("Sounds")]
    //public AudioSource audioSource;

    private void Awake()
    {
       /* if (particleSystem != null) 
            particleSystem.transform.SetParent(null);*/
    }

    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.CompareTag(comparetag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
    }

    public void Hide()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke(nameof(HideObject), timeToHide);
    }

    protected virtual void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if(particleSystem != null){
            particleSystem.transform.SetParent(null);
            particleSystem.Play();
        } 
        /*if(audioSource != null) audioSource.Play();*/
    }
}
