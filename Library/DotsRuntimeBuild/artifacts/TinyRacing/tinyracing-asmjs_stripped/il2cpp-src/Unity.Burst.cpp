#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>

#include "StringLiteralsOffsets.h"


// System.ArgumentException
struct ArgumentException_t92A7BEFF4AB3D9960C51962DA66F969D5BC9254E;
// System.InvalidOperationException
struct InvalidOperationException_tF2925B9384E9032AA11349A2C3C1C17E82CBFB4F;
// System.String
struct String_t;
// System.Type
struct Type_t;
// System.Void
struct Void_t39CB6A4CCC637097970C8F4936C9B344C27FEEA9;

IL2CPP_EXTERN_C String_t* _stringLiteral8C01367F6B784D1ABC182A2E9F6A403A0506773E;
IL2CPP_EXTERN_C String_t* _stringLiteral99558DD5BF091125B80584111852E84E79679E91;
IL2CPP_EXTERN_C String_t* _stringLiteralAAC2268753A1BFB2DC7D9A46957E76F35AAC2D48;
IL2CPP_EXTERN_C String_t* _stringLiteralE8A25E76E3168AD5402ECA0ECD4590B455D50C61;
IL2CPP_EXTERN_C const RuntimeMethod ArgumentException__ctor_mC0130E9E2B1A8B7E299DE0DA275C7EFAC79BD206_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod BurstCompilerService_GetOrCreateSharedMemory_m58BF29E061035DFE8F677E5C87014B79DD61EA3A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod BurstRuntime_HashStringWithFNV1A64_mFBE9CDC176C21ACCEF3B09B8AE9A150DAB7E2B42_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod Hash128__ctor_m538A7B577643ECDE0A0E446404F5418C5EAF431B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod InvalidOperationException__ctor_m588DA8165B4167A54412608FFCA1219209BBB54D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod SharedStatic_CheckResult_mC37F691555FFB1C49060F15893B6C85C38A7B7FD_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod SharedStatic_CheckSizeOf_mF1B62F8B128FE6E1AE3AA3AEBD5E099373BB887E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod String_get_Chars_m3877B6BABF6D6A85E9F023D56CE3B72D11B5DDB5_RuntimeMethod_var;
IL2CPP_EXTERN_C const uint32_t TINY_TYPE_OFFSET_ArgumentException_t92A7BEFF4AB3D9960C51962DA66F969D5BC9254E;
IL2CPP_EXTERN_C const uint32_t TINY_TYPE_OFFSET_InvalidOperationException_tF2925B9384E9032AA11349A2C3C1C17E82CBFB4F;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_tCD5BF6D3AAB147F28F15DED35776F8117AE07F16 
{
public:

public:
};


// System.Object

struct Il2CppArrayBounds;

// System.Array


// Unity.Burst.BurstCompiler
struct  BurstCompiler_t99F34BDE62961CF5A5ACEFBB6522F1343BF085D2  : public RuntimeObject
{
public:

public:
};


// Unity.Burst.BurstRuntime
struct  BurstRuntime_t725AE7FF2003494CEB5F987F3365BA847C762735  : public RuntimeObject
{
public:

public:
};


// System.Exception
struct  Exception_t  : public RuntimeObject
{
public:
	// System.String System.Exception::<Message>k__BackingField
	String_t* ___U3CMessageU3Ek__BackingField_0;
	// System.String System.Exception::<StackTrace>k__BackingField
	String_t* ___U3CStackTraceU3Ek__BackingField_1;

public:
	inline String_t* get_U3CMessageU3Ek__BackingField_0() const { return ___U3CMessageU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CMessageU3Ek__BackingField_0() { return &___U3CMessageU3Ek__BackingField_0; }
	inline void set_U3CMessageU3Ek__BackingField_0(String_t* value)
	{
		___U3CMessageU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CMessageU3Ek__BackingField_0), (void*)value);
	}

	inline String_t* get_U3CStackTraceU3Ek__BackingField_1() const { return ___U3CStackTraceU3Ek__BackingField_1; }
	inline String_t** get_address_of_U3CStackTraceU3Ek__BackingField_1() { return &___U3CStackTraceU3Ek__BackingField_1; }
	inline void set_U3CStackTraceU3Ek__BackingField_1(String_t* value)
	{
		___U3CStackTraceU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CStackTraceU3Ek__BackingField_1), (void*)value);
	}
};


