using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentTransform : MonoBehaviour
{
    public void Unparent()
    {
        transform.SetParent(null);
    }
}
