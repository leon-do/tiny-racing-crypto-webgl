#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>

#include "StringLiteralsOffsets.h"


// System.Collections.Generic.List`1<Unity.Jobs.EarlyInitHelpers/EarlyInitFunction>
struct List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE;
// System.MulticastDelegate[]
struct MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54;
// Unity.Jobs.EarlyInitHelpers/EarlyInitFunction[]
struct EarlyInitFunctionU5BU5D_tF2ABDF03D76BD9D550D5493CC48AA472C2CCA7CD;
// System.Exception
struct Exception_t;
// System.MulticastDelegate
struct MulticastDelegate_t;
// System.String
struct String_t;
// System.Void
struct Void_t39CB6A4CCC637097970C8F4936C9B344C27FEEA9;
// Unity.Jobs.EarlyInitHelpers/EarlyInitFunction
struct EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D;

IL2CPP_EXTERN_C const RuntimeMethod Debug_LogException_m7BF3DEB4C77AF0DE416259599D4FF48CFE60438F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod EarlyInitFunction_Invoke_m0258482E109D2FDF6D56D5E337642492735D05EB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod List_1_get_Item_mAB85BBBA87AC3805A1D7E200DCFB6ACA1E54A568_RuntimeMethod_var;
IL2CPP_EXTERN_C const uint32_t TINY_TYPE_OFFSET_Exception_t;

struct MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_tF5AC023E1B5DC0C97B349977ACE85281C418845B 
{
public:

public:
};


// System.Object


// System.Collections.Generic.List`1<Unity.Jobs.EarlyInitHelpers/EarlyInitFunction>
struct  List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE  : public RuntimeObject
{
public:
	// T[] System.Collections.Generic.List`1::_items
	EarlyInitFunctionU5BU5D_tF2ABDF03D76BD9D550D5493CC48AA472C2CCA7CD* ____items_0;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_1;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_2;

public:
	inline EarlyInitFunctionU5BU5D_tF2ABDF03D76BD9D550D5493CC48AA472C2CCA7CD* get__items_0() const { return ____items_0; }
	inline EarlyInitFunctionU5BU5D_tF2ABDF03D76BD9D550D5493CC48AA472C2CCA7CD** get_address_of__items_0() { return &____items_0; }
	inline void set__items_0(EarlyInitFunctionU5BU5D_tF2ABDF03D76BD9D550D5493CC48AA472C2CCA7CD* value)
	{
		____items_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&____items_0), (void*)value);
	}

	inline int32_t get__size_1() const { return ____size_1; }
	inline int32_t* get_address_of__size_1() { return &____size_1; }
	inline void set__size_1(int32_t value)
	{
		____size_1 = value;
	}

	inline int32_t get__version_2() const { return ____version_2; }
	inline int32_t* get_address_of__version_2() { return &____version_2; }
	inline void set__version_2(int32_t value)
	{
		____version_2 = value;
	}
};

struct Il2CppArrayBounds;

// System.Array


// Unity.Jobs.EarlyInitHelpers
struct  EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2  : public RuntimeObject
{
public:

public:
};

extern void* EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields_Storage;
struct EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields
{
public:
	// System.Collections.Generic.List`1<Unity.Jobs.EarlyInitHelpers/EarlyInitFunction> Unity.Jobs.EarlyInitHelpers::s_PendingDelegates
	List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * ___s_PendingDelegates_0;

public:
	inline List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * get_s_PendingDelegates_0() const { return ___s_PendingDelegates_0; }
	inline List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE ** get_address_of_s_PendingDelegates_0() { return &___s_PendingDelegates_0; }
	inline void set_s_PendingDelegates_0(List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * value)
	{
		___s_PendingDelegates_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___s_PendingDelegates_0), (void*)value);
	}
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


// Unity.Jobs.IJobParallelForDeferExtensions
struct  IJobParallelForDeferExtensions_t90781E0EB8E1D8F93802729D2EF11D851533E022  : public RuntimeObject
{
public:

public:
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


// System.Delegate
struct  Delegate_t  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	intptr_t ___method_ptr_0;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_1;
	// System.Void* System.Delegate::m_ReversePInvokeWrapperPtr
	void* ___m_ReversePInvokeWrapperPtr_2;
	// System.Boolean System.Delegate::m_IsDelegateOpen
	bool ___m_IsDelegateOpen_3;

public:
	inline intptr_t get_method_ptr_0() const { return ___method_ptr_0; }
	inline intptr_t* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(intptr_t value)
	{
		___method_ptr_0 = value;
	}

