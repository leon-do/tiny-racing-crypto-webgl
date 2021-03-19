#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>

#include "StringLiteralsOffsets.h"


// System.MulticastDelegate[]
struct MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54;
// System.Attribute
struct Attribute_t0712C5F28B527826C7BC0539654367D66FF7F289;
// System.MulticastDelegate
struct MulticastDelegate_t;
// System.String
struct String_t;
// System.Void
struct Void_t39CB6A4CCC637097970C8F4936C9B344C27FEEA9;
// Unity.Platforms.RunLoop/RunLoopDelegate
struct RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F;
// Unity.Platforms.RunLoopImpl/MonoPInvokeCallbackAttribute
struct MonoPInvokeCallbackAttribute_t51A12D1564348616D39272C37B96E678C87BA1AC;

IL2CPP_EXTERN_C String_t* _stringLiteralB40E9CA1F89355D9EAE132706D7C9CC331B26E8F;
IL2CPP_EXTERN_C const RuntimeMethod Attribute__ctor_m54BE022F2D0A04FE644D1F971FCAB6C40502874A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod Console_WriteLine_m3E132428C6277A6897FF963B45A1C90D43410A13_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod HTMLNativeCalls_set_animation_frame_callback_mAE1502039DA88F3AA0309957CE44DDEC19229E4D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod RunLoopDelegate_Invoke_m330E1BD5AB58024C38503BE4948F4ADC05F783EF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod RunLoopDelegate__ctor_m6A8F9B2BE3EEA2710CBBC84058F5058DC45CB25F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod RunLoopImpl_EnterMainLoop_m6ABE4253A50C43D489B0168F9152440D3D1320BB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod RunLoopImpl_ManagedRAFCallback_mD6C192DE80B640C94F9EDAB2D9EA7D1B52D7442A_RuntimeMethod_var;
IL2CPP_EXTERN_C const uint32_t TINY_TYPE_OFFSET_RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F;

struct MulticastDelegateU5BU5D_t3086C8E59092F9A1DC9A455DE88F452C2746DE54;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t6C8B943A0974D412B63ECE092EA77F18D3B0E197 
{
public:

public:
};


// System.Object

struct Il2CppArrayBounds;

// System.Array


// System.Attribute
struct  Attribute_t0712C5F28B527826C7BC0539654367D66FF7F289  : public RuntimeObject
{
public:

public:
};


// Unity.Platforms.HTMLNativeCalls
struct  HTMLNativeCalls_t3A847050BBBC704EA3F4E7EDA12B63CBBB72D167  : public RuntimeObject
{
public:

public:
};


// Unity.Platforms.RunLoop
struct  RunLoop_t4E038731884DB2E4F679C95E792BE818F2684D6A  : public RuntimeObject
{
public:

public:
};

extern void* RunLoop_t4E038731884DB2E4F679C95E792BE818F2684D6A_StaticFields_Storage;
struct RunLoop_t4E038731884DB2E4F679C95E792BE818F2684D6A_StaticFields
{
public:
	// Unity.Platforms.RunLoop/RunLoopDelegate Unity.Platforms.RunLoop::<CurrentRunLoopDelegate>k__BackingField
	RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * ___U3CCurrentRunLoopDelegateU3Ek__BackingField_0;

public:
	inline RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * get_U3CCurrentRunLoopDelegateU3Ek__BackingField_0() const { return ___U3CCurrentRunLoopDelegateU3Ek__BackingField_0; }
	inline RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F ** get_address_of_U3CCurrentRunLoopDelegateU3Ek__BackingField_0() { return &___U3CCurrentRunLoopDelegateU3Ek__BackingField_0; }
	inline void set_U3CCurrentRunLoopDelegateU3Ek__BackingField_0(RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * value)
	{
		___U3CCurrentRunLoopDelegateU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CCurrentRunLoopDelegateU3Ek__BackingField_0), (void*)value);
	}
};


// Unity.Platforms.RunLoopImpl
struct  RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D  : public RuntimeObject
{
public:

public:
};

extern void* RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields_Storage;
struct RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields
{
public:
	// System.Boolean Unity.Platforms.RunLoopImpl::<DisableTicks>k__BackingField
	bool ___U3CDisableTicksU3Ek__BackingField_0;
	// Unity.Platforms.RunLoop/RunLoopDelegate Unity.Platforms.RunLoopImpl::staticM
	RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * ___staticM_1;
	// Unity.Platforms.RunLoop/RunLoopDelegate Unity.Platforms.RunLoopImpl::staticManagedDelegate
	RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * ___staticManagedDelegate_2;

public:
	inline bool get_U3CDisableTicksU3Ek__BackingField_0() const { return ___U3CDisableTicksU3Ek__BackingField_0; }
	inline bool* get_address_of_U3CDisableTicksU3Ek__BackingField_0() { return &___U3CDisableTicksU3Ek__BackingField_0; }
	inline void set_U3CDisableTicksU3Ek__BackingField_0(bool value)
	{
		___U3CDisableTicksU3Ek__BackingField_0 = value;
	}

