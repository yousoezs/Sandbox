using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCanvas : MonoBehaviour
{
    public Canvas canvas;
    public Canvas InventoryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        InventoryCanvas = (Canvas)Instantiate(canvas, this.transform.position, Quaternion.identity);
        InventoryCanvas.name = "InventoryCanvas";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
