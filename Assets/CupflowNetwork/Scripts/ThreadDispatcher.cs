using System;
using System.Collections.Generic;
using UnityEngine;

namespace CupflowNetwork
{
    public class ThreadDispatcher : MonoBehaviour
    {
        private static ThreadDispatcher instance;

        private readonly Queue<Action> actionQueue = new Queue<Action>();
        private readonly object queueLock = new object();

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Multiple ThreadDispatcher instances detected. Only one is allowed.");
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            lock (queueLock)
            {
                while (actionQueue.Count > 0)
                {
                    Action action = actionQueue.Dequeue();
                    action.Invoke();
                }
            }
        }

        public static void RunOnMainThread(Action action)
        {
            if (instance == null)
            {
                Debug.LogError("ThreadDispatcher instance not found. Make sure the script is attached to a GameObject in the scene.");
                return;
            }

            lock (instance.queueLock)
            {
                instance.actionQueue.Enqueue(action);
            }
        }
    }
}

