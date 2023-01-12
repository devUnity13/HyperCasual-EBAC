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

    //Variaveis privadas
    private Vector3 _pos;
    private Vector3 _startPosition;
    private float _startRadius;
    private bool _canRun = false;
    private float _currentSpeed;

    private void Start()
    {
        _startPosition = transform.position;
        _startRadius = collectableCoin.radius;
        ResetSpeed("");
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
                EndGame();
                Debug.Log("GameOver!");
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.transform.tag == TagFinish)
        {
            _canRun = false;
            EndGame();
            Debug.Log("Você Venceu!");
        }
    }
    public void StartGame()
    {
        _canRun = true;
        Screen[0].SetActive(false);
        if (Screen[1])
        {
            Screen[1].SetActive(false);
        }

    }

    public void EndGame()
    {
        Screen[1].SetActive(true);
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

    public void CollectAllCoins(float expand)
    {
        collectableCoin.radius += expand;
    }

    public void ResetCollectAllCoins()
    {
        collectableCoin.radius = _startRadius;
    }
}
