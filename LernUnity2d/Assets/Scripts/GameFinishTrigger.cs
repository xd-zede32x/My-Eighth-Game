using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishTrigger : MonoBehaviour
{
    private EndPoint[] _points;

    private void OnEnable()
    {
        _points = gameObject.GetComponentsInChildren<EndPoint>();

        foreach (var point in _points)
        {
            point.Reached += OnEndPointReached;
        }
    }

    private void OnDisable()
    {
        foreach (var point in _points)
        {
            point.Reached -= OnEndPointReached;
        }
    }

    private void OnEndPointReached()
    {
        foreach (var point in _points)
        {
            if (point.IsReached == false)
            {
                return;
            }
        }
        Debug.Log("Level Finish!");
        SceneManager.LoadScene(0);  
    }
}