// System.Reflection.MemberInfo
struct  MemberInfo_t  : public RuntimeObject
{
public:

public:
};


// Unity.Burst.SharedStatic
struct  SharedStatic_t4A478B3109091C26ED6F772B9BEC1EA0802B2FFC  : public RuntimeObject
{
public:

public:
};


// System.String
struct  String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::_length
	int32_t ____length_0;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_1;

public:
	inline int32_t get__length_0() const { return ____length_0; }
	inline int32_t* get_address_of__length_0() { return &____length_0; }
	inline void set__length_0(int32_t value)
	{
		____length_0 = value;
	}

	inline Il2CppChar get__firstChar_1() const { return ____firstChar_1; }
	inline Il2CppChar* get_address_of__firstChar_1() { return &____firstChar_1; }
	inline void set__firstChar_1(Il2CppChar value)
	{
		____firstChar_1 = value;
	}
};

extern void* String_t_StaticFields_Storage;
struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_2;

public:
	inline String_t* get_Empty_2() const { return ___Empty_2; }
	inline String_t** get_address_of_Empty_2() { return &___Empty_2; }
	inline void set_Empty_2(String_t* value)
	{
		___Empty_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Empty_2), (void*)value);
	}
};


// System.ValueType
struct  ValueType_t9E835CDBB7CA8FF62C1E998C186DBB81B6242C94  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t9E835CDBB7CA8FF62C1E998C186DBB81B6242C94_marshaled_pinvoke
{
};

// System.Char
struct  Char_t312855888692AB480259272BFBF0236C425A398B 
{
public:
	// System.Char System.Char::m_value
	Il2CppChar ___m_value_0;

public:
	inline Il2CppChar get_m_value_0() const { return ___m_value_0; }
	inline Il2CppChar* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(Il2CppChar value)
	{
		___m_value_0 = value;
	}
};


// UnityEngine.Hash128
struct  Hash128_tC9DF98FF26F26D850840BD69D6C5B20CD40E6BF5 
{
public:
	// System.UInt32 UnityEngine.Hash128::m_u32_0
	uint32_t ___m_u32_0_0;
	// System.UInt32 UnityEngine.Hash128::m_u32_1
	uint32_t ___m_u32_1_1;
	// System.UInt32 UnityEngine.Hash128::m_u32_2
	uint32_t ___m_u32_2_2;
	// System.UInt32 UnityEngine.Hash128::m_u32_3
	uint32_t ___m_u32_3_3;

public:
	inline uint32_t get_m_u32_0_0() const { return ___m_u32_0_0; }
	inline uint32_t* get_address_of_m_u32_0_0() { return &___m_u32_0_0; }
	inline void set_m_u32_0_0(uint32_t value)
	{
		___m_u32_0_0 = value;
	}

	inline uint32_t get_m_u32_1_1() const { return ___m_u32_1_1; }
	inline uint32_t* get_address_of_m_u32_1_1() { return &___m_u32_1_1; }
	inline void set_m_u32_1_1(uint32_t value)
	{
		___m_u32_1_1 = value;
	}

	inline uint32_t get_m_u32_2_2() const { return ___m_u32_2_2; }
	inline uint32_t* get_address_of_m_u32_2_2() { return &___m_u32_2_2; }
	inline void set_m_u32_2_2(uint32_t value)
	{
		___m_u32_2_2 = value;
	}

