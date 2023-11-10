#include <stdio.h>
#include <string.h>

int is_palindrome(char str[])
{
 int len = strlen(str);
 int last = len - 1;
 int isPalindrome = 1;
 for(int i = 0; i< len; i++)
 {
    if(i==last)
    {
        break;
    }
    
    if(str[i] == str[last])
    {
        isPalindrome = 1;
    }else{
        isPalindrome = -1;
       break;
    }

    last--;
 }
 return isPalindrome;
}
int main()
{
    char input[1001];
    
    scanf("%s", input);
    int result = is_palindrome(input);

    if(result == 1)
    {
        printf("Palindrome");
    }else{
        printf("Not Palindrome");
    }

    return 0;
}