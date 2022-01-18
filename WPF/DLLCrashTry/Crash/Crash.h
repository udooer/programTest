#pragma once

#ifdef Crash_EXPORTS
#define Crash_API __declspec(dllexport)
#else
#define Crash_API __declspec(dllimport)
#endif

//change top-left point of the target monitor 
extern "C" Crash_API void DoCrash();