using UnityEngine;

public class TeamModifier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<Team>().Color = GetComponentInParent<Team>().Color;
    }
}