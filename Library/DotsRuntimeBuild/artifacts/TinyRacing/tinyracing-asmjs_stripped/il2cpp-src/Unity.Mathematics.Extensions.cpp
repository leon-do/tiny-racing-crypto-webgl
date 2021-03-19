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

IL2CPP_EXTERN_C String_t* _stringLiteral3608EF012853B73B01D7308B206EE8F0BD3891EB;
IL2CPP_EXTERN_C const RuntimeMethod AABB_ToString_mC082774ED19A067B275ADD04CE16A2A8C7A17300_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AABB_get_Max_m11E6A52990542B0A9F1696C669D21604F29B0911_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AABB_get_Min_mAAB5E96EC0A2FE9EC9A8C17AE52894165D11B4AB_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod AABB_get_Size_m69704879F4E8509BBF6C7935BB68EAE341C0A4CA_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod MinMaxAABB_Encapsulate_mD851FBDA5E25568BEE60F3535DCC21E4A4BDEC2E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod MinMaxAABB_Equals_m471492E8F7EF83ABFE0E01C14A09E309330291C7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod Single_IsNaN_m70BB8B40668C01870EE266E66E200DB41E81C323_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod String_Format_mC574153FA247578A22DD455DBDEBAEBB46E5E0A7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod float3_Equals_m0F3F05530D696A61CCA05FC868D2DF2A61F984D6_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod float3__ctor_m4FCA18779A2A9DD7B0BFEBA891A145F5AA772D8D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod float3__ctor_mCD89C40FC2460E1243C28DFE77AE99A689DBD8D1_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod float3_op_Addition_mA5429BE3D1BE852B163E0B253A1E8B9D6FF4F57C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod float3_op_Multiply_mDD521C766C3798A0E1917D3A3E14A7079E3E222B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod float3_op_Subtraction_mB3250D4D18B21370A6FEA3B2B527CFA7B6DE439D_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod math_float3_m68FF1C84FB144866D0D9846F209B18C1EE164915_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod math_max_m163409FA282D357AE730B2B3562086663F3B5C50_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod math_max_m50BE7BF5F177964230090F2B1AF068FAE0D8E721_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod math_min_m5FFC5422228C240A2517A59370F3A1A2D15D266C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod math_min_mF326657FAB4548F84D71C5D8AEC52CE8A96FAB46_RuntimeMethod_var;
IL2CPP_EXTERN_C const uint32_t TINY_TYPE_OFFSET_float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_tCA4FCF16098B3EC595C91665511ED8D759841C61 
{
public:

public:
};


// System.Object

struct Il2CppArrayBounds;

// System.Array


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


// System.Single
struct  Single_tF66BD68098944176DA1868142CD69A5E45683E6E 
{
public:
	// System.Single System.Single::m_value
	float ___m_value_0;

public:
	inline float get_m_value_0() const { return ___m_value_0; }
	inline float* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(float value)
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


// Unity.Mathematics.float3
struct  float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D 
{
public:
	// System.Single Unity.Mathematics.float3::x
	float ___x_0;
	// System.Single Unity.Mathematics.float3::y
	float ___y_1;
	// System.Single Unity.Mathematics.float3::z
	float ___z_2;

public:
	inline float get_x_0() const { return ___x_0; }
	inline float* get_address_of_x_0() { return &___x_0; }
	inline void set_x_0(float value)
	{
		___x_0 = value;
	}

	inline float get_y_1() const { return ___y_1; }
	inline float* get_address_of_y_1() { return &___y_1; }
	inline void set_y_1(float value)
	{
		___y_1 = value;
	}

