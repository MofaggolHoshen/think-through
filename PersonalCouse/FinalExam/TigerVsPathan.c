#include <stdio.h>

int main()
{
    int t;
    scanf("%d", &t);
    int result[100][2] = {0};

    for (int i = 0; i < t; i++)
    {
        int n;
        scanf("%d", &n);

        char txt[n];
        scanf("%s", txt);
        for (int j = 0; j < n; j++)
        {
            if (txt[j] == 'T' || txt[j] == 't')
            {
                result[i][0]++;
            }
            else if (txt[j] == 'P' || txt[j] == 'p')
            {
                result[i][1]++;
            }
        }
    }

    for (int k = 0; k < t; k++)
    {
        if (result[k][0] > result[k][1])
        {
            printf("Tiger\n");
        }
        else if (result[k][1] > result[k][0])
        {
            printf("Pathaan\n");
        }
        else
        {
            printf("Draw\n");
        }
    }
    return 0;
}