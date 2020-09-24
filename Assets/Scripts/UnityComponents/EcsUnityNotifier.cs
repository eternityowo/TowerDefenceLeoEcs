using Leopotam.Ecs;
using System;
using TowerDefenceLeoEcs.Components.Events.UnityEvents;
using TowerDefenceLeoEcs.Extensions;
using TowerDefenceLeoEcs.Extensions.UnityComponent;
using TowerDefenceLeoEcs.Extensions.UnityComponents;
using UnityEngine;

namespace TowerDefenceLeoEcs.UnityComponents
{
    public class EcsUnityNotifier : EcsUnityNotifierBase
    {
        private void OnBecameInvisible()
        {
            if(!Entity.IsAlive()) return;
            // Entity.AddEventToStack<OnBecameInvisibleEvent>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //Debug.Log("On Collision Enter2D");
            if (!Entity.IsAlive()) return;
            
            var otherTransform = other.transform;
            if (!otherTransform.HasProvider()) return;

            var otherEntity = otherTransform.GetProvider().Entity;
            if (!otherEntity.IsAlive()) return;
            
            Entity.AddEventToStack(new OnCollisionEnter2DEvent() {Other = otherEntity});
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log("Trigger Enter2D");
            if (!Entity.IsAlive()) return;

            var otherTransform = other.transform;
            if (!otherTransform.HasProvider()) return;

            var otherEntity = otherTransform.GetProvider().Entity;
            if (!otherEntity.IsAlive()) return;

            Entity.AddEventToStack(new OnTriggerEnter2DEvent() { Other = otherEntity });
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!Entity.IsAlive()) return;

            var otherTransform = other.transform;
            if (!otherTransform.HasProvider()) return;

            var otherEntity = otherTransform.GetProvider().Entity;
            if (!otherEntity.IsAlive()) return;

            Entity.AddEventToStack(new OnCollisionExit2DEvent() { Other = otherEntity });
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            //Debug.Log("Trigger Exit 2D");
            if (!Entity.IsAlive()) return;

            var otherTransform = other.transform;
            if (!otherTransform.HasProvider()) return;

            var otherEntity = otherTransform.GetProvider().Entity;
            if (!otherEntity.IsAlive()) return;

            Entity.AddEventToStack(new OnTriggerExit2DEvent() { Other = otherEntity });
        }
    }
}