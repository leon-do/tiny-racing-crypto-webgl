#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>

#include "StringLiteralsOffsets.h"


// System.String
struct String_t;

IL2CPP_EXTERN_C String_t* _stringLiteral58CAF06C9442050A0714C256C1B1A040FBEF28A1;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_CloseImpl_m615D38894685D494B1CCFDC921324CBC010D924A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_Dispose_m771B4F3203E94484DF35B0AC0FC93394DF3E0866_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_GetDataImpl_mB67316C777727182AB705AE8CAE5BE33E9F316AA_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_GetData_m68729EE197F2A4FF7D5804476AD1A2B021FC78BE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_GetErrorStatusImpl_m5AD06F1277B01A364F916236966AC3C3F49A006B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_GetErrorStatus_mE9D2C005FDE12B1A2B7B7B59382542107C53949A_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_GetStatusImpl_m26620AAC30789F5F11B0D25FCE28CCD87E6B56A7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_GetStatus_mF16724C614D0DC14E91C052269BEB5517CE219F2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_ToString_m30ECB5BCB5245B2E6E668B844A13227EC03A2C23_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp__ctor_m9DD0B5DFA94AEB7109951B3A984121C660156859_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AsyncOp_get_IsCreated_m601BC7B39968C7908117C455AABEAFF4FB6E152C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod IOService_RequestAsyncReadImpl_mDFF9AC5788369EC0F437667977B63CFB94D6AE79_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod String_Format_mF264B41D046F53C19626C3EAA5633294A0236D62_RuntimeMethod_var;
IL2CPP_EXTERN_C const uint32_t TINY_TYPE_OFFSET_Int32_tBC6089C5C93BC1423D3EA683333151645C66E22A;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t4457354C0506A927A79E296C72B92F909D2E81AD 
{
public:

public:
};


// System.Object

struct Il2CppArrayBounds;

// System.Array


// Unity.Tiny.IO.IOService
struct  IOService_tE8849DC50A595FDDFD1C084DDD7C2AA1E93420AF  : public RuntimeObject
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

