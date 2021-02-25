using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour, IPowerup
{
    private void Start()
    {
        OnSpawn();
    }
    public void OnSpawn()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider hit in colliders)
        {
            if(hit.gameObject.tag == "Player")
            {
                hit.gameObject.GetComponent<PlayerController>().speed += 1000;
                StartCoroutine(RemoveSpeed(hit));
            }


        }
    }
    IEnumerator RemoveSpeed(Collider hit)
    {
        yield return new WaitForSeconds(10);
        hit.gameObject.GetComponent<PlayerController>().speed -= 1000;
        Destroy(this.gameObject);
    }
}
