using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerInput : MonoBehaviour,IInitializable,IDisposable
{
    public static Action<Piece> OnPieceTaked;

    private Coroutine _coroutine;

    [Inject]
    public void Construct()
    {

    }

    public void Initialize()
    {
        PieceCreator.OnSpawnPiecesFinished += StartPlayerInput;
        PieceCreator.OnSpawnPiecesStarted += StopPlayerInput;
    }

    public void Dispose()
    {
        PieceCreator.OnSpawnPiecesFinished -= StartPlayerInput;
        PieceCreator.OnSpawnPiecesStarted -= StopPlayerInput;
    }

    private void StartPlayerInput()
    {
        _coroutine = StartCoroutine(PlayerInputUpdate());
    }
    private void StopPlayerInput()
    {
        if( _coroutine != null ) StopCoroutine(_coroutine);
    }

    private IEnumerator PlayerInputUpdate()
    {
        while (true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Ended)
                {
                    Vector3 touchPosition = touch.position;
                    touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);

                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                    if (hit.collider != null && hit.collider.TryGetComponent<Piece>(out Piece piece))
                    {
                        OnPieceTaked?.Invoke(piece);
                        piece.MakeThisStatic();
                    }
                }
            }
            yield return null;
        }
    }
}
