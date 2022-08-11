using UnityEngine;

public class GridMap : MonoBehaviour {
    [SerializeField] int width = 10;
    [SerializeField] int height = 10;
    [SerializeField] float cellSize = 3f;
    void Start() {
        new Pathfinding(width, height, cellSize);
    }
}
