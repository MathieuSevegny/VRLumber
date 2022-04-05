using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Axe : MonoBehaviour
{
    public TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = Player.Instance.points.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
