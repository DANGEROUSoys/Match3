using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Piece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _animalVisual;
    [SerializeField] private SpriteRenderer _colorVisual;

    private PiecesConfig _piecesConfig;

    private PieceType _pieceType;
    public PieceType Type => _pieceType;

    public void Initialize(PieceType pieceType)
    {
        _pieceType = pieceType;
        _piecesConfig = new PiecesConfig();

        SetAnimalVisual(_piecesConfig.AnimalsDictionary[_pieceType.Animal]);
        SetColorVisual(_piecesConfig.ColorsDictionary[_pieceType.Color]);
        _colorVisual.material = new Material(_colorVisual.material);
    }

    private void SetAnimalVisual(Sprite sprite) => _animalVisual.sprite = sprite;
    private void SetColorVisual(Color32 color) => _colorVisual.color = color;
}
