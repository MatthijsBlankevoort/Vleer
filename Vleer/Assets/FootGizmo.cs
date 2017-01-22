using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
}
