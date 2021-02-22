using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    MeshRenderer rend;
    Material mat;
    Color cor;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        mat = rend.material;
        cor = mat.color;
    }

    public void OnHover()
    {
        mat.color = Color.cyan;
    }

    public void OnUnHover()
    {
        mat.color = cor;
    }
}
