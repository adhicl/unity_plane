using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscroll : MonoBehaviour
{
    [SerializeField] float speedScroll = 1f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Time.deltaTime * Vector3.back * speedScroll;
    }
}
