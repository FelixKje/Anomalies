using UnityEngine;

public class GridMap : MonoBehaviour {
    Pathfinding pathfinding;
    [SerializeField] int width = 10;
    [SerializeField] int height = 10;
    [SerializeField] float cellSize = 3f;
    void Start() {
        pathfinding = new Pathfinding(width, height, cellSize);
    }
}