	inline RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * get_staticM_1() const { return ___staticM_1; }
	inline RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F ** get_address_of_staticM_1() { return &___staticM_1; }
	inline void set_staticM_1(RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * value)
	{
		___staticM_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___staticM_1), (void*)value);
	}

	inline RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * get_staticManagedDelegate_2() const { return ___staticManagedDelegate_2; }
	inline RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F ** get_address_of_staticManagedDelegate_2() { return &___staticManagedDelegate_2; }
	inline void set_staticManagedDelegate_2(RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * value)
	{
		___staticManagedDelegate_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___staticManagedDelegate_2), (void*)value);
	}
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

// System.Boolean
struct  Boolean_tBDBDB23D0BC3A1E051C3029ADAACC0AD78A40D91 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Boolean_tBDBDB23D0BC3A1E051C3029ADAACC0AD78A40D91__padding[1];
	};

public:
};


// System.Double
struct  Double_t0D0B40845C3D09CA2DDDA8E25625E31345305D7E 
{
public:
	// System.Double System.Double::m_value
	double ___m_value_0;

public:
	inline double get_m_value_0() const { return ___m_value_0; }
	inline double* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(double value)
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


// Unity.Platforms.RunLoopImpl/MonoPInvokeCallbackAttribute
struct  MonoPInvokeCallbackAttribute_t51A12D1564348616D39272C37B96E678C87BA1AC  : public Attribute_t0712C5F28B527826C7BC0539654367D66FF7F289
{
public:

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


// Unity.Platforms.RunLoop/RunLoopDelegate
struct  RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F  : public MulticastDelegate_t
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

extern "C" int32_t DEFAULT_CALL ReversePInvokeWrapper_RunLoopImpl_ManagedRAFCallback_mD6C192DE80B640C94F9EDAB2D9EA7D1B52D7442A(double ___timestampInSeconds0);


// System.Void Unity.Platforms.RunLoopImpl::EnterMainLoop(Unity.Platforms.RunLoop/RunLoopDelegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RunLoopImpl_EnterMainLoop_m6ABE4253A50C43D489B0168F9152440D3D1320BB (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * ___runLoopDelegate0);
// System.Boolean Unity.Platforms.RunLoopImpl::ManagedRAFCallback(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool RunLoopImpl_ManagedRAFCallback_mD6C192DE80B640C94F9EDAB2D9EA7D1B52D7442A (double ___timestampInSeconds0);
// System.Boolean Unity.Platforms.RunLoop/RunLoopDelegate::Invoke(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool RunLoopDelegate_Invoke_m330E1BD5AB58024C38503BE4948F4ADC05F783EF (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * __this, double ___timestampInSeconds0);
// System.Void Unity.Platforms.RunLoop/RunLoopDelegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RunLoopDelegate__ctor_m6A8F9B2BE3EEA2710CBBC84058F5058DC45CB25F (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * __this, RuntimeObject * ___object0, intptr_t ___method1);
// System.Boolean Unity.Platforms.HTMLNativeCalls::set_animation_frame_callback(System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool HTMLNativeCalls_set_animation_frame_callback_mAE1502039DA88F3AA0309957CE44DDEC19229E4D (intptr_t ___func0);
// System.Void System.Console::WriteLine(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Console_WriteLine_m3E132428C6277A6897FF963B45A1C90D43410A13 (String_t* ___input0);
// System.Void System.Attribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Attribute__ctor_m54BE022F2D0A04FE644D1F971FCAB6C40502874A (Attribute_t0712C5F28B527826C7BC0539654367D66FF7F289 * __this);
#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_html_INTERNAL
IL2CPP_EXTERN_C int8_t DEFAULT_CALL rafcallbackinit_html(intptr_t);
#endif
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
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_HTMLNativeCalls_set_animation_frame_callback_mAE1502039DA88F3AA0309957CE44DDEC19229E4D()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Boolean Unity.Platforms.HTMLNativeCalls::set_animation_frame_callback(System.IntPtr)", "it does not have the [MonoPInvokeCallback] attribute.");
}
// System.Boolean Unity.Platforms.HTMLNativeCalls::set_animation_frame_callback(System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool HTMLNativeCalls_set_animation_frame_callback_mAE1502039DA88F3AA0309957CE44DDEC19229E4D (intptr_t ___func0)
{
	typedef int8_t (DEFAULT_CALL *PInvokeFunc) (intptr_t);
	#if !FORCE_PINVOKE_INTERNAL && !FORCE_PINVOKE_lib_unity_tiny_html_INTERNAL
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(intptr_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("lib_unity_tiny_html"), "rafcallbackinit_html", IL2CPP_CALL_DEFAULT, CHARSET_NOT_SPECIFIED, parameterSize, false);
		IL2CPP_ASSERT(il2cppPInvokeFunc != NULL);
	}
	#endif

