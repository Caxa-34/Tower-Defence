using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyTreeClick : MonoBehaviour
{
    public Material baseMaterial;

    private void Start() {
        baseMaterial = GetComponent<MeshRenderer>().material;
    }

    private void OnMouseDown() {
        Money.money += 3;
        GetComponent<MeshRenderer>().material = baseMaterial;
        GetComponent<BoxCollider>().enabled = false;
    }
}
