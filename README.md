#include <stdio.h>

//Struct creation
struct employee{
	
	char name[12];
	int RollNum;
	int NumMonths;
	int AvgSalary;
};
int main(){
	
	//emp1 and pointer declaration
	struct employee emp1;
	struct employee* ptr = &emp1;
	
	//Input taking
	printf("What is the Employees Name: ");
	scanf("%s", ptr->name);
	
	printf("What is %s's RollNumber?: ", ptr->name);
	scanf("%d", &ptr->RollNum);
	
	printf("How many months did %s's work?: ", ptr->name);
	scanf("%d", &ptr->NumMonths);
	
	printf("Out of the total amount of %d months, what what %s's Average Salary?: ", ptr->NumMonths, ptr->name);
	scanf("%d", &ptr->AvgSalary);
	
	
	//Checking if the data was taken correctly
	printf("-----------------\n");
	printf("name: %s\nrollnum: %d\nnummonths: %d\nAvgsalary: %d", emp1.name, emp1.RollNum, emp1.NumMonths, emp1.AvgSalary);
	
	return 0;
	
}