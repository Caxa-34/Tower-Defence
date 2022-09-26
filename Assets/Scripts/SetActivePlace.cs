using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetActivePlace : MonoBehaviour
{
    List<GameObject> canvasList = new List<GameObject>();
    int i;
    public GameObject canvas;

    void Awake()
    {
        canvasList = GameObject.FindGameObjectsWithTag("PlaceCanvas").ToList();
        for (i = 0; i < canvasList.Count; i++) if (canvasList[i].name == name) canvas = canvasList[i];
    }

    void Start()
    {
        for (i = 0; i < canvasList.Count; i++) canvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        for (i = 0; i < canvasList.Count; i++) canvasList[i].SetActive(false);
        canvas.SetActive(true);
    }
}
