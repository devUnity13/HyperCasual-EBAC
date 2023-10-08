using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;
    public float duration = 1f;
    private int _index = 0;

    private PlayerController _playerController;
    private void Start()
    {
        var initialPosition = Random.Range(0, positions.Count);
        transform.position = positions[initialPosition].position;

        NextIndex();
        StartCoroutine(StartMovement());
    }

    void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }

    IEnumerator StartMovement()
    {
        float time = 0;
        while (true)
        {
            var currentPosition = transform.position;

            while (time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].position, (time / duration));

                time += Time.deltaTime;
                yield return null;
            }
            NextIndex();
            time = 0;

            yield return null;
        }
    }
}
