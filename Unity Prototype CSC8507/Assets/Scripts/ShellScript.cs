using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour, IPowerup
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float counter;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        OnSpawn();
    }

    public void OnSpawn()
    {
        var forward = this.transform.forward;
        rb.AddForce(forward * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter >= 3)
        {
            Destroy(this.gameObject);
        }
    }
}
