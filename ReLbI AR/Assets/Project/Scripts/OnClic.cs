using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnClic : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent onMouseclick;
    private void OnMouseDown()
    {
        onMouseclick.Invoke();
    }
}
