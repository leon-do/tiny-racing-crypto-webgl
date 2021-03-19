using System;
using Unity.Transforms;
using UnityEngine;

namespace Unity.Entities.Streaming
{
    [DisableAutoCreation]
    [WorldSystemFilter(WorldSystemFilterFlags.EntitySceneOptimizations)]
    class OptimizationGroup : ComponentSystemGroup
    {
    }

    public static class EntitySceneOptimization
    {
        static void RemoveSystemState(EntityManager entityManager)
        {
            foreach (var s in TypeManager.AllTypes)
            {
                if (TypeManager.IsSystemStateComponent(s.TypeIndex))
                {
                    //@TODO: Make query instead of this crazy slow shit
                    entityManager.RemoveComponent(entityManager.UniversalQuery, ComponentType.FromTypeIndex(s.TypeIndex));
                }
            }
        }

        public static void Optimize(World world)
        {
            var entityManager = world.EntityManager;

            var group = world.GetOrCreateSystem<OptimizationGroup>();

            var systemTypes = DefaultWorldInitialization.GetAllSystems(WorldSystemFilterFlags.EntitySceneOptimizations);
            foreach (var systemType in systemTypes)
                AddSystemAndLogException(world, group, systemType);
            group.SortSystems();

            // foreach (var system in group.Systems)
            //    Debug.Log(system.GetType());

            // Run first pass (This might add / remove a bunch of components and thus invalidate some of chunk component data caches)
            group.Update();

            // Run all systems again (For example chunk bounding volumes might be out of sync after various remove / add from previous pass)
            // But now we are sure that no more re-ordering will happen.
            group.Update();

            RemoveSystemState(entityManager);
        }

        static void AddSystemAndLogException(World world, ComponentSystemGroup group, Type type)
        {
            try
            {
                group.AddSystemToUpdateList(world.GetOrCreateSystem(type) as ComponentSystemBase);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
