using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask unwalkableLayer;
    public Vector2 gridSize;
    public float nodeSize;

    private int numberOfNodesPerRow;
    private int numberOfNodesPerCol;

    private Node[,] grid;


    void Start()
    {
        numberOfNodesPerRow = Mathf.RoundToInt(gridSize.x / nodeSize);
        numberOfNodesPerCol = Mathf.RoundToInt(gridSize.y / nodeSize);

        CreateGrid();
    }

    private void Update()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[numberOfNodesPerRow, numberOfNodesPerCol];

        Vector3 bottomLeft = this.transform.position - (Vector3.right * (gridSize.x / 2)) - (Vector3.forward * (gridSize.y / 2));

        Vector3 point;
        bool walkable;

        for (int x = 0; x < numberOfNodesPerRow; x++)
        {
            for(int y = 0; y < numberOfNodesPerCol; y++)
            {
                point = bottomLeft + Vector3.right * (x * nodeSize + (nodeSize / 2)) + Vector3.forward * (y * nodeSize + (nodeSize / 2));

                walkable = !(Physics.CheckSphere(point, nodeSize / 2, unwalkableLayer));

                grid[x, y] = new Node(walkable, point);
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(gridSize.x, 1, gridSize.y));

        if(grid != null)
        {
            foreach(Node node in grid)
            {
                Gizmos.color = (node.walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(node.positionInTheWorld, Vector3.one * (nodeSize - 0.1f));
            }
        }
    }
}
