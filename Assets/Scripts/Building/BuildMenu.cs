using UnityEngine;

public class BuildMenu : MonoBehaviour {
    
    [SerializeField] Builder drill;
    [SerializeField] Builder unitSpawner;
    [SerializeField] GameObject buildMenuUI;
    bool toggleBuildMenu;

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.B)) {
            toggleBuildMenu = !toggleBuildMenu;
            Debug.Log(toggleBuildMenu);
            if (buildMenuUI != null) buildMenuUI.SetActive(!buildMenuUI.activeSelf);
        }
        if (toggleBuildMenu) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                drill.Build();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                unitSpawner.Build();
            }
        }
    }
}
