using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject;

public class PiecesGenerator
{
    private PiecesConfig _config;
    private List<PieceType> _pieceTypes;

    [Inject]
    public void Construct(PiecesConfig config)
    {
        _config = config;
    }

    public List<PieceType> GeneratePieces(int currentPieceCount)
    {
        _pieceTypes = new List<PieceType>();
        int countPiecesTypes = currentPieceCount / 3;

        for (int i = 0; i < countPiecesTypes; i++)
        {
            Shapes shape = (Shapes)Random.Range(0, _config.ShapesDictionary.Keys.Count);
            Animals animal = (Animals)Random.Range(0, _config.AnimalsDictionary.Keys.Count);
            Colors color = (Colors)Random.Range(0, _config.ColorsDictionary.Keys.Count);

            PieceType pieceType = new PieceType();
            pieceType.Initialize(shape, animal, color);
            for (int j = 0; j < 3; j++)
            {
                _pieceTypes.Add(pieceType);
            }
        }

        return _pieceTypes;
    }
}
