#include <stdio.h>
#include "Everything.h"

#define DIRNAME_LEN (MAX_PATH + 2)
BOOL PrintMsg(HANDLE hOut, LPCTSTR pMsg);
VOID ReportError(LPCTSTR userMessage, DWORD exitCode, BOOL printErrorMessage);

pointersizeof() {

	char c_var;
	int i_var;
	double d_var;
	char* char_ptr;
	int* int_ptr;
	double* double_ptr;
	char_ptr = &c_var;
	int_ptr = &i_var;
	double_ptr = &d_var;
	printf("Size of char pointer = %d value = %u\n", sizeof(char_ptr), char_ptr);
	printf("Size of integer pointer = %d value = %u\n", sizeof(int_ptr), int_ptr);
	printf("Size of double pointer = %d value = %u\n", sizeof(double_ptr), double_ptr);
	_getch();
}

printcurrentdir() {
	TCHAR pwdBuffer[DIRNAME_LEN];
	DWORD lenCurDir;
	lenCurDir = GetCurrentDirectory(DIRNAME_LEN, pwdBuffer);
	if (lenCurDir == 0)
		ReportError(_T("Failure getting pathname."), 1, TRUE);
	if (lenCurDir > DIRNAME_LEN)
		ReportError(_T("Pathname is too long."), 2, FALSE);

	PrintMsg(GetStdHandle(STD_OUTPUT_HANDLE), pwdBuffer);
	return 0;
}
