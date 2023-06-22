using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class moneyTree : MonoBehaviour
{
    bool spawn = false;
    List<GameObject> trees = new List<GameObject>();
    public Material green, gold;
    // Start is called before the first frame update
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("moneyTree").ToList();
        foreach (GameObject tree in trees) {
            tree.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void Update() {
        if (!spawn) StartCoroutine(moneyTrees());
    }
    IEnumerator moneyTrees() {
        spawn = true;
        yield return new WaitForSeconds(5f);
        int number = Random.Range(0, trees.Count);
        trees[number].GetComponent<BoxCollider>().enabled = true;
        trees[number].GetComponent<MeshRenderer>().material = gold;
        Debug.Log("GOLD SPAWN");
        yield return new WaitForSeconds(5f);
        trees[number].GetComponent<BoxCollider>().enabled = false;
        trees[number].GetComponent<MeshRenderer>().material = green;
        yield return new WaitForSeconds(20f);
        spawn = false;
    }
}
