#include <stdio.h>
#include <string.h>
int main()
{
    char s[10001];
    scanf("%s", &s);
    int count[26] = {0};

    for (int i = 0; i < strlen(s); i++)
    {
        int index = s[i] - 'a';
        count[index]++;
    }

    for (int j = 0; j < 26; j++)
    {
        if (count[j] != 0)
        {
            char ck = j + 'a';
            printf("%c - %d \n", ck, count[j]);
        }
    }

    return 0;
}