namespace FlatMango.ProjectGlass.Demo
{
    using UnityEngine;
    using FlatMango.ProjectGlass;


    public sealed class ProjectGlassActivator : MonoBehaviour
    {
        private void Awake()
        {
#if !UNITY_EDITOR

        ProjectGlass.Windows.MainWindow.SetTransparent(true);
        ProjectGlass.Windows.MainWindow.SetTopMost(true);
        ProjectGlass.Windows.MainWindow.SetClickThrough(true);

#endif
        }
    }

}