	inline RuntimeObject * get_m_target_1() const { return ___m_target_1; }
	inline RuntimeObject ** get_address_of_m_target_1() { return &___m_target_1; }
	inline void set_m_target_1(RuntimeObject * value)
	{
		___m_target_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_target_1), (void*)value);
	}

	inline void* get_m_ReversePInvokeWrapperPtr_2() const { return ___m_ReversePInvokeWrapperPtr_2; }
	inline void** get_address_of_m_ReversePInvokeWrapperPtr_2() { return &___m_ReversePInvokeWrapperPtr_2; }
	inline void set_m_ReversePInvokeWrapperPtr_2(void* value)
	{
		___m_ReversePInvokeWrapperPtr_2 = value;
	}

	inline bool get_m_IsDelegateOpen_3() const { return ___m_IsDelegateOpen_3; }
	inline bool* get_address_of_m_IsDelegateOpen_3() { return &___m_IsDelegateOpen_3; }
	inline void set_m_IsDelegateOpen_3(bool value)
	{
		___m_IsDelegateOpen_3 = value;
	}
};


// System.MulticastDelegate
struct  MulticastDelegate_t  : public Delegate_t
{
public:
	// System.MulticastDelegate[] System.MulticastDelegate::delegates
	MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54* ___delegates_4;
	// System.Int32 System.MulticastDelegate::delegateCount
	int32_t ___delegateCount_5;

public:
	inline MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54* get_delegates_4() const { return ___delegates_4; }
	inline MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54** get_address_of_delegates_4() { return &___delegates_4; }
	inline void set_delegates_4(MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54* value)
	{
		___delegates_4 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___delegates_4), (void*)value);
	}

	inline int32_t get_delegateCount_5() const { return ___delegateCount_5; }
	inline int32_t* get_address_of_delegateCount_5() { return &___delegateCount_5; }
	inline void set_delegateCount_5(int32_t value)
	{
		___delegateCount_5 = value;
	}
};


// Unity.Jobs.EarlyInitHelpers/EarlyInitFunction
struct  EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D  : public MulticastDelegate_t
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.MulticastDelegate[]
struct MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54  : public RuntimeArray
{
public:
	ALIGN_FIELD (8) MulticastDelegate_t * m_Items[1];

public:
	inline MulticastDelegate_t * GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline MulticastDelegate_t ** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, MulticastDelegate_t * value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline MulticastDelegate_t * GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline MulticastDelegate_t ** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, MulticastDelegate_t * value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};



// !0 System.Collections.Generic.List`1<Unity.Jobs.EarlyInitHelpers/EarlyInitFunction>::get_Item(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D * List_1_get_Item_mAB85BBBA87AC3805A1D7E200DCFB6ACA1E54A568 (List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * __this, int32_t ___index0);
// System.Void Unity.Jobs.EarlyInitHelpers/EarlyInitFunction::Invoke()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EarlyInitFunction_Invoke_m0258482E109D2FDF6D56D5E337642492735D05EB (EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D * __this);
// System.Void UnityEngine.Debug::LogException(System.Exception)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_LogException_m7BF3DEB4C77AF0DE416259599D4FF48CFE60438F (Exception_t * ___exception0);
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
void* EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields_Storage = (void*)sizeof(EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_EarlyInitHelpers_FlushEarlyInits_mFA176BE1ABC6522CCF9F39A6E27EC87CE8CAC503()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Jobs.EarlyInitHelpers::FlushEarlyInits()", "it does not have the [MonoPInvokeCallback] attribute.");
}
// System.Void Unity.Jobs.EarlyInitHelpers::FlushEarlyInits()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EarlyInitHelpers_FlushEarlyInits_mFA176BE1ABC6522CCF9F39A6E27EC87CE8CAC503 ()
{
	List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * V_0 = NULL;
	int32_t V_1 = 0;
	Exception_t * __last_unhandled_exception = 0;
	NO_UNUSED_WARNING (__last_unhandled_exception);
	Exception_t * __exception_local = 0;
	NO_UNUSED_WARNING (__exception_local);
	void* __leave_targets_storage = alloca(sizeof(int32_t) * 2);
	il2cpp::utils::LeaveTargetStack __leave_targets(__leave_targets_storage);
	NO_UNUSED_WARNING (__leave_targets);
	{
		goto IL_0035;
	}

IL_0002:
	{
		List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * L_0 = ((EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields*)EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields_Storage)->get_s_PendingDelegates_0();
		V_0 = L_0;
		((EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields*)EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields_Storage)->set_s_PendingDelegates_0((List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE *)NULL);
		V_1 = 0;
		goto IL_002c;
	}

IL_0012:
	{
	}

IL_0013:
	//try - Try blocks are not supported with the Tiny profile
	{ // begin try (depth: 1)
		List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * L_1 = V_0;
		int32_t L_2 = V_1;
		EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D * L_3;
		L_3 = List_1_get_Item_mAB85BBBA87AC3805A1D7E200DCFB6ACA1E54A568(L_1, L_2);
		EarlyInitFunction_Invoke_m0258482E109D2FDF6D56D5E337642492735D05EB(L_3);
		goto IL_0028;
	} // end try (depth: 1)
	/* Catch blocks are not supported with the Tiny profile
	catch(Il2CppExceptionWrapper& e)
	{
		__exception_local = (Exception_t *)e.ex;
		if(il2cpp_codegen_class_is_assignable_from (LookupTypeInfoFromCursor(TINY_TYPE_OFFSET_Exception_t), il2cpp_codegen_object_class(e.ex)))
			goto CATCH_0021;
		throw e;
	}
	*/

CATCH_0021:
	{ // begin catch(System.Exception)
		Debug_LogException_m7BF3DEB4C77AF0DE416259599D4FF48CFE60438F(((Exception_t *)__exception_local));
		goto IL_0028;
	} // end catch (depth: 1)

IL_0028:
	{
		int32_t L_4 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add((int32_t)L_4, (int32_t)1));
	}

