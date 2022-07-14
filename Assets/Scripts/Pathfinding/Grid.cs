using UnityEngine;
using Utility;
namespace Pathfinding {
    public class Grid {
        int width;
        int height;
        float cellSize;
        int[,] gridArray;
        TextMesh[,] debugTextArray;

        public Grid(int width, int height, float cellSize) {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;

            gridArray = new int[width, height];
            debugTextArray = new TextMesh[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++) {
                for (int y = 0; y < gridArray.GetLength(1); y++) {
                    debugTextArray[x,y] = Utilities.CreateWorldText(gridArray[x, y].ToString(), null,GetWorldPosition(x,y) + new Vector3(cellSize,cellSize) * .5f, 10, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x,y +1), Color.black, 100f);
                    Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x + 1,y), Color.black, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width,height), Color.black, 100f);
            Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width,height), Color.black, 100f);
            
            SetValue(2,1, 56);
        }

        Vector3 GetWorldPosition(int x, int y) {
            return new Vector3(x, y) * cellSize;
        }
        public void SetValue(int x, int y, int value) {
            if (x >= 0 && y >= 0 && x < width && y < height) {
                gridArray[x, y] = value;
                debugTextArray[x, y].text = gridArray[x,y].ToString();
            }
        }
    }
}
