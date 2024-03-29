using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {
    const int MOVE_STRAIGHT_COST = 10;
    const int MOVE_DIAGONAL_COST = 14;
    
    public static Pathfinding Instance { get; private set; }

    
    public Grid<PathNode> Grid { get; }
    List<PathNode> openList;
    List<PathNode> closedList;
    public Pathfinding(int width, int height, float cellSize) {
        Instance = this;
        Grid = new Grid<PathNode>(width, height, cellSize, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }
    

    public List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition) {
        Grid.GetXY(startWorldPosition, out int startX, out int startY);
        Grid.GetXY(endWorldPosition, out int endX, out int endY);

        List<PathNode> path = FindPath(startX, startY, endX, endY);
        if (path == null) {
            return null;
        }
        else {
            List<Vector3> vectorPath = new List<Vector3>();
            foreach (var pathNode in path) {
                vectorPath.Add(new Vector3(pathNode.x, pathNode.y) * Grid.GetCellSize() + Vector3.one * Grid.GetCellSize() * .5f);
            }
            return vectorPath;
        }
    }

    public List<PathNode> FindPath(int startX, int startY, int endX, int endY) {
        
        PathNode startNode = Grid.GetGridObject(startX, startY);
        PathNode endNode = Grid.GetGridObject(endX, endY);
        
        openList = new List<PathNode> {startNode};
        closedList = new List<PathNode>();

        for (int x = 0; x < Grid.GetWidth(); x++) {
            for (int y = 0; y < Grid.GetHeight(); y++) {
                PathNode pathNode = Grid.GetGridObject(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0) {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode) {
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (var neighbourNode in GetNeighbourList(currentNode)) {
                if (closedList.Contains(neighbourNode)) continue;
                if (!neighbourNode.isWalkable) {
                    closedList.Add(neighbourNode);
                    continue;
                }

                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost) {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode)) {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }
        return null;
    }

    List<PathNode> GetNeighbourList(PathNode currentNode) {
        List<PathNode> neighbourList = new List<PathNode>();

        if (currentNode.x - 1 >= 0) {
            // Left
            neighbourList.Add(GetNode(currentNode.x - 1,currentNode.y));
            // Left Down
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
            // Left Up
            if (currentNode.y + 1 < Grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
            
        }
        if (currentNode.x + 1 < Grid.GetWidth()) {
            // Right
            neighbourList.Add(GetNode(currentNode.x + 1,currentNode.y));
            // Right Down
            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
            // Right up
            if (currentNode.y + 1 < Grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
        }
        // Down
        if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1));
        // up
        if (currentNode.y + 1 < Grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1));

        return neighbourList;
    }

    PathNode GetNode(int x, int y) {
        return Grid.GetGridObject(x, y);
    }


    List<PathNode> CalculatePath(PathNode endNode) {
        
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        
        while (currentNode.cameFromNode != null) {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        
        path.Reverse();
        return path;
    }

    int CalculateDistanceCost(PathNode a, PathNode b) {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    PathNode GetLowestFCostNode(List<PathNode> pathNodes) {
        PathNode lowestFCostNode = pathNodes[0];
        for (int i = 1; i < pathNodes.Count; i++) {
            if (pathNodes[i].fCost < lowestFCostNode.fCost) {
                lowestFCostNode = pathNodes[i];
            }
        }
        return lowestFCostNode;
    }
}
