using UnityEngine;
public class Shooting : MonoBehaviour
{
    private void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        Debug.DrawRay(transform.position, transform.up * 5, Color.red);

        if (hit)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}