using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;

public class NoSlice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sliceable2D slicer = GetComponent<Sliceable2D>();
        slicer.AddEvent(SlicedEvent);
    }

    bool SlicedEvent (Slice2D slice)
    {
        SceneManager.Instance.gameController.OnBoxSliced();
        return true;
    }
}
