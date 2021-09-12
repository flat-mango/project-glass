/*

Project Glass
Made by Oleh Zahorodnii (Flat Mango)

The MIT License (MIT)

Copyright © 2021 Oleh Zahorodnii (Flat Mango)


Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/
namespace FlatMango.ProjectGlass
{
    using UnityEngine;
    using UnityEngine.LowLevel;

    
    public static class ProjectGlass
    {
        public static MouseInputModule Mouse { get; private set; }
        public static KeyboardInputModule Keyboard { get; private set; }
        public static WindowsModule Windows { get; private set; }


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void OnBeforeSplashScreen()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Debug.Log($"Project Glass - Initialize");

            Mouse = MouseInputModule.Instance;
            Keyboard = KeyboardInputModule.Instance;
            Windows = WindowsModule.Instance;

            Application.quitting += OnApplicationQuitting;

            RegisterUpdateBeforeMonoBehaviour();
        }

        /// <summary>
        /// Sets <see cref="Update"/> to be called right before <see cref="UnityEngine.MonoBehaviour"/>'s Update in
        /// Unity Player Loop, so every script will get fresh data when accessing <see cref="ProjectGlass"/> modules.
        /// </summary>
        private static void RegisterUpdateBeforeMonoBehaviour()
        {
            PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();

            for (int i = 0; i < playerLoop.subSystemList.Length; i++)
            {
                PlayerLoopSystem updateSystem = playerLoop.subSystemList[i];

                if (updateSystem.type != typeof(UnityEngine.PlayerLoop.Update))
                    continue;

                PlayerLoopSystem[] updateSubSystems = new PlayerLoopSystem[updateSystem.subSystemList.Length + 1];

                updateSubSystems[0] = new PlayerLoopSystem
                {
                    type = typeof(UpdateSystem),
                    updateDelegate = Update
                };

                for (int j = 0; j < updateSystem.subSystemList.Length; j++)
                    updateSubSystems[j + 1] = updateSystem.subSystemList[j];

                updateSystem.subSystemList = updateSubSystems;
                playerLoop.subSystemList[i] = updateSystem;

                break;
            }

            PlayerLoop.SetPlayerLoop(playerLoop);
        }

        private static void OnApplicationQuitting()
        {
            Deinitialize();
        }

        private static void Deinitialize()
        {
            Debug.Log($"Project Glass - Deinitialize");

            Keyboard.Disable();
            Mouse.Disable();
            Windows.Disable();

            /// When quitting Play Mode, Unity doesn't automatically reset Player Loop
            /// if it has been changed. Thus need to do it manually.

#if UNITY_EDITOR

            PlayerLoop.SetPlayerLoop(PlayerLoop.GetDefaultPlayerLoop());

#endif
        }

        private static void Update()
        {
            Keyboard.Update();
            Mouse.Update();
            Windows.Update();
        }

        public struct UpdateSystem { }
    }
}
