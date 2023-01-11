using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    //Variaveis publicas
    public Transform target;
    public float speed = 1f;
    public float lerpSpeed = 1f;
    public string tagEnemy = "Enemy";
    public string TagFinish = "Finish";
    public GameObject[] Screen;

    //Variaveis privadas
    private Vector3 _pos;
    private bool _canRun = false;

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagEnemy)
        {
            _canRun = false;
            EndGame();
            Debug.Log("GameOver!");
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
}
