#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif






IL2CPP_EXTERN_C const RuntimeMethod Program_Main_m4F2450F73620D98B4E1EDC0F72920FAD5A5EBC0C_RuntimeMethod_var;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END




// System.Void Unity.Tiny.EntryPoint.Program::Main()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Program_Main_m4F2450F73620D98B4E1EDC0F72920FAD5A5EBC0C ();
#include "il2cpp-api.h"
#include "utils/Exception.h"
#include "utils/StringUtils.h"
#if IL2CPP_TARGET_WINDOWS_DESKTOP
#include "Windows.h"
#include "Shellapi.h"
#elif IL2CPP_TARGET_WINDOWS_GAMES
#include "Windows.h"
#endif

#if IL2CPP_TARGET_LUMIN
#include "ml_lifecycle.h"
#endif
extern "C" char * platform_config_path();
extern "C" char * platform_data_path();

int MainInvoker(int argc, const Il2CppNativeChar* const* argv)
{
	Program_Main_m4F2450F73620D98B4E1EDC0F72920FAD5A5EBC0C();
	return 0;
}

int EntryPoint(int argc, const Il2CppNativeChar* const* argv)
{
	#if IL2CPP_MONO_DEBUGGER
	#define DEBUGGER_STRINGIFY(x) #x
	#define DEBUGGER_STRINGIFY2(x) DEBUGGER_STRINGIFY(x)
	#ifdef IL2CPP_MONO_DEBUGGER_LOGFILE
	#if IL2CPP_TARGET_JAVASCRIPT || IL2CPP_TARGET_IOS
	il2cpp_debugger_set_agent_options("--debugger-agent=transport=dt_socket,address=0.0.0.0:" DEBUGGER_STRINGIFY2(IL2CPP_DEBUGGER_PORT) ",server=y,suspend=n,loglevel=9");
	#else
	il2cpp_debugger_set_agent_options("--debugger-agent=transport=dt_socket,address=0.0.0.0:" DEBUGGER_STRINGIFY2(IL2CPP_DEBUGGER_PORT) ",server=y,suspend=n,loglevel=9,logfile=" DEBUGGER_STRINGIFY2(IL2CPP_MONO_DEBUGGER_LOGFILE) "");
	#endif
	#else
	il2cpp_debugger_set_agent_options("--debugger-agent=transport=dt_socket,address=0.0.0.0:" DEBUGGER_STRINGIFY2(IL2CPP_DEBUGGER_PORT) ",server=y,suspend=n");
	#endif
	#undef DEBUGGER_STRINGIFY
	#undef DEBUGGER_STRINGIFY2
	#endif

	#if IL2CPP_DISABLE_GC
	il2cpp_gc_disable();
	#endif

	#if IL2CPP_TARGET_WINDOWS
		il2cpp_set_commandline_arguments_utf16(argc, argv, NULL);
	#else
		il2cpp_set_commandline_arguments(argc, argv, NULL);
		#endif
		il2cpp_init();

	#if IL2CPP_TARGET_LUMIN
		MLLifecycleSetReadyIndication();
	#endif

		int exitCode = MainInvoker(argc, argv);

		return exitCode;
	}

	#if IL2CPP_TARGET_WINDOWS

	#if IL2CPP_TARGET_WINDOWS_GAMES 
	#include <windef.h>
	#include <string>
	#include <locale>
	#include <codecvt>
	#elif !IL2CPP_TARGET_WINDOWS_DESKTOP 
	#include "ActivateApp.h"
	#endif

	int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPWSTR lpCmdLine, int nShowCmd)
	{
	#if IL2CPP_TARGET_WINDOWS_DESKTOP || IL2CPP_TARGET_WINDOWS_GAMES
	#if IL2CPP_TARGET_WINDOWS_DESKTOP
		int argc;
		wchar_t** argv = CommandLineToArgvW(GetCommandLineW(), &argc);
		int returnValue = EntryPoint(argc, argv);
		LocalFree(argv);
		return returnValue;
	#elif IL2CPP_TARGET_WINDOWS_GAMES
		int result = EntryPoint(__argc, __wargv);
		return result;
	#endif
	#elif IL2CPP_WINRT_NO_ACTIVATE
		wchar_t executableName[MAX_PATH + 2];
		GetModuleFileNameW(nullptr, executableName, MAX_PATH + 2);

		int argc = 1;
		const wchar_t* argv[] = { executableName };
		return EntryPoint(argc, argv);
	#else
		return WinRT::Activate(EntryPoint);
	#endif
	}

	#elif IL2CPP_TARGET_ANDROID && IL2CPP_TINY

	#include <jni.h>
	int main(int argc, const char* argv[])
	{
		return EntryPoint(argc, argv);
	}
	extern "C"
	JNIEXPORT void start()
	{
		const char* argv[1];
		argv[0] = "";
		main(1, argv);
	}

	#elif IL2CPP_TARGET_IOS && IL2CPP_TINY

	extern "C"
	void start()
	{
		const char* argv[1];
		argv[0] = "";
		EntryPoint(1, argv);
	}

	#elif IL2CPP_TARGET_JAVASCRIPT && IL2CPP_MONO_DEBUGGER && !IL2CPP_TINY_FROM_IL2CPP_BUILDER
	#include <emscripten.h>
	#include <emscripten/fetch.h>
	#include <emscripten/html5.h>

	void* g_MetadataForWebTinyDebugger = NULL;

	void OnSuccess(emscripten_fetch_t* pFetch)
	{
		g_MetadataForWebTinyDebugger = (void*) pFetch->data;
		const char* argv[1];
		argv[0] = "";
		EntryPoint(1, argv);
	}

	void OnError(emscripten_fetch_t* pFetch)
	{
		printf("Unable to load the file 'Data/Metadata/global-metadata.dat' from the server. This file is required for managed code debugging.\n");
		abort();
	}

	int main(int argc, const char* argv[])
	{
		emscripten_fetch_attr_t attr;
		emscripten_fetch_attr_init(&attr);
		strcpy(attr.requestMethod, "GET");
		attr.attributes = EMSCRIPTEN_FETCH_LOAD_TO_MEMORY;
		attr.onsuccess = OnSuccess;
		attr.onerror = OnError;
		emscripten_fetch(&attr, "Data/Metadata/global-metadata.dat");
		#if (__EMSCRIPTEN_major__ >= 1) && (__EMSCRIPTEN_minor__ >= 39) && (__EMSCRIPTEN_tiny__ >= 5)
		emscripten_unwind_to_js_event_loop();
		#endif
	}

	#else

	int main(int argc, const char* argv[])
	{
		return EntryPoint(argc, argv);
	}

	#endif
