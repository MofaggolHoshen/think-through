#include <stdio.h>
int main()
{
    int tCase;
    scanf("%d", &tCase);

    for (int i = 0; i < tCase; i++)
    {
        char s[10001];
        scanf("%s", &s);
        int small = 0, big = 0, digit = 0;
        for (int k = 0; k < 10000; k++)
        {
            if (s[k] == '\0')
            {
                break;
            }
            else if (s[k] >= 'a' && s[k] <= 'z')
            {
                // small letter
                small++;
            }
            else if (s[k] >= 'A' && s[k] <= 'Z')
            {
                // big letter
                big++;
            }
            else if (s[k] >= '0' && s[k] <= '9')
            {
                // digit
                digit++;
            }
        }

        printf("%d %d %d\n", big, small, digit);
    }

    return 0;
}