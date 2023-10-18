using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();

    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }

    public bool IsReached { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsReached)
        {
            return;
        }

        if (collision.TryGetComponent<PlayerManager>(out PlayerManager player))
        {
            IsReached = true;
            _reached .Invoke();
        }
    }
}   