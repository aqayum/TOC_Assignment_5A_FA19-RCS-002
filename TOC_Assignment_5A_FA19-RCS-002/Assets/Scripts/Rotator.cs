using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    Quaternion rotation;

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        transform.GetChild(0).rotation = Quaternion.identity;

        //Euler(0f, 0f, 0f);
        //transform.localPosition(0f, 0f, 0f);
        transform.GetChild(0).localPosition = new Vector3(0, 0, 0);


    }
}
