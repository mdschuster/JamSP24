using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float timeToDie;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToDie;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {
            Destroy(this.gameObject);
        }

        timer -= Time.deltaTime;
    }
}
