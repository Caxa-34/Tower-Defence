using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SetActivePlace : MonoBehaviour
{
    Color baseColor;
    List<GameObject> canvasList = new List<GameObject>(), places = new List<GameObject>();
    int i;
    float cycleTime = 3f, timer;
    public GameObject canvas;
    public bool isActive = false;

    void Awake()
    {
        canvasList = GameObject.FindGameObjectsWithTag("PlaceCanvas").ToList();
        places =  GameObject.FindGameObjectsWithTag("Place").ToList();
        for (i = 0; i < canvasList.Count; i++) if (canvasList[i].name == name) canvas = canvasList[i];
    }

    void Start()
    {
        baseColor = GetComponent<Renderer>().material.color;
        cycleTime = Mathf.Abs(cycleTime);
        for (i = 0; i < canvasList.Count; i++) canvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        for (i = 0; i < canvasList.Count; i++)
        {
            canvasList[i].SetActive(false);
            places[i].GetComponent<SetActivePlace>().isActive = false;
            places[i].GetComponent<Renderer>().material.color = baseColor;
        }
        canvas.SetActive(true);
        isActive = true;
    }

    private void LateUpdate() {
        if (!isActive) return;
        timer = Time.time / cycleTime;
        timer = Mathf.Abs((timer - Mathf.Floor(timer)) * cycleTime - 1);
        GetComponent<Renderer>().material.color = Color.Lerp(Color.gray, baseColor, timer);
    }
}