IL_002c:
	{
		int32_t L_5 = V_1;
		List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * L_6 = V_0;
		int32_t L_7 = L_6->get__size_1();
		if ((((int32_t)L_5) < ((int32_t)L_7)))
		{
			goto IL_0012;
		}
	}

IL_0035:
	{
		List_1_t0783895F346834EC92951D2B4E9F8200BAE712EE * L_8 = ((EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields*)EarlyInitHelpers_tB5B2F7FC72C1C881232E63CEBF519A5DE4C026C2_StaticFields_Storage)->get_s_PendingDelegates_0();
		if (L_8)
		{
			goto IL_0002;
		}
	}
	{
		return;
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
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IJobParallelForDeferExtensions_Schedule_m931D6207A12990BC9D22133D445E2B81D1AD6164()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Jobs.JobHandle Unity.Jobs.IJobParallelForDeferExtensions::Schedule(T,Unity.Collections.NativeList`1<U>,System.Int32,Unity.Jobs.JobHandle)", "it has generic parameters.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IJobParallelForDeferExtensions_Schedule_mD03F4E4A92FB9A3D61E4562E018AAC473495065F()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Jobs.JobHandle Unity.Jobs.IJobParallelForDeferExtensions::Schedule(T,System.Int32*,System.Int32,Unity.Jobs.JobHandle)", "it has generic parameters.");
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_EarlyInitFunction__ctor_mEA3E437A40AC6F623E1426F42582CD30E81C77D7()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Jobs.EarlyInitHelpers/EarlyInitFunction::.ctor(System.Object,System.IntPtr)", "it is an instance method. Only static methods can be called back from native code.");
}
IL2CPP_EXTERN_C  void DelegatePInvokeWrapper_EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D (EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D * __this)
{
	typedef void (DEFAULT_CALL *PInvokeFunc)();
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(__this);

	// Native function invocation
	il2cppPInvokeFunc();

}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_EarlyInitFunction_Invoke_m0258482E109D2FDF6D56D5E337642492735D05EB()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Jobs.EarlyInitHelpers/EarlyInitFunction::Invoke()", "it is an instance method. Only static methods can be called back from native code.");
}
// System.Void Unity.Jobs.EarlyInitHelpers/EarlyInitFunction::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EarlyInitFunction__ctor_mEA3E437A40AC6F623E1426F42582CD30E81C77D7 (EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D * __this, RuntimeObject * ___object0, intptr_t ___method1)
{
	__this->set_method_ptr_0(___method1);
	__this->set_m_target_1(___object0);
}
// System.Void Unity.Jobs.EarlyInitHelpers/EarlyInitFunction::Invoke()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void EarlyInitFunction_Invoke_m0258482E109D2FDF6D56D5E337642492735D05EB (EarlyInitFunction_tCDA8C92B74893CCA9D606AE969CBA730C4D6776D * __this)
{
	MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54* delegateArrayToInvoke = __this->get_delegates_4();
	Delegate_t** delegatesToInvoke;
	il2cpp_array_size_t length;
	if (delegateArrayToInvoke != NULL)
	{
		length = __this->get_delegateCount_5();
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(delegateArrayToInvoke->GetAddressAtUnchecked(0));
	}
	else
	{
		length = 1;
		delegatesToInvoke = reinterpret_cast<Delegate_t**>(&__this);
	}

	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		Delegate_t* currentDelegate = delegatesToInvoke[i];
		intptr_t targetMethodPointer = currentDelegate->get_method_ptr_0();
		RuntimeObject* targetThis = currentDelegate->get_m_target_1();
		if (currentDelegate->get_m_IsDelegateOpen_3())
		{
			typedef void (*FunctionPointerType) ();
			((FunctionPointerType)targetMethodPointer)();
		}
		else
		{
			typedef void (*FunctionPointerType) (void*);
			((FunctionPointerType)targetMethodPointer)(targetThis);
		}
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
