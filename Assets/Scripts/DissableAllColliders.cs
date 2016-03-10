using UnityEngine;
using System.Collections;

public class DissableAllColliders : MonoBehaviour
{
    private GameObject[] potColliders;

    void Awake()
    {
        potColliders = GameObject.FindGameObjectsWithTag("Pot");
    }

    void OnEnable()
    {
        for (int i = 0; i < potColliders.Length; i++)
        {
            potColliders[i].GetComponent<Collider2D>().enabled = false;
        }
    }
    void OnDisable()
    {
        for (int i = 0; i < potColliders.Length; i++)
        {
            potColliders[i].GetComponent<Collider2D>().enabled = true;
        }
    }
}
