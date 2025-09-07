using System;
using GFrame.Events;

namespace GFrame.Managers
{
    public interface IEventManager
    {
        /// <summary>
        /// Register a handler for a specific event type.
        /// </summary>
        void Register<EventType>(Action<EventType> handler) where EventType : CustomEvent;

        /// <summary>
        /// Unregister a handler for a specific event type.
        /// </summary>
        void Unregister<EventType>(Action<EventType> handler) where EventType : CustomEvent;

        /// <summary>
        /// Send an event to all registered handlers.
        /// </summary>
        void Send<EventType>(EventType eventData) where EventType : CustomEvent;
    }
}