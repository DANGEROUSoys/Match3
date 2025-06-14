using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ActionBar : MonoBehaviour, IInitializable,IDisposable
{
    [SerializeField] private Transform[] _barsPlaces;

    private int _maxPiecesInBar;
    private List<Piece> _piecesInBar;

    [Inject]
    public void Construct()
    {
        _piecesInBar = new List<Piece>();
    }

    public void Initialize()
    {
        _maxPiecesInBar = _barsPlaces.Length;

        PlayerInput.OnPieceTaked += GetPiece;
    }

    public void Dispose()
    {
        PlayerInput.OnPieceTaked -= GetPiece;
    }

    private void GetPiece(Piece piece)
    {
        if (ThereIsThisPieceType(piece))
        {

        }
        else
        {
            _piecesInBar.Add(piece);
            int currentIndex = _piecesInBar.Count - 1;
            piece.transform.position = _barsPlaces[currentIndex].transform.position;
        }
    }

    private bool PiecesAreSame(Piece piece1, Piece piece2)
    {
        if(piece1.Type.Shape == piece2.Type.Shape)
        {
            if (piece1.Type.Animal == piece2.Type.Animal)
            {
                if (piece1.Type.Color == piece2.Type.Color)
                {
                    return true;
                }
            }
        }
        return false;
    }
    private bool ThereIsThisPieceType(Piece newpiece)
    {
        foreach (var piece in _piecesInBar)
        {
            if(PiecesAreSame(piece, newpiece))
            {
                return true;
            }
        }
        return false;
    }
}
