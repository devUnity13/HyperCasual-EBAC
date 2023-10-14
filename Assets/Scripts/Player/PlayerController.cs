using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    //Variaveis publicas
    public Transform target;
    public float speed = 1f;
    public float lerpSpeed = 1f;
    public string tagEnemy = "Enemy";
    public string TagFinish = "Finish";
    public GameObject[] Screen;
    public bool invencible = false;
    public TextMeshProUGUI textPowerUp;
    public SphereCollider collectableCoin;
    public AnimationManager animatorManager;

    [SerializeField]private BounceHelper _bouceHelper;

    //Variaveis privadas
    private Vector3 _pos;
    private Vector3 _startPosition;
    private float _startRadius;
    public bool _canRun = false;
    private float _currentSpeed;
    private float _baseSpeedToAnimation = 7;

	private void Start()
    {
        _startPosition = transform.position;
        _startRadius = collectableCoin.radius;
		animatorManager = GameObject.Find("ANIM_Astronaut_Idle").GetComponent<AnimationManager>();
		animatorManager.Play(AnimationManager.AnimationType.idle);
		ResetSpeed("");
    }

    public void Bounce()
    {
        if(_bouceHelper != null)
            _bouceHelper.Bounce();
    }

    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagEnemy)
        {
            if (!invencible)
            {
                _canRun = false;
                MoveBack();
				EndGame(AnimationManager.AnimationType.death);
				Debug.Log("GameOver!");
				Screen[1].SetActive(true);
			}
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.transform.tag == TagFinish)
        {
            _canRun = false;
            EndGame(AnimationManager.AnimationType.finish);
			Debug.Log("Voc� Venceu!");
        }
    }

    private void MoveBack()
    {
        transform.DOMoveZ(-1f, .3f).SetRelative();
    }
    public void StartGame()
    {
        _canRun = true;
		animatorManager.Play(AnimationManager.AnimationType.run, _currentSpeed / _baseSpeedToAnimation);
		Screen[0].SetActive(false);
        if (Screen[1])
        {
            Screen[1].SetActive(false);
        }
	}

    public void EndGame(AnimationManager.AnimationType aniimationType = AnimationManager.AnimationType.idle)
    {
        animatorManager.Play(aniimationType);
    }

    public void IncreaseSpeed(string status, float amount)
    {
        _currentSpeed = amount;
        textPowerUp.text = status;
    }

    public void ResetSpeed(string status)
    {
        _currentSpeed = speed;
        textPowerUp.text = status;
    }

    public void ResetInvencible(string status)
    {
        textPowerUp.text = status;
    }

    public void SetInvencible(string status, bool b = true)
    {
        invencible = b;
        textPowerUp.text = status;
    }

    public void SetHeigth(string status, float amountHeigth, float duration, float animDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amountHeigth;
        transform.position = p;*/

        textPowerUp.text = status;
        transform.DOMoveY(_startPosition.y + amountHeigth, animDuration).SetEase(ease);
        //Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(string status, float animDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;*/

        textPowerUp.text = status;
        transform.DOMoveY(_startPosition.y, animDuration).SetEase(ease);
    }

    public void CollectAllCoins(string status, float expand)
    {
        textPowerUp.text = status;
        collectableCoin.radius += expand;
    }

    public void ResetCollectAllCoins()
    {
        textPowerUp.text = "";
        collectableCoin.radius = _startRadius;
    }
}