	inline uint32_t get_m_u32_3_3() const { return ___m_u32_3_3; }
	inline uint32_t* get_address_of_m_u32_3_3() { return &___m_u32_3_3; }
	inline void set_m_u32_3_3(uint32_t value)
	{
		___m_u32_3_3 = value;
	}
};


// System.Int32
struct  Int32_tBC6089C5C93BC1423D3EA683333151645C66E22A 
{
public:
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;

public:
	inline int32_t get_m_value_0() const { return ___m_value_0; }
	inline int32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int32_t value)
	{
		___m_value_0 = value;
	}
};


// System.Int64
struct  Int64_t92CF6AD936A71DF967CA96510EC5061337E763AC 
{
public:
	// System.Int64 System.Int64::m_value
	int64_t ___m_value_0;

public:
	inline int64_t get_m_value_0() const { return ___m_value_0; }
	inline int64_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(int64_t value)
	{
		___m_value_0 = value;
	}
};


// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

extern void* IntPtr_t_StaticFields_Storage;
struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};


// System.SystemException
struct  SystemException_t7DE5037038B986F34BB1C205CF95A1C2F9C9F7DB  : public Exception_t
{
public:

public:
};


// System.UInt32
struct  UInt32_tC3ED28EAF4926C1D40BD77C632886FF758E999A0 
{
public:
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;

public:
	inline uint32_t get_m_value_0() const { return ___m_value_0; }
	inline uint32_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint32_t value)
	{
		___m_value_0 = value;
	}
};


// System.UInt64
struct  UInt64_tC1196FF740CB17FAA88CC857A7F70408BCE88D8F 
{
public:
	// System.UInt64 System.UInt64::m_value
	uint64_t ___m_value_0;

public:
	inline uint64_t get_m_value_0() const { return ___m_value_0; }
	inline uint64_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint64_t value)
	{
		___m_value_0 = value;
	}
};


// System.Void
struct  Void_t39CB6A4CCC637097970C8F4936C9B344C27FEEA9 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t39CB6A4CCC637097970C8F4936C9B344C27FEEA9__padding[1];
	};

public:
};


// System.ArgumentException
struct  ArgumentException_t92A7BEFF4AB3D9960C51962DA66F969D5BC9254E  : public SystemException_t7DE5037038B986F34BB1C205CF95A1C2F9C9F7DB
{
public:

public:
};


// System.InvalidOperationException
struct  InvalidOperationException_tF2925B9384E9032AA11349A2C3C1C17E82CBFB4F  : public SystemException_t7DE5037038B986F34BB1C205CF95A1C2F9C9F7DB
{
public:

public:
};


