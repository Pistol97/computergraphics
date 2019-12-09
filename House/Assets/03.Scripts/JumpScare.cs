using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject spawnMonster;
    public AudioSource jumpscare;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && RedBook.StartHorror == true)
        {
            spawnMonster.SetActive(true);
            jumpscare.Play();
            Destroy(gameObject, 1f);
        }
    }
}
