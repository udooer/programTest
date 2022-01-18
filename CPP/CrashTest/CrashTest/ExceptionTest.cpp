#include<iostream>
#include <excpt.h>
using namespace std;
//int seh_filter(unsigned int code, struct _EXCEPTION_POINTERS* ep)
//{
//	std::cout << code << std::endl;
//	return EXCEPTION_EXECUTE_HANDLER;
//}
int main() {
	int* p = NULL;   // pointer to NULL
	__try
	{
		//*p = 13; // causes an access violation exception
		for (long long int i = 0; ++i; (&i)[i] = i);
	}
	__except (EXCEPTION_EXECUTE_HANDLER) // Here is exception filter expression
	{
		std::cout << "An exception was caught in __except." << std::endl;
	}

	return 0;
}
//int main() {
//	int* p = NULL;   // pointer to NULL
//	for (long long int i = 0; ++i; (&i)[i] = i);
//	std::cout << "hi" << std::endl;
//	return 0;
//}