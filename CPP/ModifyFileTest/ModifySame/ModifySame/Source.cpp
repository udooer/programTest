#include<fstream>
#include<Windows.h>
#include<iostream>
using namespace std;
int main() {
	std::ofstream myfile;
	try {
		for (unsigned int i = 0;i < 256;i++) {
			myfile.open("D:\\asus_2021\\programTest\\CPP\\ModifyFileTest\\test.txt", std::fstream::in | std::fstream::out | std::fstream::app);
			myfile << i << '\n';
			
			myfile.close();
			Sleep(100);
		}
	}
	catch (exception e) {
		cout << e.what() << endl;
	}
	
	return 0;
}