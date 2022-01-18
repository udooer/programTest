#include<sstream>
#include<string>
#include<iostream>
using namespace std;
int main() {
	stringstream ss;
	string s;
	string output="";
	ss << "thefirstline";
	ss >> s;
	output += s;
	ss.clear();
	ss << "thesecondline\n" << endl;
	ss >> s;
	output += s;
	cout << s << endl;
	return 0;
}