	inline float get_z_2() const { return ___z_2; }
	inline float* get_address_of_z_2() { return &___z_2; }
	inline void set_z_2(float value)
	{
		___z_2 = value;
	}
};

extern void* float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D_StaticFields_Storage;
struct float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D_StaticFields
{
public:
	// Unity.Mathematics.float3 Unity.Mathematics.float3::zero
	float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___zero_3;

public:
	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  get_zero_3() const { return ___zero_3; }
	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * get_address_of_zero_3() { return &___zero_3; }
	inline void set_zero_3(float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  value)
	{
		___zero_3 = value;
	}
};


// Unity.Mathematics.AABB
struct  AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD 
{
public:
	// Unity.Mathematics.float3 Unity.Mathematics.AABB::Center
	float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___Center_0;
	// Unity.Mathematics.float3 Unity.Mathematics.AABB::Extents
	float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___Extents_1;

public:
	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  get_Center_0() const { return ___Center_0; }
	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * get_address_of_Center_0() { return &___Center_0; }
	inline void set_Center_0(float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  value)
	{
		___Center_0 = value;
	}

	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  get_Extents_1() const { return ___Extents_1; }
	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * get_address_of_Extents_1() { return &___Extents_1; }
	inline void set_Extents_1(float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  value)
	{
		___Extents_1 = value;
	}
};


// Unity.Mathematics.MinMaxAABB
struct  MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC 
{
public:
	// Unity.Mathematics.float3 Unity.Mathematics.MinMaxAABB::Min
	float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___Min_0;
	// Unity.Mathematics.float3 Unity.Mathematics.MinMaxAABB::Max
	float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___Max_1;

public:
	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  get_Min_0() const { return ___Min_0; }
	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * get_address_of_Min_0() { return &___Min_0; }
	inline void set_Min_0(float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  value)
	{
		___Min_0 = value;
	}

	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  get_Max_1() const { return ___Max_1; }
	inline float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * get_address_of_Max_1() { return &___Max_1; }
	inline void set_Max_1(float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  value)
	{
		___Max_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif



// Unity.Mathematics.float3 Unity.Mathematics.float3::op_Multiply(Unity.Mathematics.float3,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  float3_op_Multiply_mDD521C766C3798A0E1917D3A3E14A7079E3E222B_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___lhs0, float ___rhs1);
// Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Size()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Size_m69704879F4E8509BBF6C7935BB68EAE341C0A4CA (AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * __this);
// Unity.Mathematics.float3 Unity.Mathematics.float3::op_Subtraction(Unity.Mathematics.float3,Unity.Mathematics.float3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  float3_op_Subtraction_mB3250D4D18B21370A6FEA3B2B527CFA7B6DE439D_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___lhs0, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___rhs1);
// Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Min()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Min_mAAB5E96EC0A2FE9EC9A8C17AE52894165D11B4AB (AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * __this);
// Unity.Mathematics.float3 Unity.Mathematics.float3::op_Addition(Unity.Mathematics.float3,Unity.Mathematics.float3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  float3_op_Addition_mA5429BE3D1BE852B163E0B253A1E8B9D6FF4F57C_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___lhs0, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___rhs1);
// Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Max()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Max_m11E6A52990542B0A9F1696C669D21604F29B0911 (AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * __this);
// System.String System.String::Format(System.String,System.Object,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_mC574153FA247578A22DD455DBDEBAEBB46E5E0A7 (String_t* ___format0, RuntimeObject * ___arg11, RuntimeObject * ___arg22);
// System.String Unity.Mathematics.AABB::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* AABB_ToString_mC082774ED19A067B275ADD04CE16A2A8C7A17300 (AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * __this);
// Unity.Mathematics.float3 Unity.Mathematics.math::float3(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  math_float3_m68FF1C84FB144866D0D9846F209B18C1EE164915_inline (float ___v0);
// Unity.Mathematics.float3 Unity.Mathematics.math::min(Unity.Mathematics.float3,Unity.Mathematics.float3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  math_min_mF326657FAB4548F84D71C5D8AEC52CE8A96FAB46_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___x0, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___y1);
// Unity.Mathematics.float3 Unity.Mathematics.math::max(Unity.Mathematics.float3,Unity.Mathematics.float3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  math_max_m50BE7BF5F177964230090F2B1AF068FAE0D8E721_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___x0, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___y1);
// System.Void Unity.Mathematics.MinMaxAABB::Encapsulate(Unity.Mathematics.float3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MinMaxAABB_Encapsulate_mD851FBDA5E25568BEE60F3535DCC21E4A4BDEC2E (MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC * __this, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___point0);
// System.Boolean Unity.Mathematics.float3::Equals(Unity.Mathematics.float3)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool float3_Equals_m0F3F05530D696A61CCA05FC868D2DF2A61F984D6_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * __this, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___rhs0);
// System.Boolean Unity.Mathematics.MinMaxAABB::Equals(Unity.Mathematics.MinMaxAABB)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MinMaxAABB_Equals_m471492E8F7EF83ABFE0E01C14A09E309330291C7 (MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC * __this, MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  ___other0);
// System.Void Unity.Mathematics.float3::.ctor(System.Single,System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void float3__ctor_m4FCA18779A2A9DD7B0BFEBA891A145F5AA772D8D_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * __this, float ___x0, float ___y1, float ___z2);
// System.Void Unity.Mathematics.float3::.ctor(System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void float3__ctor_mCD89C40FC2460E1243C28DFE77AE99A689DBD8D1_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * __this, float ___v0);
// System.Single Unity.Mathematics.math::min(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_min_m5FFC5422228C240A2517A59370F3A1A2D15D266C_inline (float ___x0, float ___y1);
// System.Single Unity.Mathematics.math::max(System.Single,System.Single)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_max_m163409FA282D357AE730B2B3562086663F3B5C50_inline (float ___x0, float ___y1);
// System.Boolean System.Single::IsNaN(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Single_IsNaN_m70BB8B40668C01870EE266E66E200DB41E81C323 (float ___f0);
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
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AABB_get_Size_m69704879F4E8509BBF6C7935BB68EAE341C0A4CA()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Size()", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AABB_get_Min_mAAB5E96EC0A2FE9EC9A8C17AE52894165D11B4AB()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Min()", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AABB_get_Max_m11E6A52990542B0A9F1696C669D21604F29B0911()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Max()", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_AABB_ToString_mC082774ED19A067B275ADD04CE16A2A8C7A17300()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.String Unity.Mathematics.AABB::ToString()", "it is an instance method. Only static methods can be called back from native code.");
}
// Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Size()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Size_m69704879F4E8509BBF6C7935BB68EAE341C0A4CA (AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * __this)
{
	{
		// public float3 Size { get { return Extents * 2; } }
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = __this->get_Extents_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1;
		L_1 = float3_op_Multiply_mDD521C766C3798A0E1917D3A3E14A7079E3E222B_inline(L_0, (2.0f));
		return L_1;
	}
}
IL2CPP_EXTERN_C  float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Size_m69704879F4E8509BBF6C7935BB68EAE341C0A4CA_AdjustorThunk (RuntimeObject * __this)
{
	AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD *>(__this + _offset);
	float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  _returnValue;
	_returnValue = AABB_get_Size_m69704879F4E8509BBF6C7935BB68EAE341C0A4CA(_thisAdjusted);
	return _returnValue;
}
// Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Min()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Min_mAAB5E96EC0A2FE9EC9A8C17AE52894165D11B4AB (AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * __this)
{
	{
		// public float3 Min { get { return Center - Extents; } }
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = __this->get_Center_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1 = __this->get_Extents_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_2;
		L_2 = float3_op_Subtraction_mB3250D4D18B21370A6FEA3B2B527CFA7B6DE439D_inline(L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C  float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Min_mAAB5E96EC0A2FE9EC9A8C17AE52894165D11B4AB_AdjustorThunk (RuntimeObject * __this)
{
	AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD *>(__this + _offset);
	float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  _returnValue;
	_returnValue = AABB_get_Min_mAAB5E96EC0A2FE9EC9A8C17AE52894165D11B4AB(_thisAdjusted);
	return _returnValue;
}
// Unity.Mathematics.float3 Unity.Mathematics.AABB::get_Max()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Max_m11E6A52990542B0A9F1696C669D21604F29B0911 (AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * __this)
{
	{
		// public float3 Max { get { return Center + Extents; } }
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = __this->get_Center_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1 = __this->get_Extents_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_2;
		L_2 = float3_op_Addition_mA5429BE3D1BE852B163E0B253A1E8B9D6FF4F57C_inline(L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C  float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  AABB_get_Max_m11E6A52990542B0A9F1696C669D21604F29B0911_AdjustorThunk (RuntimeObject * __this)
{
	AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD *>(__this + _offset);
	float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  _returnValue;
	_returnValue = AABB_get_Max_m11E6A52990542B0A9F1696C669D21604F29B0911(_thisAdjusted);
	return _returnValue;
}
// System.String Unity.Mathematics.AABB::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* AABB_ToString_mC082774ED19A067B275ADD04CE16A2A8C7A17300 (AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * __this)
{
	{
		// return $"AABB(Center:{Center}, Extents:{Extents}";
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = __this->get_Center_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1 = L_0;
		RuntimeObject * L_2 = Box(LookupTypeInfoFromCursor(TINY_TYPE_OFFSET_float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D), (void*)&L_1, sizeof(float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D ));
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_3 = __this->get_Extents_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_4 = L_3;
		RuntimeObject * L_5 = Box(LookupTypeInfoFromCursor(TINY_TYPE_OFFSET_float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D), (void*)&L_4, sizeof(float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D ));
		String_t* L_6;
		L_6 = String_Format_mC574153FA247578A22DD455DBDEBAEBB46E5E0A7(LookupStringFromCursor(TINY_STRING_OFFSET__stringLiteral3608EF012853B73B01D7308B206EE8F0BD3891EB), L_2, L_5);
		return L_6;
	}
}
IL2CPP_EXTERN_C  String_t* AABB_ToString_mC082774ED19A067B275ADD04CE16A2A8C7A17300_AdjustorThunk (RuntimeObject * __this)
{
	AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD *>(__this + _offset);
	String_t* _returnValue;
	_returnValue = AABB_ToString_mC082774ED19A067B275ADD04CE16A2A8C7A17300(_thisAdjusted);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MinMaxAABB_get_Empty_mDD69C4BB0A6EC08F10CD2009CC7E59B00D209E61()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Mathematics.MinMaxAABB Unity.Mathematics.MinMaxAABB::get_Empty()", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MinMaxAABB_Encapsulate_mD851FBDA5E25568BEE60F3535DCC21E4A4BDEC2E()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Void Unity.Mathematics.MinMaxAABB::Encapsulate(Unity.Mathematics.float3)", "it is an instance method. Only static methods can be called back from native code.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MinMaxAABB_op_Implicit_mF2FA354DB11FB44F70F5C220E01C6DD04106E0B5()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("Unity.Mathematics.AABB Unity.Mathematics.MinMaxAABB::op_Implicit(Unity.Mathematics.MinMaxAABB)", "it does not have the [MonoPInvokeCallback] attribute.");
}
extern "C" void DEFAULT_CALL ReversePInvokeWrapper_MinMaxAABB_Equals_m471492E8F7EF83ABFE0E01C14A09E309330291C7()
{
	il2cpp_codegen_no_reverse_pinvoke_wrapper("System.Boolean Unity.Mathematics.MinMaxAABB::Equals(Unity.Mathematics.MinMaxAABB)", "it is an instance method. Only static methods can be called back from native code.");
}
// Unity.Mathematics.MinMaxAABB Unity.Mathematics.MinMaxAABB::get_Empty()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  MinMaxAABB_get_Empty_mDD69C4BB0A6EC08F10CD2009CC7E59B00D209E61 ()
{
	MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// get { return new MinMaxAABB { Min = float3(float.PositiveInfinity), Max = float3(float.NegativeInfinity) }; }
		il2cpp_codegen_initobj((&V_0), sizeof(MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC ));
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0;
		L_0 = math_float3_m68FF1C84FB144866D0D9846F209B18C1EE164915_inline((std::numeric_limits<float>::infinity()));
		(&V_0)->set_Min_0(L_0);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1;
		L_1 = math_float3_m68FF1C84FB144866D0D9846F209B18C1EE164915_inline((-std::numeric_limits<float>::infinity()));
		(&V_0)->set_Max_1(L_1);
		MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  L_2 = V_0;
		return L_2;
	}
}
// System.Void Unity.Mathematics.MinMaxAABB::Encapsulate(Unity.Mathematics.float3)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MinMaxAABB_Encapsulate_mD851FBDA5E25568BEE60F3535DCC21E4A4BDEC2E (MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC * __this, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___point0)
{
	{
		// Min = math.min(Min, point);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = __this->get_Min_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1 = ___point0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_2;
		L_2 = math_min_mF326657FAB4548F84D71C5D8AEC52CE8A96FAB46_inline(L_0, L_1);
		__this->set_Min_0(L_2);
		// Max = math.max(Max, point);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_3 = __this->get_Max_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_4 = ___point0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_5;
		L_5 = math_max_m50BE7BF5F177964230090F2B1AF068FAE0D8E721_inline(L_3, L_4);
		__this->set_Max_1(L_5);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void MinMaxAABB_Encapsulate_mD851FBDA5E25568BEE60F3535DCC21E4A4BDEC2E_AdjustorThunk (RuntimeObject * __this, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___point0)
{
	MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC *>(__this + _offset);
	MinMaxAABB_Encapsulate_mD851FBDA5E25568BEE60F3535DCC21E4A4BDEC2E(_thisAdjusted, ___point0);
}
// Unity.Mathematics.AABB Unity.Mathematics.MinMaxAABB::op_Implicit(Unity.Mathematics.MinMaxAABB)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD  MinMaxAABB_op_Implicit_mF2FA354DB11FB44F70F5C220E01C6DD04106E0B5 (MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  ___aabb0)
{
	AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// return new AABB { Center = (aabb.Min + aabb.Max) * 0.5F, Extents = (aabb.Max - aabb.Min) * 0.5F};
		il2cpp_codegen_initobj((&V_0), sizeof(AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD ));
		MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  L_0 = ___aabb0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1 = L_0.get_Min_0();
		MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  L_2 = ___aabb0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_3 = L_2.get_Max_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_4;
		L_4 = float3_op_Addition_mA5429BE3D1BE852B163E0B253A1E8B9D6FF4F57C_inline(L_1, L_3);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_5;
		L_5 = float3_op_Multiply_mDD521C766C3798A0E1917D3A3E14A7079E3E222B_inline(L_4, (0.5f));
		(&V_0)->set_Center_0(L_5);
		MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  L_6 = ___aabb0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_7 = L_6.get_Max_1();
		MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  L_8 = ___aabb0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_9 = L_8.get_Min_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_10;
		L_10 = float3_op_Subtraction_mB3250D4D18B21370A6FEA3B2B527CFA7B6DE439D_inline(L_7, L_9);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_11;
		L_11 = float3_op_Multiply_mDD521C766C3798A0E1917D3A3E14A7079E3E222B_inline(L_10, (0.5f));
		(&V_0)->set_Extents_1(L_11);
		AABB_tB919B5AD126E4B81162E018CDF0565348AAEEFCD  L_12 = V_0;
		return L_12;
	}
}
// System.Boolean Unity.Mathematics.MinMaxAABB::Equals(Unity.Mathematics.MinMaxAABB)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool MinMaxAABB_Equals_m471492E8F7EF83ABFE0E01C14A09E309330291C7 (MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC * __this, MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  ___other0)
{
	{
		// return Min.Equals(other.Min) && Max.Equals(other.Max);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * L_0 = __this->get_address_of_Min_0();
		MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  L_1 = ___other0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_2 = L_1.get_Min_0();
		bool L_3;
		L_3 = float3_Equals_m0F3F05530D696A61CCA05FC868D2DF2A61F984D6_inline((float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D *)L_0, L_2);
		if (!L_3)
		{
			goto IL_0025;
		}
	}
	{
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * L_4 = __this->get_address_of_Max_1();
		MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  L_5 = ___other0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_6 = L_5.get_Max_1();
		bool L_7;
		L_7 = float3_Equals_m0F3F05530D696A61CCA05FC868D2DF2A61F984D6_inline((float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D *)L_4, L_6);
		return L_7;
	}

IL_0025:
	{
		return (bool)0;
	}
}
IL2CPP_EXTERN_C  bool MinMaxAABB_Equals_m471492E8F7EF83ABFE0E01C14A09E309330291C7_AdjustorThunk (RuntimeObject * __this, MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC  ___other0)
{
	MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC * _thisAdjusted;
	int32_t _offset = ((sizeof(RuntimeObject) + IL2CPP_BOXED_OBJECT_ALIGNMENT - 1) & ~(IL2CPP_BOXED_OBJECT_ALIGNMENT - 1)) / sizeof(void*);
	_thisAdjusted = reinterpret_cast<MinMaxAABB_tCCD4ACB50B35AC26791867F908282F8FC6A050AC *>(__this + _offset);
	bool _returnValue;
	_returnValue = MinMaxAABB_Equals_m471492E8F7EF83ABFE0E01C14A09E309330291C7(_thisAdjusted, ___other0);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  float3_op_Multiply_mDD521C766C3798A0E1917D3A3E14A7079E3E222B_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___lhs0, float ___rhs1)
{
	{
		// public static float3 operator * (float3 lhs, float rhs) { return new float3 (lhs.x * rhs, lhs.y * rhs, lhs.z * rhs); }
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = ___lhs0;
		float L_1 = L_0.get_x_0();
		float L_2 = ___rhs1;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_3 = ___lhs0;
		float L_4 = L_3.get_y_1();
		float L_5 = ___rhs1;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_6 = ___lhs0;
		float L_7 = L_6.get_z_2();
		float L_8 = ___rhs1;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_9;
		memset((&L_9), 0, sizeof(L_9));
		float3__ctor_m4FCA18779A2A9DD7B0BFEBA891A145F5AA772D8D_inline((&L_9), ((float)il2cpp_codegen_multiply((float)L_1, (float)L_2)), ((float)il2cpp_codegen_multiply((float)L_4, (float)L_5)), ((float)il2cpp_codegen_multiply((float)L_7, (float)L_8)));
		return L_9;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  float3_op_Subtraction_mB3250D4D18B21370A6FEA3B2B527CFA7B6DE439D_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___lhs0, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___rhs1)
{
	{
		// public static float3 operator - (float3 lhs, float3 rhs) { return new float3 (lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z); }
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = ___lhs0;
		float L_1 = L_0.get_x_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_2 = ___rhs1;
		float L_3 = L_2.get_x_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_4 = ___lhs0;
		float L_5 = L_4.get_y_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_6 = ___rhs1;
		float L_7 = L_6.get_y_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_8 = ___lhs0;
		float L_9 = L_8.get_z_2();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_10 = ___rhs1;
		float L_11 = L_10.get_z_2();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_12;
		memset((&L_12), 0, sizeof(L_12));
		float3__ctor_m4FCA18779A2A9DD7B0BFEBA891A145F5AA772D8D_inline((&L_12), ((float)il2cpp_codegen_subtract((float)L_1, (float)L_3)), ((float)il2cpp_codegen_subtract((float)L_5, (float)L_7)), ((float)il2cpp_codegen_subtract((float)L_9, (float)L_11)));
		return L_12;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  float3_op_Addition_mA5429BE3D1BE852B163E0B253A1E8B9D6FF4F57C_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___lhs0, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___rhs1)
{
	{
		// public static float3 operator + (float3 lhs, float3 rhs) { return new float3 (lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z); }
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = ___lhs0;
		float L_1 = L_0.get_x_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_2 = ___rhs1;
		float L_3 = L_2.get_x_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_4 = ___lhs0;
		float L_5 = L_4.get_y_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_6 = ___rhs1;
		float L_7 = L_6.get_y_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_8 = ___lhs0;
		float L_9 = L_8.get_z_2();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_10 = ___rhs1;
		float L_11 = L_10.get_z_2();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_12;
		memset((&L_12), 0, sizeof(L_12));
		float3__ctor_m4FCA18779A2A9DD7B0BFEBA891A145F5AA772D8D_inline((&L_12), ((float)il2cpp_codegen_add((float)L_1, (float)L_3)), ((float)il2cpp_codegen_add((float)L_5, (float)L_7)), ((float)il2cpp_codegen_add((float)L_9, (float)L_11)));
		return L_12;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  math_float3_m68FF1C84FB144866D0D9846F209B18C1EE164915_inline (float ___v0)
{
	{
		// public static float3 float3(float v) { return new float3(v); }
		float L_0 = ___v0;
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1;
		memset((&L_1), 0, sizeof(L_1));
		float3__ctor_mCD89C40FC2460E1243C28DFE77AE99A689DBD8D1_inline((&L_1), L_0);
		return L_1;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  math_min_mF326657FAB4548F84D71C5D8AEC52CE8A96FAB46_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___x0, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___y1)
{
	{
		// public static float3 min(float3 x, float3 y) { return new float3(min(x.x, y.x), min(x.y, y.y), min(x.z, y.z)); }
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = ___x0;
		float L_1 = L_0.get_x_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_2 = ___y1;
		float L_3 = L_2.get_x_0();
		float L_4;
		L_4 = math_min_m5FFC5422228C240A2517A59370F3A1A2D15D266C_inline(L_1, L_3);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_5 = ___x0;
		float L_6 = L_5.get_y_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_7 = ___y1;
		float L_8 = L_7.get_y_1();
		float L_9;
		L_9 = math_min_m5FFC5422228C240A2517A59370F3A1A2D15D266C_inline(L_6, L_8);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_10 = ___x0;
		float L_11 = L_10.get_z_2();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_12 = ___y1;
		float L_13 = L_12.get_z_2();
		float L_14;
		L_14 = math_min_m5FFC5422228C240A2517A59370F3A1A2D15D266C_inline(L_11, L_13);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_15;
		memset((&L_15), 0, sizeof(L_15));
		float3__ctor_m4FCA18779A2A9DD7B0BFEBA891A145F5AA772D8D_inline((&L_15), L_4, L_9, L_14);
		return L_15;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  math_max_m50BE7BF5F177964230090F2B1AF068FAE0D8E721_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___x0, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___y1)
{
	{
		// public static float3 max(float3 x, float3 y) { return new float3(max(x.x, y.x), max(x.y, y.y), max(x.z, y.z)); }
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_0 = ___x0;
		float L_1 = L_0.get_x_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_2 = ___y1;
		float L_3 = L_2.get_x_0();
		float L_4;
		L_4 = math_max_m163409FA282D357AE730B2B3562086663F3B5C50_inline(L_1, L_3);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_5 = ___x0;
		float L_6 = L_5.get_y_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_7 = ___y1;
		float L_8 = L_7.get_y_1();
		float L_9;
		L_9 = math_max_m163409FA282D357AE730B2B3562086663F3B5C50_inline(L_6, L_8);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_10 = ___x0;
		float L_11 = L_10.get_z_2();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_12 = ___y1;
		float L_13 = L_12.get_z_2();
		float L_14;
		L_14 = math_max_m163409FA282D357AE730B2B3562086663F3B5C50_inline(L_11, L_13);
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_15;
		memset((&L_15), 0, sizeof(L_15));
		float3__ctor_m4FCA18779A2A9DD7B0BFEBA891A145F5AA772D8D_inline((&L_15), L_4, L_9, L_14);
		return L_15;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool float3_Equals_m0F3F05530D696A61CCA05FC868D2DF2A61F984D6_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * __this, float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  ___rhs0)
{
	{
		// public bool Equals(float3 rhs) { return x == rhs.x && y == rhs.y && z == rhs.z; }
		float L_0 = __this->get_x_0();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_1 = ___rhs0;
		float L_2 = L_1.get_x_0();
		if ((!(((float)L_0) == ((float)L_2))))
		{
			goto IL_002b;
		}
	}
	{
		float L_3 = __this->get_y_1();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_4 = ___rhs0;
		float L_5 = L_4.get_y_1();
		if ((!(((float)L_3) == ((float)L_5))))
		{
			goto IL_002b;
		}
	}
	{
		float L_6 = __this->get_z_2();
		float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D  L_7 = ___rhs0;
		float L_8 = L_7.get_z_2();
		return (bool)((((float)L_6) == ((float)L_8))? 1 : 0);
	}

IL_002b:
	{
		return (bool)0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void float3__ctor_m4FCA18779A2A9DD7B0BFEBA891A145F5AA772D8D_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * __this, float ___x0, float ___y1, float ___z2)
{
	{
		// this.x = x;
		float L_0 = ___x0;
		__this->set_x_0(L_0);
		// this.y = y;
		float L_1 = ___y1;
		__this->set_y_1(L_1);
		// this.z = z;
		float L_2 = ___z2;
		__this->set_z_2(L_2);
		// }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void float3__ctor_mCD89C40FC2460E1243C28DFE77AE99A689DBD8D1_inline (float3_tE0DD2FF13F818025945C9AC314390D2A1F55E37D * __this, float ___v0)
{
	{
		// this.x = v;
		float L_0 = ___v0;
		__this->set_x_0(L_0);
		// this.y = v;
		float L_1 = ___v0;
		__this->set_y_1(L_1);
		// this.z = v;
		float L_2 = ___v0;
		__this->set_z_2(L_2);
		// }
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_min_m5FFC5422228C240A2517A59370F3A1A2D15D266C_inline (float ___x0, float ___y1)
{
	{
		// public static float min(float x, float y) { return float.IsNaN(y) || x < y ? x : y; }
		float L_0 = ___y1;
		bool L_1;
		L_1 = Single_IsNaN_m70BB8B40668C01870EE266E66E200DB41E81C323(L_0);
		if (L_1)
		{
			goto IL_000e;
		}
	}
	{
		float L_2 = ___x0;
		float L_3 = ___y1;
		if ((((float)L_2) < ((float)L_3)))
		{
			goto IL_000e;
		}
	}
	{
		float L_4 = ___y1;
		return L_4;
	}

IL_000e:
	{
		float L_5 = ___x0;
		return L_5;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR float math_max_m163409FA282D357AE730B2B3562086663F3B5C50_inline (float ___x0, float ___y1)
{
	{
		// public static float max(float x, float y) { return float.IsNaN(y) || x > y ? x : y; }
		float L_0 = ___y1;
		bool L_1;
		L_1 = Single_IsNaN_m70BB8B40668C01870EE266E66E200DB41E81C323(L_0);
		if (L_1)
		{
			goto IL_000e;
		}
	}
	{
		float L_2 = ___x0;
		float L_3 = ___y1;
		if ((((float)L_2) > ((float)L_3)))
		{
			goto IL_000e;
		}
	}
	{
		float L_4 = ___y1;
		return L_4;
	}

IL_000e:
	{
		float L_5 = ___x0;
		return L_5;
	}
}
