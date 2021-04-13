using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawConstantMove : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextpos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextpos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextpos, speed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, nextpos) <= 0.1)
        {
            change();
        }
    }
    private void change()
    {
        nextpos = nextpos != posA ? posA : posB;
    }

}
