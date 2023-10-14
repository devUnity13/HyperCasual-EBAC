using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimationSetup> animatorSetup;
    private PlayerController playerController;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    private void Start()
	{
        transform.DOScale(1, 1f).SetEase(Ease.Linear);
        playerController = GameObject.
            Find("PlayerContainer").
            GetComponent<PlayerController>();
	}

    public void EndGameEvent()
    {
        playerController.EndGame();
		playerController.Screen[1].SetActive(true);
	}
	public enum AnimationType
    {
        run,
        idle,
        death,
        finish
    }

    public void Play(AnimationType type, float currentFactor = 1f)
    {
        foreach(var animation in animatorSetup)
        {
            if(animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentFactor;
                break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.run);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimationType.idle);
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimationType.death);
        }
    }
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationManager.AnimationType type;
    public string trigger;
    public float speed;
}
