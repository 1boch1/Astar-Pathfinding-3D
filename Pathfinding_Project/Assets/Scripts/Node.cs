using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    /*
     * To define a node I need its position and I need
     * to know if it is walkable in order to create a path
     */

    public bool walkable;
    public Vector3 positionInTheWorld;

    public Node(bool walkable, Vector3 pos)
    {
        this.walkable = walkable;
        this.positionInTheWorld = pos;
    }
}
