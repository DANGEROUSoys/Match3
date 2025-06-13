using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PieceCreator : MonoBehaviour
{
    public static Action OnSpawnPiecesStarted;
    public static Action OnSpawnPiecesFinished;

    [SerializeField,Range(3,75)] private int _piecesCount;
    private List<PieceType> _currentPiecesTypes;

    private PiecesConfig _config;
    private PiecesGenerator _piecesGenerator;
    private Coroutine _coroutine;

    [Inject]
    public void Construct(PiecesGenerator piecesGenerator)
    {
        _config = new PiecesConfig();
        _piecesGenerator = piecesGenerator;
    }

    private void Start() //Initialize
    {
        _currentPiecesTypes = _piecesGenerator.GeneratePieces(_piecesCount);
        //Заносим в Data
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
        OnSpawnPiecesStarted?.Invoke();
        int piecesTypesCount = _currentPiecesTypes.Count;
        for (int i = 0; i < piecesTypesCount; i++)
        {
            PieceType pieceType = _currentPiecesTypes[UnityEngine.Random.Range(0,_currentPiecesTypes.Count)];
            Piece piece = Instantiate(_config.ShapesDictionary[pieceType.Shape],transform).GetComponent<Piece>();
            piece.Initialize(pieceType);
            _currentPiecesTypes.Remove(pieceType);

            yield return new WaitForSeconds(0.025f);
        }

        OnSpawnPiecesFinished?.Invoke();
    }

    private void OnValidate()
    {
        if(_piecesCount % 3 != 0)
        {
            _piecesCount = _piecesCount - _piecesCount % 3;
        }
    }
}