// Unity.Tiny.IO.AsyncOp
struct  AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 
{
public:
	// System.Int32 Unity.Tiny.IO.AsyncOp::m_Handle
	int32_t ___m_Handle_0;

public:
	inline int32_t get_m_Handle_0() const { return ___m_Handle_0; }
	inline int32_t* get_address_of_m_Handle_0() { return &___m_Handle_0; }
	inline void set_m_Handle_0(int32_t value)
	{
		___m_Handle_0 = value;
	}
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


// System.Byte
struct  Byte_tB2B6CDA44347D99B0027043DD6C50B2746A54AEE 
{
public:
	// System.Byte System.Byte::m_value
	uint8_t ___m_value_0;

public:
	inline uint8_t get_m_value_0() const { return ___m_value_0; }
	inline uint8_t* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(uint8_t value)
	{
		___m_value_0 = value;
	}
};


// System.Enum
struct  Enum_tFDDEC8EBF44E40C0E22B2D619177E36FC073A77C  : public ValueType_t9E835CDBB7CA8FF62C1E998C186DBB81B6242C94
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.Enum
struct Enum_tFDDEC8EBF44E40C0E22B2D619177E36FC073A77C_marshaled_pinvoke
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


// Unity.Tiny.IO.AsyncOp/ErrorStatus
struct  ErrorStatus_t50E1036C4CF0B706C4328922873015560B935CE6 
{
public:
	// System.Int32 Unity.Tiny.IO.AsyncOp/ErrorStatus::value__
	int32_t ___value___0;

public:
	inline int32_t get_value___0() const { return ___value___0; }
	inline int32_t* get_address_of_value___0() { return &___value___0; }
	inline void set_value___0(int32_t value)
	{
		___value___0 = value;
	}
};


// Unity.Tiny.IO.AsyncOp/Status
struct  Status_t9B5887C1E84648EBCBBEE6F6EDC4300A2CAC678E 
{
public:
	// System.Int32 Unity.Tiny.IO.AsyncOp/Status::value__
	int32_t ___value___0;

public:
	inline int32_t get_value___0() const { return ___value___0; }
	inline int32_t* get_address_of_value___0() { return &___value___0; }
	inline void set_value___0(int32_t value)
	{
		___value___0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void Unity.Tiny.IO.AsyncOp::.ctor(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void AsyncOp__ctor_m9DD0B5DFA94AEB7109951B3A984121C660156859_inline (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this, int32_t ___sysHandle0);
// System.Int32 Unity.Tiny.IO.AsyncOp::GetStatusImpl(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AsyncOp_GetStatusImpl_m26620AAC30789F5F11B0D25FCE28CCD87E6B56A7 (int32_t ___handle0);
// Unity.Tiny.IO.AsyncOp/Status Unity.Tiny.IO.AsyncOp::GetStatus()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AsyncOp_GetStatus_mF16724C614D0DC14E91C052269BEB5517CE219F2 (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this);
// System.Int32 Unity.Tiny.IO.AsyncOp::GetErrorStatusImpl(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AsyncOp_GetErrorStatusImpl_m5AD06F1277B01A364F916236966AC3C3F49A006B (int32_t ___handle0);
// Unity.Tiny.IO.AsyncOp/ErrorStatus Unity.Tiny.IO.AsyncOp::GetErrorStatus()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AsyncOp_GetErrorStatus_mE9D2C005FDE12B1A2B7B7B59382542107C53949A (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this);
// System.Void Unity.Tiny.IO.AsyncOp::CloseImpl(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp_CloseImpl_m615D38894685D494B1CCFDC921324CBC010D924A (int32_t ___handle0);
// System.Void Unity.Tiny.IO.AsyncOp::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp_Dispose_m771B4F3203E94484DF35B0AC0FC93394DF3E0866 (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this);
// System.Void Unity.Tiny.IO.AsyncOp::GetDataImpl(System.Int32,System.Byte*&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp_GetDataImpl_mB67316C777727182AB705AE8CAE5BE33E9F316AA (int32_t ___handle0, uint8_t** ___data1, int32_t* ___sizeInBytes2);
// System.Void Unity.Tiny.IO.AsyncOp::GetData(System.Byte*&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp_GetData_m68729EE197F2A4FF7D5804476AD1A2B021FC78BE (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this, uint8_t** ___data0, int32_t* ___sizeInBytes1);
// System.Boolean Unity.Tiny.IO.AsyncOp::get_IsCreated()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AsyncOp_get_IsCreated_m601BC7B39968C7908117C455AABEAFF4FB6E152C (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this);
// System.String System.String::Format(System.String,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_mF264B41D046F53C19626C3EAA5633294A0236D62 (String_t* ___format0, RuntimeObject * ___arg11);
// System.String Unity.Tiny.IO.AsyncOp::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* AsyncOp_ToString_m30ECB5BCB5245B2E6E668B844A13227EC03A2C23 (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this);
// System.Int32 Unity.Tiny.IO.IOService::RequestAsyncReadImpl(System.String,System.Void*,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t IOService_RequestAsyncReadImpl_mDFF9AC5788369EC0F437667977B63CFB94D6AE79 (String_t* ___path0, void* ___buffer1, int32_t ___bufferSize2);
#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
IL2CPP_EXTERN_C int32_t DEFAULT_CALL GetStatus(int32_t);
#endif
#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
IL2CPP_EXTERN_C int32_t DEFAULT_CALL GetErrorStatus(int32_t);
#endif
#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
IL2CPP_EXTERN_C void DEFAULT_CALL Close(int32_t);
#endif
#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
IL2CPP_EXTERN_C void DEFAULT_CALL GetData(int32_t, uint8_t**, int32_t*);
#endif
#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
IL2CPP_EXTERN_C int32_t DEFAULT_CALL RequestAsyncRead(char*, void*, int32_t);
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
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp__ctor_m9DD0B5DFA94AEB7109951B3A984121C660156859()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Tiny.IO.AsyncOp::.ctor(System.Int32)", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_GetStatus_mF16724C614D0DC14E91C052269BEB5517CE219F2()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Tiny.IO.AsyncOp/Status Unity.Tiny.IO.AsyncOp::GetStatus()", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_GetErrorStatus_mE9D2C005FDE12B1A2B7B7B59382542107C53949A()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Tiny.IO.AsyncOp/ErrorStatus Unity.Tiny.IO.AsyncOp::GetErrorStatus()", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_Dispose_m771B4F3203E94484DF35B0AC0FC93394DF3E0866()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Tiny.IO.AsyncOp::Dispose()", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_GetData_m68729EE197F2A4FF7D5804476AD1A2B021FC78BE()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Tiny.IO.AsyncOp::GetData(System.Byte*&,System.Int32&)", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_get_IsCreated_m601BC7B39968C7908117C455AABEAFF4FB6E152C()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Boolean Unity.Tiny.IO.AsyncOp::get_IsCreated()", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_ToString_m30ECB5BCB5245B2E6E668B844A13227EC03A2C23()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.String Unity.Tiny.IO.AsyncOp::ToString()", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_GetStatusImpl_m26620AAC30789F5F11B0D25FCE28CCD87E6B56A7()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Int32 Unity.Tiny.IO.AsyncOp::GetStatusImpl(System.Int32)", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_GetErrorStatusImpl_m5AD06F1277B01A364F916236966AC3C3F49A006B()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Int32 Unity.Tiny.IO.AsyncOp::GetErrorStatusImpl(System.Int32)", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_CloseImpl_m615D38894685D494B1CCFDC921324CBC010D924A()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Tiny.IO.AsyncOp::CloseImpl(System.Int32)", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AsyncOp_GetDataImpl_mB67316C777727182AB705AE8CAE5BE33E9F316AA()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Tiny.IO.AsyncOp::GetDataImpl(System.Int32,System.Byte*&,System.Int32&)", "it does not have the [MonoPInvokeCallback] attribute.");
}
// System.Void Unity.Tiny.IO.AsyncOp::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp__ctor_m9DD0B5DFA94AEB7109951B3A984121C660156859 (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this, int32_t ___sysHandle0)
{
	{
		// m_Handle = sysHandle;
		int32_t L_0 = ___sysHandle0;
		__this->set_m_Handle_0(L_0);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void AsyncOp__ctor_m9DD0B5DFA94AEB7109951B3A984121C660156859_AdjustorThunk (RuntimeObject * __this, int32_t ___sysHandle0)
{
	AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 *>(__this + _offset);
	AsyncOp__ctor_m9DD0B5DFA94AEB7109951B3A984121C660156859_inline(_thisAdjusted, ___sysHandle0);
}
// Unity.Tiny.IO.AsyncOp/Status Unity.Tiny.IO.AsyncOp::GetStatus()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AsyncOp_GetStatus_mF16724C614D0DC14E91C052269BEB5517CE219F2 (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this)
{
	{
		// return (Status)GetStatusImpl(m_Handle);
		int32_t L_0 = __this->get_m_Handle_0();
		int32_t L_1;
		L_1 = AsyncOp_GetStatusImpl_m26620AAC30789F5F11B0D25FCE28CCD87E6B56A7(L_0);
		return (int32_t)(L_1);
	}
}
IL2CPP_EXTERN_C  int32_t AsyncOp_GetStatus_mF16724C614D0DC14E91C052269BEB5517CE219F2_AdjustorThunk (RuntimeObject * __this)
{
	AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = AsyncOp_GetStatus_mF16724C614D0DC14E91C052269BEB5517CE219F2(_thisAdjusted);
	return _returnValue;
}
// Unity.Tiny.IO.AsyncOp/ErrorStatus Unity.Tiny.IO.AsyncOp::GetErrorStatus()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AsyncOp_GetErrorStatus_mE9D2C005FDE12B1A2B7B7B59382542107C53949A (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this)
{
	{
		// return (ErrorStatus)GetErrorStatusImpl(m_Handle);
		int32_t L_0 = __this->get_m_Handle_0();
		int32_t L_1;
		L_1 = AsyncOp_GetErrorStatusImpl_m5AD06F1277B01A364F916236966AC3C3F49A006B(L_0);
		return (int32_t)(L_1);
	}
}
IL2CPP_EXTERN_C  int32_t AsyncOp_GetErrorStatus_mE9D2C005FDE12B1A2B7B7B59382542107C53949A_AdjustorThunk (RuntimeObject * __this)
{
	AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 *>(__this + _offset);
	int32_t _returnValue;
	_returnValue = AsyncOp_GetErrorStatus_mE9D2C005FDE12B1A2B7B7B59382542107C53949A(_thisAdjusted);
	return _returnValue;
}
// System.Void Unity.Tiny.IO.AsyncOp::Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp_Dispose_m771B4F3203E94484DF35B0AC0FC93394DF3E0866 (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this)
{
	{
		// CloseImpl(m_Handle);
		int32_t L_0 = __this->get_m_Handle_0();
		AsyncOp_CloseImpl_m615D38894685D494B1CCFDC921324CBC010D924A(L_0);
		// m_Handle = 0;
		__this->set_m_Handle_0(0);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void AsyncOp_Dispose_m771B4F3203E94484DF35B0AC0FC93394DF3E0866_AdjustorThunk (RuntimeObject * __this)
{
	AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 *>(__this + _offset);
	AsyncOp_Dispose_m771B4F3203E94484DF35B0AC0FC93394DF3E0866(_thisAdjusted);
}
// System.Void Unity.Tiny.IO.AsyncOp::GetData(System.Byte*&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp_GetData_m68729EE197F2A4FF7D5804476AD1A2B021FC78BE (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this, uint8_t** ___data0, int32_t* ___sizeInBytes1)
{
	uint8_t* V_0 = NULL;
	int32_t V_1 = 0;
	{
		// byte* inData = null;
		V_0 = (uint8_t*)((uintptr_t)0);
		// int inSize = 0;
		V_1 = 0;
		// GetDataImpl(m_Handle, ref inData, ref inSize);
		int32_t L_0 = __this->get_m_Handle_0();
		AsyncOp_GetDataImpl_mB67316C777727182AB705AE8CAE5BE33E9F316AA(L_0, (uint8_t**)(&V_0), (int32_t*)(&V_1));
		// data = inData;
		uint8_t** L_1 = ___data0;
		uint8_t* L_2 = V_0;
		*((intptr_t*)L_1) = (intptr_t)L_2;
		// sizeInBytes = inSize;
		int32_t* L_3 = ___sizeInBytes1;
		int32_t L_4 = V_1;
		*((int32_t*)L_3) = (int32_t)L_4;
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void AsyncOp_GetData_m68729EE197F2A4FF7D5804476AD1A2B021FC78BE_AdjustorThunk (RuntimeObject * __this, uint8_t** ___data0, int32_t* ___sizeInBytes1)
{
	AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 *>(__this + _offset);
	AsyncOp_GetData_m68729EE197F2A4FF7D5804476AD1A2B021FC78BE(_thisAdjusted, ___data0, ___sizeInBytes1);
}
// System.Boolean Unity.Tiny.IO.AsyncOp::get_IsCreated()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AsyncOp_get_IsCreated_m601BC7B39968C7908117C455AABEAFF4FB6E152C (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this)
{
	{
		// get { return m_Handle > 0; }
		int32_t L_0 = __this->get_m_Handle_0();
		return (bool)((((int32_t)L_0) > ((int32_t)0))? 1 : 0);
	}
}
IL2CPP_EXTERN_C  bool AsyncOp_get_IsCreated_m601BC7B39968C7908117C455AABEAFF4FB6E152C_AdjustorThunk (RuntimeObject * __this)
{
	AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 *>(__this + _offset);
	bool _returnValue;
	_returnValue = AsyncOp_get_IsCreated_m601BC7B39968C7908117C455AABEAFF4FB6E152C(_thisAdjusted);
	return _returnValue;
}
// System.String Unity.Tiny.IO.AsyncOp::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* AsyncOp_ToString_m30ECB5BCB5245B2E6E668B844A13227EC03A2C23 (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this)
{
	{
		// return $"AsyncOp({m_Handle})";
		int32_t L_0 = __this->get_m_Handle_0();
		int32_t L_1 = L_0;
		RuntimeObject * L_2 = Box(LookupTypeInfoFromCursor(TINY_TYPE_OFFSET_Int32_tBC6089C5C93BC1423D3EA683333151645C66E22A), (void*)&L_1, sizeof(int32_t));
		String_t* L_3;
		L_3 = String_Format_mF264B41D046F53C19626C3EAA5633294A0236D62(LookupStringFromCursor(TINY_STRING_OFFSET__stringLiteral58CAF06C9442050A0714C256C1B1A040FBEF28A1), L_2);
		return L_3;
	}
}
IL2CPP_EXTERN_C  String_t* AsyncOp_ToString_m30ECB5BCB5245B2E6E668B844A13227EC03A2C23_AdjustorThunk (RuntimeObject * __this)
{
	AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 *>(__this + _offset);
	String_t* _returnValue;
	_returnValue = AsyncOp_ToString_m30ECB5BCB5245B2E6E668B844A13227EC03A2C23(_thisAdjusted);
	return _returnValue;
}
// System.Int32 Unity.Tiny.IO.AsyncOp::GetStatusImpl(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AsyncOp_GetStatusImpl_m26620AAC30789F5F11B0D25FCE28CCD87E6B56A7 (int32_t ___handle0)
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc) (int32_t);
	#if !FORCE_PINVOKE_INTERNAL && !FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("lib_unity_tiny_io"), "GetStatus", IL2CPP_CALL_DEFAULT, CHARSET_NOT_SPECIFIED, parameterSize, false);
		IL2CPP_ASSERT(il2cppPInvokeFunc != NULL);
	}
	#endif

	// Native function invocation
	#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	int32_t returnValue = reinterpret_cast<PInvokeFunc>(GetStatus)(___handle0);
	#else
	int32_t returnValue = il2cppPInvokeFunc(___handle0);
	#endif

	return returnValue;
}
// System.Int32 Unity.Tiny.IO.AsyncOp::GetErrorStatusImpl(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t AsyncOp_GetErrorStatusImpl_m5AD06F1277B01A364F916236966AC3C3F49A006B (int32_t ___handle0)
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc) (int32_t);
	#if !FORCE_PINVOKE_INTERNAL && !FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("lib_unity_tiny_io"), "GetErrorStatus", IL2CPP_CALL_DEFAULT, CHARSET_NOT_SPECIFIED, parameterSize, false);
		IL2CPP_ASSERT(il2cppPInvokeFunc != NULL);
	}
	#endif

	// Native function invocation
	#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	int32_t returnValue = reinterpret_cast<PInvokeFunc>(GetErrorStatus)(___handle0);
	#else
	int32_t returnValue = il2cppPInvokeFunc(___handle0);
	#endif

	return returnValue;
}
// System.Void Unity.Tiny.IO.AsyncOp::CloseImpl(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp_CloseImpl_m615D38894685D494B1CCFDC921324CBC010D924A (int32_t ___handle0)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t);
	#if !FORCE_PINVOKE_INTERNAL && !FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("lib_unity_tiny_io"), "Close", IL2CPP_CALL_DEFAULT, CHARSET_NOT_SPECIFIED, parameterSize, false);
		IL2CPP_ASSERT(il2cppPInvokeFunc != NULL);
	}
	#endif

