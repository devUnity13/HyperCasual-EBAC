using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;
    [Header("Pieces")]
    public List<LevelPieceBasedSetup> levelSetups;
    public float timeBetweenPiece = .3f;
    [SerializeField] private int _index;
    private GameObject _currentLevel;
    [SerializeField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBasedSetup _currentSetup;

    private void Awake()
    {
        //SpawnNextLevel();
        //StartCoroutine(nameof(CreateLevelPiecesCoroutine));
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {

        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if (_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    #region Pieces

    private void CreateLevelPieces()
    {
        CleanSpawnPieces();

        if (_currentSetup != null)
        {
            _index++;

            if (_index >= levelSetups.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentSetup = levelSetups[_index];

        for (int i = 0; i < _currentSetup.piecesStartnumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPiecesStart);
        }

        for (int i = 0; i < _currentSetup.piecesnumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPieces);
        }

        for (int i = 0; i < _currentSetup.piecesEndnumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPiecesEnd);
        }
    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }
        _spawnedPieces.Add(spawnedPiece);
    }

    private void CleanSpawnPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    IEnumerator CreateLevelPiecesCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < _currentSetup.piecesnumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPieces);
            yield return new WaitForSeconds(timeBetweenPiece);
        }
    }

    #endregion;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //SpawnNextLevel();
            CreateLevelPieces();
        }
    }
}
