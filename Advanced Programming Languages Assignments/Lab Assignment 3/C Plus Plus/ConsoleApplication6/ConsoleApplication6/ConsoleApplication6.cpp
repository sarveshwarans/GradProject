#include "stdafx.h"
#include <iostream>
#include <algorithm>
#include <vector>
#include <string>
#include <utility>
using namespace std;
struct Person
{
	string name;
	int age;
};
bool compareByAge(const Person &a, const Person &b)
{
	if (a.age == b.age)
		return b.name>a.name;
	else
		return a.age > b.age;
}
void main()
{
	double doubleArray[]= { 645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26 };
	int numOfElem = sizeof(doubleArray) / sizeof(doubleArray[0]);
	stable_sort(doubleArray, doubleArray+numOfElem);
	cout << "Floating Point Number Arranged In Increasing Order"<<"\n";
	for (int i = 0; i < numOfElem; i++)
	{
		cout << doubleArray[i] << " ";
	}
	cout << "\n";
	cout << "\n";
	string stringArray[] = { "Hal","Susann","Dwight","Kassandra","Lawrence","Cindy","Cory","Mac","Romana","Doretha","Danna",
		"Zara","Rosalyn","Risa","Benny","Juan","Natalie" };
	numOfElem = sizeof(stringArray) / sizeof(stringArray[0]);
	stable_sort(stringArray, stringArray + numOfElem);
	cout << "User Names Arranged In Ascending Order" << "\n";
	for (int i = 0; i < numOfElem; i++)
	{
		cout << stringArray[i] << " ";
	}
	cout << "\n";
	cout << "\n";
	string nameArray[] = { "Hal","Susann","Dwight","Kassandra","Lawrence","Cindy","Cory","Mac","Romana","Doretha","Danna",
		"Zara","Rosalyn","Risa","Benny","Juan","Natalie" };
	int ageArray[] = {20,31,19,21,25,22,27,19,27,32,20,23,26,24,28,33,25};
	numOfElem = sizeof(nameArray) / sizeof(nameArray[0]);

	vector<Person> p;

	for (int i = 0; i < numOfElem; i++)
	{
		p.push_back(Person());
		p[i].name = nameArray[i];
		p[i].age = ageArray[i] ;
	}

	std::sort(p.begin(), p.end(), compareByAge);
	cout << "User Names Arranged In Descending Order Of Their Age" << "\n";
	for (Person n : p)
	{
		cout << n.age << " "<< n.name<<" , ";
	}
	cin.get();

}