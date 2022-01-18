#include "pch.h"
#include "Crash.h"
#include <iostream>
#include <excpt.h>
//int seh_filter(unsigned int code, struct _EXCEPTION_POINTERS* ep)
//{
//	return EXCEPTION_EXECUTE_HANDLER;
//}
void DoCrash() {
	int* p = NULL;   // pointer to NULL
	__try {
		for (long long int i = 0; ++i; (&i)[i] = i);
	}
	__except (EXCEPTION_EXECUTE_HANDLER)
	{
		std::cout << "An exception was caught in __except." << std::endl;
	}
	return;
}

//void DoCrash() {
//	int* p = NULL;   // pointer to NULL
//	
//	for (long long int i = 0; ++i; (&i)[i] = i);
//	return;
//}