	// Native function invocation
	#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_html_INTERNAL
	int8_t returnValue = reinterpret_cast<PInvokeFunc>(rafcallbackinit_html)(___func0);
	#else
	int8_t returnValue = il2cppPInvokeFunc(___func0);
	#endif

	return static_cast<bool>(returnValue);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void* RunLoop_t4E038731884DB2E4F679C95E792BE818F2684D6A_StaticFields_Storage = (void*)sizeof(RunLoop_t4E038731884DB2E4F679C95E792BE818F2684D6A_StaticFields);
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_RunLoop_EnterMainLoop_mFBDF03F8383490F657BB0367C022CC82E2D2AC01()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Platforms.RunLoop::EnterMainLoop(Unity.Platforms.RunLoop/RunLoopDelegate)", "it does not have the [MonoPInvokeCallback] attribute.");
}
// System.Void Unity.Platforms.RunLoop::EnterMainLoop(Unity.Platforms.RunLoop/RunLoopDelegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RunLoop_EnterMainLoop_mFBDF03F8383490F657BB0367C022CC82E2D2AC01 (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * ___runLoopDelegate0)
{
	{
		RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * L_0 = ___runLoopDelegate0;
		((RunLoop_t4E038731884DB2E4F679C95E792BE818F2684D6A_StaticFields*)RunLoop_t4E038731884DB2E4F679C95E792BE818F2684D6A_StaticFields_Storage)->set_U3CCurrentRunLoopDelegateU3Ek__BackingField_0(L_0);
		RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * L_1 = ___runLoopDelegate0;
		RunLoopImpl_EnterMainLoop_m6ABE4253A50C43D489B0168F9152440D3D1320BB(L_1);
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
void* RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields_Storage = (void*)sizeof(RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields);
extern "C" int32_t DEFAULT_CALL ReversePInvokeWrapper_RunLoopImpl_ManagedRAFCallback_mD6C192DE80B640C94F9EDAB2D9EA7D1B52D7442A(double ___timestampInSeconds0)
{
	tiny::vm::ScopedThreadAttacher _vmThreadHelper;

	// Managed method invocation
	bool returnValue;
	returnValue = RunLoopImpl_ManagedRAFCallback_mD6C192DE80B640C94F9EDAB2D9EA7D1B52D7442A(___timestampInSeconds0);

	return static_cast<int32_t>(returnValue);
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_RunLoopImpl_EnterMainLoop_m6ABE4253A50C43D489B0168F9152440D3D1320BB()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Platforms.RunLoopImpl::EnterMainLoop(Unity.Platforms.RunLoop/RunLoopDelegate)", "it does not have the [MonoPInvokeCallback] attribute.");
}
// System.Boolean Unity.Platforms.RunLoopImpl::ManagedRAFCallback(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool RunLoopImpl_ManagedRAFCallback_mD6C192DE80B640C94F9EDAB2D9EA7D1B52D7442A (double ___timestampInSeconds0)
{
	{
		bool L_0 = ((RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields*)RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields_Storage)->get_U3CDisableTicksU3Ek__BackingField_0();
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		return (bool)1;
	}

IL_0009:
	{
		RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * L_1 = ((RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields*)RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields_Storage)->get_staticM_1();
		double L_2 = ___timestampInSeconds0;
		bool L_3;
		L_3 = RunLoopDelegate_Invoke_m330E1BD5AB58024C38503BE4948F4ADC05F783EF(L_1, L_2);
		return L_3;
	}
}
// System.Void Unity.Platforms.RunLoopImpl::EnterMainLoop(Unity.Platforms.RunLoop/RunLoopDelegate)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RunLoopImpl_EnterMainLoop_m6ABE4253A50C43D489B0168F9152440D3D1320BB (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * ___runLoopDelegate0)
{
	{
		// staticManagedDelegate = (RunLoop.RunLoopDelegate)ManagedRAFCallback;
		intptr_t L_0 = (intptr_t)RunLoopImpl_ManagedRAFCallback_mD6C192DE80B640C94F9EDAB2D9EA7D1B52D7442A;
		RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * L_1 = (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F *)il2cpp_codegen_object_new(sizeof(RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F), LookupTypeInfoFromCursor(TINY_TYPE_OFFSET_RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F));
		RunLoopDelegate__ctor_m6A8F9B2BE3EEA2710CBBC84058F5058DC45CB25F(L_1, NULL, (intptr_t)L_0);
		L_1->set_m_ReversePInvokeWrapperPtr_2(reinterpret_cast<void*>(ReversePInvokeWrapper_RunLoopImpl_ManagedRAFCallback_mD6C192DE80B640C94F9EDAB2D9EA7D1B52D7442A));
		L_1->set_m_IsDelegateOpen_3(true);
		((RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields*)RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields_Storage)->set_staticManagedDelegate_2(L_1);
		// staticM = runLoopDelegate;
		RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * L_2 = ___runLoopDelegate0;
		((RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields*)RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields_Storage)->set_staticM_1(L_2);
		// HTMLNativeCalls.set_animation_frame_callback(Marshal.GetFunctionPointerForDelegate(staticManagedDelegate));
		RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * L_3 = ((RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields*)RunLoopImpl_t295FA0A951D616BFD6D5B892E5B496CABA75768D_StaticFields_Storage)->get_staticManagedDelegate_2();
		intptr_t L_4;
		L_4 = il2cpp_codegen_marshal_get_function_pointer_for_delegate(L_3);
		bool L_5;
		L_5 = HTMLNativeCalls_set_animation_frame_callback_mAE1502039DA88F3AA0309957CE44DDEC19229E4D((intptr_t)L_4);
		// Console.WriteLine("HTML Main loop exiting.");
		Console_WriteLine_m3E132428C6277A6897FF963B45A1C90D43410A13(LookupStringFromCursor(TINY_STRING_OFFSET__stringLiteralB40E9CA1F89355D9EAE132706D7C9CC331B26E8F));
		// }
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
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_RunLoopDelegate__ctor_m6A8F9B2BE3EEA2710CBBC84058F5058DC45CB25F()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Platforms.RunLoop/RunLoopDelegate::.ctor(System.Object,System.IntPtr)", "it is an instance method. Only static methods can be called back from native code.");
}
IL2CPP_EXTERN_C  bool DelegatePInvokeWrapper_RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * __this, double ___timestampInSeconds0)
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc)(double);
	PInvokeFunc il2cppPInvokeFunc = reinterpret_cast<PInvokeFunc>(__this);

	// Native function invocation
	int32_t returnValue = il2cppPInvokeFunc(___timestampInSeconds0);

	return static_cast<bool>(returnValue);
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_RunLoopDelegate_Invoke_m330E1BD5AB58024C38503BE4948F4ADC05F783EF()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Boolean Unity.Platforms.RunLoop/RunLoopDelegate::Invoke(System.Double)", "it is an instance method. Only static methods can be called back from native code.");
}
// System.Void Unity.Platforms.RunLoop/RunLoopDelegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RunLoopDelegate__ctor_m6A8F9B2BE3EEA2710CBBC84058F5058DC45CB25F (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * __this, RuntimeObject * ___object0, intptr_t ___method1)
{
	__this->set_method_ptr_0(___method1);
	__this->set_m_target_1(___object0);
}
// System.Boolean Unity.Platforms.RunLoop/RunLoopDelegate::Invoke(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool RunLoopDelegate_Invoke_m330E1BD5AB58024C38503BE4948F4ADC05F783EF (RunLoopDelegate_tA6D60A6D9F5F4FA68DFEDF612ED958AA375E689F * __this, double ___timestampInSeconds0)
{
	bool result = false;
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
			typedef bool (*FunctionPointerType) (double);
			result = ((FunctionPointerType)targetMethodPointer)(___timestampInSeconds0);
		}
		else
		{
			typedef bool (*FunctionPointerType) (void*, double);
			result = ((FunctionPointerType)targetMethodPointer)(targetThis, ___timestampInSeconds0);
		}
	}
	return result;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MonoPInvokeCallbackAttribute__ctor_m91627E6CE5CE69357C93030FD260D92B2211CB87()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Platforms.RunLoopImpl/MonoPInvokeCallbackAttribute::.ctor()", "it is an instance method. Only static methods can be called back from native code.");
}
// System.Void Unity.Platforms.RunLoopImpl/MonoPInvokeCallbackAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoPInvokeCallbackAttribute__ctor_m91627E6CE5CE69357C93030FD260D92B2211CB87 (MonoPInvokeCallbackAttribute_t51A12D1564348616D39272C37B96E678C87BA1AC * __this)
{
	{
		Attribute__ctor_m54BE022F2D0A04FE644D1F971FCAB6C40502874A(__this);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