// System.Type
struct  Type_t  : public MemberInfo_t
{
public:
	// System.IntPtr System.Type::typeHandle
	intptr_t ___typeHandle_0;

public:
	inline intptr_t get_typeHandle_0() const { return ___typeHandle_0; }
	inline intptr_t* get_address_of_typeHandle_0() { return &___typeHandle_0; }
	inline void set_typeHandle_0(intptr_t value)
	{
		___typeHandle_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Int64 Unity.Burst.BurstRuntime::HashStringWithFNV1A64(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t BurstRuntime_HashStringWithFNV1A64_mFBE9CDC176C21ACCEF3B09B8AE9A150DAB7E2B42 (String_t* ___text0);
// System.Char System.String::get_Chars(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar String_get_Chars_m3877B6BABF6D6A85E9F023D56CE3B72D11B5DDB5 (String_t* __this, int32_t ___index0);
// System.Void System.ArgumentException::.ctor(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_mC0130E9E2B1A8B7E299DE0DA275C7EFAC79BD206 (ArgumentException_t92A7BEFF4AB3D9960C51962DA66F969D5BC9254E * __this, String_t* ___message0, String_t* ___argumentName1);
// System.Void Unity.Burst.SharedStatic::CheckSizeOf(System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SharedStatic_CheckSizeOf_mF1B62F8B128FE6E1AE3AA3AEBD5E099373BB887E (uint32_t ___sizeOf0);
// System.Void System.InvalidOperationException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_m588DA8165B4167A54412608FFCA1219209BBB54D (InvalidOperationException_tF2925B9384E9032AA11349A2C3C1C17E82CBFB4F * __this, String_t* ___msg0);
// System.Void Unity.Burst.SharedStatic::CheckResult(System.Void*)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SharedStatic_CheckResult_mC37F691555FFB1C49060F15893B6C85C38A7B7FD (void* ___result0);
// System.Void UnityEngine.Hash128::.ctor(System.UInt64,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Hash128__ctor_m538A7B577643ECDE0A0E446404F5418C5EAF431B (Hash128_tC9DF98FF26F26D850840BD69D6C5B20CD40E6BF5 * __this, uint64_t ___u64_00, uint64_t ___u64_11);
// System.Void* Unity.Burst.LowLevel.BurstCompilerService::GetOrCreateSharedMemory(UnityEngine.Hash128&,System.UInt32,System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void* BurstCompilerService_GetOrCreateSharedMemory_m58BF29E061035DFE8F677E5C87014B79DD61EA3A (Hash128_tC9DF98FF26F26D850840BD69D6C5B20CD40E6BF5 * ___subKey0, uint32_t ___sizeOf1, uint32_t ___alignment2);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_BurstCompiler_CompileFunctionPointer_m056551D235BD6F37F694A67F1E57E6208231BE52()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Burst.FunctionPointer`1<T> Unity.Burst.BurstCompiler::CompileFunctionPointer(T)", "it has generic parameters.");
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_BurstRuntime_GetHashCode64_m89F4560DD69F3C3753269F691EEAEBA60D61446B()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Int64 Unity.Burst.BurstRuntime::GetHashCode64()", "it has generic parameters.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_BurstRuntime_GetHashCode64_m360C0927FB7E432C41E2CFF1B958870F9A24B7D4()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Int64 Unity.Burst.BurstRuntime::GetHashCode64(System.Type)", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_BurstRuntime_HashStringWithFNV1A64_mFBE9CDC176C21ACCEF3B09B8AE9A150DAB7E2B42()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Int64 Unity.Burst.BurstRuntime::HashStringWithFNV1A64(System.String)", "it does not have the [MonoPInvokeCallback] attribute.");
}
// System.Int64 Unity.Burst.BurstRuntime::GetHashCode64(System.Type)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t BurstRuntime_GetHashCode64_m360C0927FB7E432C41E2CFF1B958870F9A24B7D4 (Type_t * ___type0)
{
	{
		int64_t L_0;
		L_0 = BurstRuntime_HashStringWithFNV1A64_mFBE9CDC176C21ACCEF3B09B8AE9A150DAB7E2B42(LookupStringFromCursor(TINY_STRING_OFFSET__stringLiteralAAC2268753A1BFB2DC7D9A46957E76F35AAC2D48));
		return L_0;
	}
}
// System.Int64 Unity.Burst.BurstRuntime::HashStringWithFNV1A64(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t BurstRuntime_HashStringWithFNV1A64_mFBE9CDC176C21ACCEF3B09B8AE9A150DAB7E2B42 (String_t* ___text0)
{
	uint64_t V_0 = 0;
	String_t* V_1 = NULL;
	int32_t V_2 = 0;
	Il2CppChar V_3 = 0x0;
	{
		V_0 = ((int64_t)-3750763034362895579LL);
		String_t* L_0 = ___text0;
		V_1 = L_0;
		V_2 = 0;
		goto IL_0044;
	}

IL_0010:
	{
		String_t* L_1 = V_1;
		int32_t L_2 = V_2;
		Il2CppChar L_3;
		L_3 = String_get_Chars_m3877B6BABF6D6A85E9F023D56CE3B72D11B5DDB5(L_1, L_2);
		V_3 = L_3;
		uint64_t L_4 = V_0;
		Il2CppChar L_5 = V_3;
		V_0 = ((int64_t)il2cpp_codegen_multiply((int64_t)((int64_t)1099511628211LL), (int64_t)((int64_t)((int64_t)L_4^(int64_t)((int64_t)((uint64_t)((uint32_t)((uint32_t)((int32_t)((uint8_t)((int32_t)((int32_t)L_5&(int32_t)((int32_t)255)))))))))))));
		uint64_t L_6 = V_0;
		Il2CppChar L_7 = V_3;
		V_0 = ((int64_t)il2cpp_codegen_multiply((int64_t)((int64_t)1099511628211LL), (int64_t)((int64_t)((int64_t)L_6^(int64_t)((int64_t)((uint64_t)((uint32_t)((uint32_t)((int32_t)((uint8_t)((int32_t)((int32_t)L_7>>(int32_t)8))))))))))));
		int32_t L_8 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add((int32_t)L_8, (int32_t)1));
	}

IL_0044:
	{
		int32_t L_9 = V_2;
		String_t* L_10 = V_1;
		int32_t L_11 = L_10->get__length_0();
		if ((((int32_t)L_9) < ((int32_t)L_11)))
		{
			goto IL_0010;
		}
	}
	{
		uint64_t L_12 = V_0;
		return L_12;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_SharedStatic_CheckSizeOf_mF1B62F8B128FE6E1AE3AA3AEBD5E099373BB887E()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Burst.SharedStatic::CheckSizeOf(System.UInt32)", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_SharedStatic_CheckResult_mC37F691555FFB1C49060F15893B6C85C38A7B7FD()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Burst.SharedStatic::CheckResult(System.Void*)", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_SharedStatic_GetOrCreateSharedStaticInternal_mB72AA33D29DAF89998944889A23DD86D1E58FA83()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void* Unity.Burst.SharedStatic::GetOrCreateSharedStaticInternal(System.Int64,System.Int64,System.UInt32,System.UInt32)", "it does not have the [MonoPInvokeCallback] attribute.");
}
// System.Void Unity.Burst.SharedStatic::CheckSizeOf(System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SharedStatic_CheckSizeOf_mF1B62F8B128FE6E1AE3AA3AEBD5E099373BB887E (uint32_t ___sizeOf0)
{
	{
		// if (sizeOf == 0) throw new ArgumentException("sizeOf must be > 0", nameof(sizeOf));
		uint32_t L_0 = ___sizeOf0;
		if (L_0)
		{
			goto IL_0013;
		}
	}
	{
		// if (sizeOf == 0) throw new ArgumentException("sizeOf must be > 0", nameof(sizeOf));
		ArgumentException_t92A7BEFF4AB3D9960C51962DA66F969D5BC9254E * L_1 = (ArgumentException_t92A7BEFF4AB3D9960C51962DA66F969D5BC9254E *)il2cpp_codegen_object_new(sizeof(ArgumentException_t92A7BEFF4AB3D9960C51962DA66F969D5BC9254E), LookupTypeInfoFromCursor(TINY_TYPE_OFFSET_ArgumentException_t92A7BEFF4AB3D9960C51962DA66F969D5BC9254E));
		ArgumentException__ctor_mC0130E9E2B1A8B7E299DE0DA275C7EFAC79BD206(L_1, LookupStringFromCursor(TINY_STRING_OFFSET__stringLiteral8C01367F6B784D1ABC182A2E9F6A403A0506773E), LookupStringFromCursor(TINY_STRING_OFFSET__stringLiteral99558DD5BF091125B80584111852E84E79679E91));
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, &SharedStatic_CheckSizeOf_mF1B62F8B128FE6E1AE3AA3AEBD5E099373BB887E_RuntimeMethod_var);
	}

IL_0013:
	{
		// }
		return;
	}
}
// System.Void Unity.Burst.SharedStatic::CheckResult(System.Void*)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SharedStatic_CheckResult_mC37F691555FFB1C49060F15893B6C85C38A7B7FD (void* ___result0)
{
	{
		// if (result == null) throw new InvalidOperationException("Unable to create a SharedStatic for this key. It is likely that the same key was used to allocate a shared memory with a smaller size while the new size requested is bigger");
		void* L_0 = ___result0;
		if ((!(((uintptr_t)L_0) == ((uintptr_t)((uintptr_t)0)))))
		{
			goto IL_0010;
		}
	}
	{
		// if (result == null) throw new InvalidOperationException("Unable to create a SharedStatic for this key. It is likely that the same key was used to allocate a shared memory with a smaller size while the new size requested is bigger");
		InvalidOperationException_tF2925B9384E9032AA11349A2C3C1C17E82CBFB4F * L_1 = (InvalidOperationException_tF2925B9384E9032AA11349A2C3C1C17E82CBFB4F *)il2cpp_codegen_object_new(sizeof(InvalidOperationException_tF2925B9384E9032AA11349A2C3C1C17E82CBFB4F), LookupTypeInfoFromCursor(TINY_TYPE_OFFSET_InvalidOperationException_tF2925B9384E9032AA11349A2C3C1C17E82CBFB4F));
		InvalidOperationException__ctor_m588DA8165B4167A54412608FFCA1219209BBB54D(L_1, LookupStringFromCursor(TINY_STRING_OFFSET__stringLiteralE8A25E76E3168AD5402ECA0ECD4590B455D50C61));
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, &SharedStatic_CheckResult_mC37F691555FFB1C49060F15893B6C85C38A7B7FD_RuntimeMethod_var);
	}

