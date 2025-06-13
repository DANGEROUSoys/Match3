using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInput : MonoBehaviour
{
    private Coroutine _coroutine;

    private void OnEnable()
    {
        PieceCreator.OnSpawnPiecesFinished += StartPlayerInput;
        PieceCreator.OnSpawnPiecesStarted += StopPlayerInput;
    }
    private void OnDisable()
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
                        Destroy(piece.gameObject);
                    }
                }
            }
            yield return null;
        }
    }
}
