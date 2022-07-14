using UnityEngine;
using Utility;
namespace Pathfinding {
    public class Testgrid : MonoBehaviour
    {
        void Start() {
            Pathfinding.Grid grid = new Pathfinding.Grid(4, 2, 5f);
        }
    }
}
