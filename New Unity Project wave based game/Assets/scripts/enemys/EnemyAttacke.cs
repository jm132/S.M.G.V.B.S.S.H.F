using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacke : MonoBehaviour
{

    public float damage = 5;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            healthSCRIPT Player = col.gameObject.GetComponent<healthSCRIPT>();
            if (Player != null)
            {
                Player.TakeDamage(damage);
            }
        }
    }
}
