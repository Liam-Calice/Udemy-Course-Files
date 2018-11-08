using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
