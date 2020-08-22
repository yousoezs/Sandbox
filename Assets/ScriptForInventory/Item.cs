using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Texture Icon;

    public string type;
    public int treeDamage;

    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    private bool pickedUp;
}
