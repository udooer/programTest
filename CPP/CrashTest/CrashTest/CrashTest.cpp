// CrashTest.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <excpt.h>
static int exception_filter(unsigned int code, struct _EXCEPTION_POINTERS* ep)
{
	
	return EXCEPTION_EXECUTE_HANDLER;
}
int main()
{
	int* p = NULL;   // pointer to NULL
	__try
	{
		// Guarded code
		//*p = 13; // causes an access violation exception
		for (long long int i = 0; ++i; (&i)[i] = i);
	}
	__except (exception_filter(GetExceptionCode(), GetExceptionInformation())) // Here is exception filter expression
	{
		std::cout << "An exception was caught in __except." << std::endl;
	}
 //   //abort();
	//try {
	//	for (long long int i = 0; ++i; (&i)[i] = i);
	//	
	//}
	//catch (...) {
	//	std::cout << "Hello World!\n";
	//}
 //   
 //   return 0;
}
//void fail()
//{
//    // generates SE and attempts to catch it using catch(...)
//    try
//    {
//        int i = 0, j = 1;
//        j /= i;   // This will throw a SE (divide by zero).
//        printf("%d", j);
//        //for (long long int i = 0; ++i; (&i)[i] = i);
//        //abort();
//    }
//    catch (...)
//    {
//        // catch block will only be executed under /EHa
//        std::cout << "Caught an exception in catch(...)." << std::endl;
//        return;
//    }
//}
//
//int main()
//{
//    __try
//    {
//        fail();
//    }
//
//    // __except will only catch an exception here
//    __except (EXCEPTION_EXECUTE_HANDLER)
//    {
//        // if the exception was not caught by the catch(...) inside fail()
//        std::cout << "An exception was caught in __except." << std::endl;
//    }
//}
// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
