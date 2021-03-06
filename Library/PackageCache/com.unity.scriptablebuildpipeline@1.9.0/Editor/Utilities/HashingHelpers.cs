using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Build.Content;
using UnityEditor.Build.Pipeline.Utilities;
using UnityEngine;

static class HashingHelpers
{
    static void WriteObjectIdentifier(ObjectIdentifier obj, BinaryWriter writer)
    {
        writer.Write(obj.filePath ?? string.Empty);
        writer.Write((int)obj.fileType);
        writer.Write(obj.guid.ToString());
        writer.Write(obj.localIdentifierInFile);
    }

    internal static void WriteObjectIdentifiers(List<ObjectIdentifier> ids, BinaryWriter writer)
    {
        writer.Write((ids != null) ? ids.Count : 0);
        if (ids != null)
            foreach (ObjectIdentifier o in ids)
                WriteObjectIdentifier(o, writer);
    }

    internal static void WriteHashData(AssetLoadInfo info, BinaryWriter writer)
    {
        writer.Write(info.address ?? string.Empty);
        writer.Write(info.asset.ToString());
        WriteObjectIdentifiers(info.referencedObjects, writer);
        WriteObjectIdentifiers(info.includedObjects, writer);
    }

    internal static void WriteHashData(AssetBundleInfo info, BinaryWriter writer)
    {
        if (info != null)
        {
            writer.Write(info.bundleName ?? string.Empty);
            if (info.bundleAssets != null)
                foreach (AssetLoadInfo ali in info.bundleAssets)
                    WriteHashData(ali, writer);
        }
    }

    internal static void WriteHashData(PreloadInfo info, BinaryWriter writer)
    {
        if (info != null)
            WriteObjectIdentifiers(info.preloadObjects, writer);
    }

    internal static void WriteHashData(SerializationInfo info, BinaryWriter writer)
    {
        WriteObjectIdentifier(info.serializationObject, writer);
        writer.Write(info.serializationIndex);
    }

    internal static void WriteHashData(WriteCommand cmd, BinaryWriter writer)
    {
        if (cmd != null)
        {
            writer.Write(cmd.fileName ?? string.Empty);
            writer.Write(cmd.internalName ?? string.Empty);
            if (cmd.serializeObjects != null)
            {
                cmd.serializeObjects.ForEach((x) => WriteHashData(x, writer));
                foreach (SerializationInfo info in cmd.serializeObjects)
                    WriteHashData(info, writer);
            }
        }
    }

    public static Hash128 GetHash128(this SerializationInfo info)
    {
        StreamHasher hasher = new StreamHasher();
        HashingHelpers.WriteHashData(info, hasher.Writer);
        return hasher.GetHash();
    }

    public static Hash128 GetHash128(this PreloadInfo info)
    {
        StreamHasher hasher = new StreamHasher();
        HashingHelpers.WriteHashData(info, hasher.Writer);
        return hasher.GetHash();
    }

    public static Hash128 GetHash128(this AssetBundleInfo info)
    {
        StreamHasher hasher = new StreamHasher();
        HashingHelpers.WriteHashData(info, hasher.Writer);
        return hasher.GetHash();
    }

    public static Hash128 GetHash128(this AssetLoadInfo info)
    {
        StreamHasher hasher = new StreamHasher();
        HashingHelpers.WriteHashData(info, hasher.Writer);
        return hasher.GetHash();
    }

    public static Hash128 GetHash128(this WriteCommand cmd)
    {
        StreamHasher hasher = new StreamHasher();
        HashingHelpers.WriteHashData(cmd, hasher.Writer);
        return hasher.GetHash();
    }
}

class StreamHasher
{
    MemoryStream m_Stream;
    public BinaryWriter Writer { private set; get; }


    public StreamHasher()
    {
        m_Stream = new MemoryStream();
        Writer = new BinaryWriter(m_Stream);
    }

    public Hash128 GetHash()
    {
        m_Stream.Position = 0;
        return HashingMethods.CalculateStream(m_Stream).ToHash128();
    }
}
