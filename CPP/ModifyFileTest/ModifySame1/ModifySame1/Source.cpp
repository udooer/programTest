#include<fstream>
#include<iostream>
#include"Windows.h"
using namespace std;
int main() {
	try {
		std::ofstream myfile;
		for (unsigned int i = 0;i < 256;i++) {
			myfile.open("D:\\asus_2021\\programTest\\CPP\\ModifyFileTest\\test.txt", std::fstream::in | std::fstream::out | std::fstream::app);
			myfile << i + 10000 << '\n';
			
			myfile.close();
			Sleep(100);
		}
	}
	catch (exception e) {
		cout << e.what() << endl;
	}
	
	return 0;
}