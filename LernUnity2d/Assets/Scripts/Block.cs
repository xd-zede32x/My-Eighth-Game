using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void OnPointerClick(PointerEventData eventData)
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}