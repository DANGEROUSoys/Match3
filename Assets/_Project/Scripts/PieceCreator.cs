using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PieceCreator : MonoBehaviour
{
    [SerializeField] private int _piecesCount;

    private PiecesConfig _config;
    private Coroutine _coroutine;

    [Inject]
    public void Construct(PiecesConfig config)
    {
        _config = config;
    }

    public void Start()
    {
        StartSpawnPieces();
    }

    private void StartSpawnPieces()
    {
        _coroutine = StartCoroutine(SpawnPieces());
    }
    private void StopSpawnPieces()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator SpawnPieces()
    {
        for (int i = 0; i < _piecesCount; i++)
        {
            Instantiate(_config.ShapesDictionary[Shapes.Sircle],transform);

            yield return new WaitForSeconds(0.025f);
        }
    }
}