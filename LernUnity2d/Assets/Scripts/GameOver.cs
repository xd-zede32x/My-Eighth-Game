using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;
    [SerializeField] private Text _textClose;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out FreeWayChecker playerManager))
        {
            _event?.Invoke();
            Destroy(collision.collider.gameObject);
            _textClose.text = "GameOver";

            StartCoroutine(WaitAndReloadScene());
        }
    }

    public IEnumerator WaitAndReloadScene(float _respawnTime = 1.5f)
    {
        var restartScene = new WaitForSeconds(_respawnTime);

        yield return restartScene;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}