IL_0010:
	{
		// }
		return;
	}
}
// System.Void* Unity.Burst.SharedStatic::GetOrCreateSharedStaticInternal(System.Int64,System.Int64,System.UInt32,System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void* SharedStatic_GetOrCreateSharedStaticInternal_mB72AA33D29DAF89998944889A23DD86D1E58FA83 (int64_t ___getHashCode640, int64_t ___getSubHashCode641, uint32_t ___sizeOf2, uint32_t ___alignment3)
{
	Hash128_tC9DF98FF26F26D850840BD69D6C5B20CD40E6BF5  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// CheckSizeOf(sizeOf);
		uint32_t L_0 = ___sizeOf2;
		SharedStatic_CheckSizeOf_mF1B62F8B128FE6E1AE3AA3AEBD5E099373BB887E(L_0);
		// var hash128 = new Hash128((ulong)getHashCode64, (ulong)getSubHashCode64);
		int64_t L_1 = ___getHashCode640;
		int64_t L_2 = ___getSubHashCode641;
		Hash128__ctor_m538A7B577643ECDE0A0E446404F5418C5EAF431B((Hash128_tC9DF98FF26F26D850840BD69D6C5B20CD40E6BF5 *)(&V_0), L_1, L_2);
		// var result = BurstCompilerService.GetOrCreateSharedMemory(ref hash128, sizeOf, alignment);
		uint32_t L_3 = ___sizeOf2;
		uint32_t L_4 = ___alignment3;
		void* L_5;
		L_5 = BurstCompilerService_GetOrCreateSharedMemory_m58BF29E061035DFE8F677E5C87014B79DD61EA3A((Hash128_tC9DF98FF26F26D850840BD69D6C5B20CD40E6BF5 *)(&V_0), L_3, L_4);
		// CheckResult(result);
		void* L_6 = (void*)L_5;
		SharedStatic_CheckResult_mC37F691555FFB1C49060F15893B6C85C38A7B7FD((void*)(void*)L_6);
		// return result;
		return (void*)(L_6);
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
