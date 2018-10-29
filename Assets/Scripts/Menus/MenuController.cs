using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController
    :
    MonoBehaviour
{
    static MenuManager menuMan;
    // 
    public static void Initialize()
    {
        menuMan = new MenuManager();
    }
    public static void GoToMenu( MenuState theMenu )
    {}
}
