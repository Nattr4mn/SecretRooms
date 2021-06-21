using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Animator animator;
    private GhostAggr aggression;
    private GhostMove move;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        move.Move(ref animator);
    }

    private void GetReferences()
    {
        animator = GetComponent<Animator>();
        aggression = GetComponent<GhostAggr>();
        move = GetComponent<GhostMove>();
    }
}
