using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;
    [SerializeField] private Text _textClose;

    private float _respawnTime = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerManager playerManager))
        {
            _event?.Invoke();
            Destroy(collision.collider.gameObject);
            _textClose.text = "GameOver";

            StartCoroutine(WaitAndReloadScene());
        }
    }

    IEnumerator WaitAndReloadScene()
    {
        yield return new WaitForSeconds(_respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}