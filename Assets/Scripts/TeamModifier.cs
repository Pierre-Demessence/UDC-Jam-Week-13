using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamModifier : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<Team>().Color = this.GetComponentInParent<Team>().Color;
    }
}
