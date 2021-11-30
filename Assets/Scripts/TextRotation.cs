using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotation : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
