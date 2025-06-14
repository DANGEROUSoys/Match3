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
        _colorVisual.sortingOrder = 0;
        _animalVisual.sortingOrder = 1;

        _pieceType = pieceType;
        _piecesConfig = new PiecesConfig();

        SetAnimalVisual(_piecesConfig.AnimalsDictionary[_pieceType.Animal]);
        SetColorVisual(_piecesConfig.ColorsDictionary[_pieceType.Color]);
        _colorVisual.material = new Material(_colorVisual.material);
    }

    private void SetAnimalVisual(Sprite sprite) => _animalVisual.sprite = sprite;
    private void SetColorVisual(Color32 color) => _colorVisual.color = color;

    public void MakeThisStatic()
    {
        _colorVisual.sortingOrder = 5;
        _animalVisual.sortingOrder = 6;

        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
