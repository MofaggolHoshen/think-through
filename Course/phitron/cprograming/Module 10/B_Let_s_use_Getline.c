#include <stdio.h>
int main()
{
    char s[100001];
    fgets(s,100001,stdin);

    int i = 0;
    while(s[i] != '\\')
    {
        printf("%c", s[i]);
        i++;
    }

    return 0;
}