	// Native function invocation
	#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	reinterpret_cast<PInvokeFunc>(Close)(___handle0);
	#else
	il2cppPInvokeFunc(___handle0);
	#endif

}
// System.Void Unity.Tiny.IO.AsyncOp::GetDataImpl(System.Int32,System.Byte*&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AsyncOp_GetDataImpl_mB67316C777727182AB705AE8CAE5BE33E9F316AA (int32_t ___handle0, uint8_t** ___data1, int32_t* ___sizeInBytes2)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (int32_t, uint8_t**, int32_t*);
	#if !FORCE_PINVOKE_INTERNAL && !FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(int32_t) + sizeof(uint8_t**) + sizeof(int32_t*);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("lib_unity_tiny_io"), "GetData", IL2CPP_CALL_DEFAULT, CHARSET_NOT_SPECIFIED, parameterSize, false);
		IL2CPP_ASSERT(il2cppPInvokeFunc != NULL);
	}
	#endif

	// Marshaling of parameter '___data1' to native representation
	uint8_t** ____data1_marshaled = NULL;
	uint8_t* ____data1_marshaled_dereferenced = NULL;
	____data1_marshaled_dereferenced = *___data1;
	____data1_marshaled = &____data1_marshaled_dereferenced;

	// Native function invocation
	#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	reinterpret_cast<PInvokeFunc>(GetData)(___handle0, ____data1_marshaled, ___sizeInBytes2);
	#else
	il2cppPInvokeFunc(___handle0, ____data1_marshaled, ___sizeInBytes2);
	#endif

	// Marshaling of parameter '___data1' back from native representation
	uint8_t* _____data1_marshaled_unmarshaled_dereferenced = NULL;
	_____data1_marshaled_unmarshaled_dereferenced = *____data1_marshaled;
	*___data1 = _____data1_marshaled_unmarshaled_dereferenced;

}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IOService_RequestAsyncReadImpl_mDFF9AC5788369EC0F437667977B63CFB94D6AE79()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Int32 Unity.Tiny.IO.IOService::RequestAsyncReadImpl(System.String,System.Void*,System.Int32)", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_IOService_RequestAsyncRead_m7220D8FA4205D8474814A83920BE6870A16798BE()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Tiny.IO.AsyncOp Unity.Tiny.IO.IOService::RequestAsyncRead(System.String)", "it does not have the [MonoPInvokeCallback] attribute.");
}
// System.Int32 Unity.Tiny.IO.IOService::RequestAsyncReadImpl(System.String,System.Void*,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t IOService_RequestAsyncReadImpl_mDFF9AC5788369EC0F437667977B63CFB94D6AE79 (String_t* ___path0, void* ___buffer1, int32_t ___bufferSize2)
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc) (char*, void*, int32_t);
	#if !FORCE_PINVOKE_INTERNAL && !FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	static PInvokeFunc il2cppPInvokeFunc;
	if (il2cppPInvokeFunc == NULL)
	{
		int parameterSize = sizeof(char*) + sizeof(void*) + sizeof(int32_t);
		il2cppPInvokeFunc = il2cpp_codegen_resolve_pinvoke<PInvokeFunc>(IL2CPP_NATIVE_STRING("lib_unity_tiny_io"), "RequestAsyncRead", IL2CPP_CALL_DEFAULT, CHARSET_ANSI, parameterSize, false);
		IL2CPP_ASSERT(il2cppPInvokeFunc != NULL);
	}
	#endif

	// Marshaling of parameter '___path0' to native representation
	char* ____path0_marshaled = NULL;
	____path0_marshaled = il2cpp_codegen_marshal_string(___path0);

	// Native function invocation
	#if FORCE_PINVOKE_INTERNAL || FORCE_PINVOKE_lib_unity_tiny_io_INTERNAL
	int32_t returnValue = reinterpret_cast<PInvokeFunc>(RequestAsyncRead)(____path0_marshaled, ___buffer1, ___bufferSize2);
	#else
	int32_t returnValue = il2cppPInvokeFunc(____path0_marshaled, ___buffer1, ___bufferSize2);
	#endif

	// Marshaling cleanup of parameter '___path0' native representation
	il2cpp_codegen_marshal_free(____path0_marshaled);
	____path0_marshaled = NULL;

	return returnValue;
}
// Unity.Tiny.IO.AsyncOp Unity.Tiny.IO.IOService::RequestAsyncRead(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18  IOService_RequestAsyncRead_m7220D8FA4205D8474814A83920BE6870A16798BE (String_t* ___path0)
{
	{
		// return new AsyncOp(RequestAsyncReadImpl(path));
		String_t* L_0 = ___path0;
		int32_t L_1;
		L_1 = IOService_RequestAsyncReadImpl_mDFF9AC5788369EC0F437667977B63CFB94D6AE79(L_0, (void*)(void*)((uintptr_t)0), 0);
		AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18  L_2;
		memset((&L_2), 0, sizeof(L_2));
		AsyncOp__ctor_m9DD0B5DFA94AEB7109951B3A984121C660156859_inline((&L_2), L_1);
		return L_2;
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
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void AsyncOp__ctor_m9DD0B5DFA94AEB7109951B3A984121C660156859_inline (AsyncOp_tB0A8F602658288BD036A3726BD556EAD1876EB18 * __this, int32_t ___sysHandle0)
{
	{
		// m_Handle = sysHandle;
		int32_t L_0 = ___sysHandle0;
		__this->set_m_Handle_0(L_0);
		// }
		return;
	}
}
