using Unity.Entities;
using Unity.Tiny.Audio;

namespace Unity.TinyConversion
{
    [WorldSystemFilter(WorldSystemFilterFlags.DotsRuntimeGameObjectConversion)]
    internal class ConvertAudioListener : GameObjectConversionSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((UnityEngine.AudioListener audioListener) =>
            {
                var primaryEntity = GetPrimaryEntity(audioListener);
                DstEntityManager.AddComponentData(primaryEntity, new AudioListener());
            });
        }
    }
}
