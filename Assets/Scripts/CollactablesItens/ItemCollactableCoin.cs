using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider coll;
    public SphereCollider playerController;
    public bool collect = false;
    public float timeLerp = 1f;
    public float distanceDifference = 10;

    private void Start()
    {
        playerController = GameObject.Find("CollectorCoin").GetComponent<SphereCollider>();
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        coll.enabled = false;
        collect = true;
    }

    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {

        if (collect)
        {
            LerpCoins();
        }
    }

    protected virtual void LerpCoins()
    {
        transform.position = Vector3.Lerp(transform.position, playerController.transform.position, timeLerp * Time.deltaTime);
        if(Vector3.Distance(transform.position, playerController.transform.position) < distanceDifference)
        {
            Hide();
        }
    }
}
